using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class TransferSqlDAO : ITransferDAO
    {
        private readonly string connectionString;
        const string sql_GetTransfersForUser = "SELECT tr.transfer_id transfer_id, tt.transfer_type_desc transfer_type_desc, ts.transfer_status_desc transfer_status_desc, tr.account_from account_from, usf.username account_from_name, tr.account_to account_to, ust.username account_to_name, tr.amount amount " +
            "FROM transfers tr " +
            "JOIN accounts acf ON tr.account_from = acf.account_id JOIN users usf ON acf.user_id = usf.user_id " +
            "JOIN accounts act ON tr.account_to = act.account_id JOIN users ust ON act.user_id = ust.user_id " +
            "JOIN transfer_types tt ON tr.transfer_type_id = tt.transfer_type_id " +
            "JOIN transfer_Statuses ts ON tr.transfer_status_id = ts.transfer_status_id " +
            "WHERE (tr.account_from = (SELECT account_id FROM accounts WHERE accounts.user_ID = @userId) " +
            "OR tr.account_to = (SELECT account_id FROM accounts WHERE accounts.user_ID = @userId)) " +
            "AND ts.transfer_status_id IN (2,3);";

        const string sql_GetAccountID = "SELECT account_id FROM accounts WHERE accounts.user_ID = @userId;";

        const string sql_GetPendingTransfersForUser = "SELECT tr.transfer_id transfer_id, tt.transfer_type_desc transfer_type_desc, ts.transfer_status_desc transfer_status_desc, tr.account_from account_from, usf.username account_from_name, tr.account_to account_to, ust.username account_to_name, tr.amount amount " +
            "FROM transfers tr " +
            "JOIN accounts acf ON tr.account_from = acf.account_id JOIN users usf ON acf.user_id = usf.user_id " +
            "JOIN accounts act ON tr.account_to = act.account_id JOIN users ust ON act.user_id = ust.user_id " +
            "JOIN transfer_types tt ON tr.transfer_type_id = tt.transfer_type_id " +
            "JOIN transfer_statuses ts ON tr.transfer_status_id = ts.transfer_status_id " +
            "WHERE (ts.transfer_status_id = 1) " +
            "AND (tr.account_to = (SELECT account_id FROM accounts WHERE accounts.user_ID = @userId) " +
            "OR tr.account_from = (SELECT account_id FROM accounts WHERE accounts.user_ID = @userId));";

        const string sql_AddNewTransfer = "INSERT INTO transfers (transfer_type_id, transfer_status_id, account_from, account_to, amount)" +
            " VALUES (@transferTypeId, @transferStatusId, @accountFrom, @accountTo, @amount);";

        const string sql_UpdateTransfer = "UPDATE transfers SET transfer_status_id = @transferStatusID WHERE transfer_id = @transferId;";

        public TransferSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        //Get transfers that logged in user is a part of
        public List<Transfer> GetTranfersForUser(int userId)
        {
            List<Transfer> transfers = new List<Transfer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    AccountSqlDAO accountSqlDAO = new AccountSqlDAO(connectionString);
                    int accountID = accountSqlDAO.GetUsersAccount(userId).AccountID;
                    SqlCommand cmd = new SqlCommand(sql_GetTransfersForUser, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Transfer transfer = new Transfer();
                        transfer.transferId = Convert.ToInt32(reader["transfer_id"]);
                        transfer.transferTypeDesc = Convert.ToString(reader["transfer_type_desc"]);
                        transfer.transferStausDesc = Convert.ToString(reader["transfer_status_desc"]);
                        transfer.accountFrom = Convert.ToInt32(reader["account_from"]);
                        transfer.accountFromName = Convert.ToString(reader["account_from_name"]);
                        //identify the user in a transfer when we display it
                        if (transfer.accountFrom == accountID)
                        {
                            transfer.accountFromName += " (You)";
                        }
                        transfer.accountTo = Convert.ToInt32(reader["account_to"]);
                        transfer.accountToName = Convert.ToString(reader["account_to_name"]);
                        if (transfer.accountTo == accountID)
                        {
                            transfer.accountToName += " (You)";
                        }
                        transfer.amount = Convert.ToDecimal(reader["amount"]);
                        transfers.Add(transfer);
                    }
                }
            }
            catch (SqlException ex)
            {
                transfers = new List<Transfer>();
            }
            return transfers;
        }
        //Get all pending transfers that the user needs to approve/decline
        public List<Transfer> GetPendingTransfersForUser(int userId)
        {
            List<Transfer> pendingTransfers = new List<Transfer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    AccountSqlDAO accountSqlDAO = new AccountSqlDAO(connectionString);
                    int accountID = accountSqlDAO.GetUsersAccount(userId).AccountID;
                    SqlCommand cmd = new SqlCommand(sql_GetPendingTransfersForUser, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Transfer transfer = new Transfer();
                        transfer.transferId = Convert.ToInt32(reader["transfer_id"]);
                        transfer.transferTypeDesc = Convert.ToString(reader["transfer_type_desc"]);
                        transfer.transferStausDesc = Convert.ToString(reader["transfer_status_desc"]);
                        transfer.accountFrom = Convert.ToInt32(reader["account_from"]);
                        transfer.accountFromName = Convert.ToString(reader["account_from_name"]);
                        //identify the user in a transfer when we display it
                        if (transfer.accountFrom == accountID)
                        {
                            transfer.accountFromName += " (You)";
                        }
                        transfer.accountTo = Convert.ToInt32(reader["account_to"]);
                        transfer.accountToName = Convert.ToString(reader["account_to_name"]);
                        //identify the user in a transfer when we display it
                        if (transfer.accountTo == accountID)
                        {
                            transfer.accountToName += " (You)";
                        }
                        transfer.amount = Convert.ToDecimal(reader["amount"]);
                        pendingTransfers.Add(transfer);
                    }
                }
            }
            catch (SqlException ex)
            {
                pendingTransfers = new List<Transfer>();
            }

            return pendingTransfers;
        }
        // Create a new transfer
        public Transfer CreateTransfer(Transfer newTransfer)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql_AddNewTransfer, conn);
                        cmd.Parameters.AddWithValue("@transferTypeId", newTransfer.transferTypeId);
                        cmd.Parameters.AddWithValue("@transferStatusId", newTransfer.transferStatusId);
                        cmd.Parameters.AddWithValue("@accountFrom", newTransfer.accountFrom);
                        cmd.Parameters.AddWithValue("@accountTo", newTransfer.accountTo);
                        cmd.Parameters.AddWithValue("@amount", newTransfer.amount);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("SELECT @@IDENTITY", conn);
                        newTransfer.transferId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    scope.Complete();
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
            return newTransfer;
        }
        //update pending transfers
        public Transfer UpdateTransfer(Transfer updatedTransfer)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql_UpdateTransfer, conn);
                        cmd.Parameters.AddWithValue("@transferStatusID", updatedTransfer.transferStatusId);
                        cmd.Parameters.AddWithValue("@transferId", updatedTransfer.transferId);
                        int affectedRows = cmd.ExecuteNonQuery();
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                updatedTransfer = null;
            }
            return updatedTransfer;
        }
    }
}
