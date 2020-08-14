using CateringDataExample.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CateringDataExample
{
    public class DatabaseAccess
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CateringSystem;Integrated Security=True";

        private string sql_GetInventoryList = "SELECT * FROM inventory;";
        private string sql_WriteLogData = "INSERT INTO log (logtime, description,  startamount, endamount) " +
            "VALUES (@logtime, @description, @startamount, @endamount);";


        public List<CateringItem> GetInventoryList()
        {
            List<CateringItem> result = new List<CateringItem>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_GetInventoryList, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        string code = Convert.ToString(reader["code"]);
                        string name = Convert.ToString(reader["name"]);
                        decimal price = Convert.ToDecimal(reader["price"]);
                        string type = Convert.ToString(reader["type"]);

                        CateringItem item = new CateringItem(code, name, price, type, 50);
                        result.Add(item);
                    }

                }

            }
            catch (Exception ex)
            {
                result = new List<CateringItem>();
            }

            return result;
        }

        public bool WriteLogData( string message, decimal startAmount, decimal endAmount)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_WriteLogData, conn);

                    cmd.Parameters.AddWithValue("@logtime", DateTime.Now.ToLocalTime());
                    cmd.Parameters.AddWithValue("@description", message);
                    cmd.Parameters.AddWithValue("@startamount", startAmount);
                    cmd.Parameters.AddWithValue("@endamount", endAmount);

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }


    }
}
