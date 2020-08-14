using Microsoft.VisualStudio.TestTools.UnitTesting;
using CateringDataExample;
using System.Collections.Generic;
using CateringDataExample.Models;
using System.Transactions;
using System.Data.SqlClient;

namespace CateringDataTest
{
    [TestClass]
    public class DatabaseAccessTest
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CateringSystem;Integrated Security=True";

        private TransactionScope transaction;

        [TestInitialize]
        public void Initalize()
        {
            transaction = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql_insert = "INSERT INTO inventory (code, name, price, type) VALUES ('X1', 'Test Product', 9.99, 'X');";
                SqlCommand cmd = new SqlCommand(sql_insert, conn);
                int count = cmd.ExecuteNonQuery();

                Assert.AreEqual(1, count, "Insert into inventory failed");
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void TestGetInventoryList()
        {
            DatabaseAccess access = new DatabaseAccess();

            List<CateringItem> items = access.GetInventoryList();

            bool found = false;
            foreach(CateringItem item in items)
            {
                if (item.ProductCode == "X1")
                {
                    found = true;
                    break;
                }
            }

            Assert.IsTrue(found);
        }

        [TestMethod]
        public void TestWriteDataLog()
        {
            DatabaseAccess access = new DatabaseAccess();

            bool result = access.WriteLogData("Xyzzy", 999.99M, 8888.88M);

            Assert.IsTrue(result);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql_select = "SELECT * FROM log WHERE description = 'Xyzzy';";

                SqlCommand cmd = new SqlCommand(sql_select, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                int count = 0;

                while (reader.Read())
                {
                    count++;
                }

                Assert.AreEqual(1, count);
            }
        }
    }
}
