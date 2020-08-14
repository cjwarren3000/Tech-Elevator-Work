using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class AccountSqlDAO : IAccountDAO
    {
        private readonly string connectionString;

        const string sql_getAccount = "SELECT * FROM accounts WHERE user_id = @user_id";
        const string sql_withdrawal = "update accounts set balance = balance - @amount " +
            "WHERE user_id = @user_id;";
        const string sql_deposit = "update accounts set balance = balance + @amount " +
            "WHERE user_id = @user_id;";
        const string sql_accountToUser = "SELECT * FROM accounts;";
        const string sql_userToName = "SELECT * FROM users;";
        const string sql_typeToName = "SELECT * FROM transfer_types;";
        const string sql_statusToName = "SELECT * FROM transfer_statuses;";

        public AccountSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Account GetAccount(int user_id)
        {
            Account result = new Account();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_getAccount, conn);
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result.AccountId = Convert.ToInt32(reader["account_id"]);
                        result.UserId = Convert.ToInt32(reader["user_id"]);
                        result.Balance = Convert.ToDecimal(reader["balance"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return result;
        }

        public Dictionary<int, int> AccountToUser()
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_accountToUser, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int accountId = Convert.ToInt32(reader["account_id"]);
                        int userId = Convert.ToInt32(reader["user_id"]);

                        result[accountId] = userId;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return result;
        }

        public Dictionary<int, string> UserToName()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_userToName, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader["user_id"]);
                        string name = Convert.ToString(reader["username"]);

                        result[userId] = name;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return result;
        }

        public Dictionary<int, string> TypeToName()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_typeToName, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader["transfer_type_id"]);
                        string name = Convert.ToString(reader["transfer_type_desc"]);

                        result[userId] = name;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return result;
        }

        public Dictionary<int, string> StatusToName()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_statusToName, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader["transfer_status_id"]);
                        string name = Convert.ToString(reader["transfer_status_desc"]);

                        result[userId] = name;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return result;
        }

        public bool Withdrawal(Transfer transfer)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_withdrawal, conn);
                    cmd.Parameters.AddWithValue("@amount", transfer.Amount);
                    cmd.Parameters.AddWithValue("@user_id", transfer.FromUser);
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

        public bool Deposit(Transfer transfer)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_deposit, conn);
                    cmd.Parameters.AddWithValue("@amount", transfer.Amount);
                    cmd.Parameters.AddWithValue("@user_id", transfer.ToUser);
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
    }
}
