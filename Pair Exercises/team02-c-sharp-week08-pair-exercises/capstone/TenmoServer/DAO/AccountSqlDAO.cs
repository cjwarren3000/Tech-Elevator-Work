using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class AccountSqlDAO : IAccountDAO
    {
        private readonly string connectionString;

        public AccountSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        string accountInfoSql = "SELECT * FROM accounts;";
        string sql_getAccount = "SELECT * FROM accounts WHERE user_id = @userid;";
        string sql_UpdateAccountBalance = "UPDATE accounts" +
            " SET balance = @accountBalance" +
            " WHERE account_id = @accountId";

        //Get all accounts
        public List<Account> AccountInfo(int loggedInUserId)
        {
            List<Account> accountList = new List<Account>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(accountInfoSql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        int accountId = Convert.ToInt32(reader["account_id"]);
                        int userId = Convert.ToInt32(reader["user_id"]);
                        decimal balance = Convert.ToDecimal(reader["balance"]);
                        bool isLoggedInUser = false;

                        if (userId == loggedInUserId)
                        {
                            isLoggedInUser = true;
                        }

                        Account account = new Account(accountId, userId, balance, isLoggedInUser);
                        accountList.Add(account);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return accountList;
        }
        //Get account for logged in user
        public Account GetUsersAccount(int loggedInUserId)
        {
            Account usersAccount = new Account();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql_getAccount, conn);
                    cmd.Parameters.AddWithValue("@userid", loggedInUserId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows && reader.Read())
                    {
                        usersAccount.AccountID = Convert.ToInt32(reader["account_id"]);
                        usersAccount.UserID = Convert.ToInt32(reader["user_id"]);
                        usersAccount.AccountBalance = Convert.ToDecimal(reader["balance"]);
                        usersAccount.IsLoggedInUser = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                usersAccount = new Account();
            }
            return usersAccount;
        }
        //Update balance of an account
        public Account UpdateAccountBalance(Account accountToUpdate)
        {
            Account updatedAccount = accountToUpdate;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql_UpdateAccountBalance, conn);

                        cmd.Parameters.AddWithValue("@accountId", accountToUpdate.AccountID);
                        cmd.Parameters.AddWithValue("@accountBalance", accountToUpdate.AccountBalance);

                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                    scope.Complete();
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
            return updatedAccount;
        }
    }
}
