using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrganizer.DAL
{
    public class DepartmentSqlDAO : IDepartmentDAO
    {
        private string sql_UpdateDepartment = "UPDATE department" +
            "SET name = @updatedName" +
            "WHERE id = @idToUpdate";
        private string sql_GetDepartmentList = "SELECT * FROM department";
        private string sql_FindNewDepartment = "SELECT id FROM department" +
            "WHERE name = @newDepartment";
        private string sql_CreateDepartment = "INSERT INTO department(name)" +
            "VALUES (@newDepartment)";
        private string connectionString;


        // Single Parameter Constructor
        public DepartmentSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the departments.
        /// </summary>
        /// <returns></returns>
        public IList<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_GetDepartmentList, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = Convert.ToString(reader["name"]);

                        Department item = new Department(id, name);
                        departments.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                departments = new List<Department>();
            }

            return departments;
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="newDepartment">The department object.</param>
        /// <returns>The id of the new department (if successful).</returns>
        public int CreateDepartment(Department newDepartment)
        {
            int id = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_CreateDepartment, conn);

                    cmd.Parameters.AddWithValue("@newDepartment", newDepartment);

                    SqlCommand dmc = new SqlCommand(sql_FindNewDepartment, conn);

                    dmc.Parameters.AddWithValue("@newDepartment", newDepartment);

                    SqlDataReader reader = dmc.ExecuteReader();
                    while (reader.Read()== true)
                    {
                        id = Convert.ToInt32(reader["id"]);
                    }
                }
            }
            catch (Exception ex)
            {
               id = 0;
            }
            return id;
        }
        
        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="updatedDepartment">The department object.</param>
        /// <returns>True, if successful.</returns>
        public bool UpdateDepartment(Department updatedDepartment)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_CreateDepartment, conn);

                    cmd.Parameters.AddWithValue("@updatedName", updatedDepartment.Name);
                    cmd.Parameters.AddWithValue("@idToUpdate", updatedDepartment.Id);

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
