using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class TransferSqlDAO: ITransferDAO
    {
        private readonly string connectionString;

        const string sql_addTransfer = "INSERT INTO transfers (transfer_type_id, transfer_status_id, " +
            "account_from, account_to, amount) VALUES (@transfer_type_id, @transfer_status_id, " +
            "@account_from, @account_to, @amount);";

        const string sql_updateTransfer = "UPDATE transfers SET transfer_status_id = @transfer_status_id " +
            "WHERE transfer_id = @transfer_id;";

        const string sql_getTransfers = "SELECT t.* FROM transfers t " +
            "JOIN accounts a on a.account_id = t.account_from " +
            "JOIN users u on u.user_id = a.user_id " +
            "WHERE u.user_id = @user_id " +
            "UNION " +
            "SELECT t.* FROM transfers t " +
            "JOIN accounts a on a.account_id = t.account_to " +
            "JOIN users u on u.user_id = a.user_id " +
            "WHERE u.user_id = @user_id;";

        public TransferSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<TransferRecord> GetTransfers(int userId)
        {
            List<TransferRecord> transfers = new List<TransferRecord>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_getTransfers, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TransferRecord transfer  =  GetTransferFromReader(reader);
                            transfers.Add(transfer);
                        }

                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return transfers;
        }

        public bool AddTransfer(Log log)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_addTransfer, conn);
                    cmd.Parameters.AddWithValue("@transfer_type_id", log.Type);
                    cmd.Parameters.AddWithValue("@transfer_status_id", log.Status);
                    cmd.Parameters.AddWithValue("@account_from", log.FromId);
                    cmd.Parameters.AddWithValue("@account_to", log.ToId);
                    cmd.Parameters.AddWithValue("@amount", log.Amount);
                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return result;
        }

        public bool UpdateTransfer(Log log)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_updateTransfer, conn);
                    cmd.Parameters.AddWithValue("@transfer_id", log.TransferId);
                    cmd.Parameters.AddWithValue("@transfer_status_id", log.Status);

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return result;
        }

        private TransferRecord GetTransferFromReader(SqlDataReader reader)
        {
            TransferRecord transfer = new TransferRecord
            {
                TransferId = Convert.ToInt32(reader["transfer_id"]),
                TransferTypeId = Convert.ToInt32(reader["transfer_type_id"]),
                TransferStatusId = Convert.ToInt32(reader["transfer_status_id"]),
                AccountFrom = Convert.ToInt32(reader["account_from"]),
                AccountTo = Convert.ToInt32(reader["account_to"]),
                Amount = Convert.ToDecimal(reader["amount"])
            };

            return transfer;
        }
    }
}
