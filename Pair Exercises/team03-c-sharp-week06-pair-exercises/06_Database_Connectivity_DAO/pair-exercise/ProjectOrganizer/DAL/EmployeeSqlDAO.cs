using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrganizer.DAL
{
    public class EmployeeSqlDAO : IEmployeeDAO
    {
        private string sql_GetEmployeeList = "SELECT * FROM employee";
        private string sql_EmployeeSearch = "SELECT * FROM employee" +
            "WHERE first_name = @firstname" +
            "OR last_name = @lastname";
        private string sql_EmployeeNoProject = "SELECT employee.birth_date, employee.department_id, employee.employee_id, employee.first_name, employee.gender, employee.hire_date, employee.job_title, employee.last_name FROM employee" +
            "JOIN project_employee ON employee.employee_id = project_employee.employee_id" +
            "JOIN project ON project_employee.project_id = project.project_id" +
            "WHERE to_date > @currentDate";

        private string connectionString;

        // Single Parameter Constructor
        public EmployeeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the employees.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        public IList<Employee> GetAllEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_GetEmployeeList, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        int employeeId = Convert.ToInt32(reader["employee_id"]);
                        int departmentId = Convert.ToInt32(reader["department_id"]);
                        string jobTitle = Convert.ToString(reader["job_title"]);
                        string firstName = Convert.ToString(reader["first_name"]);
                        string lastName = Convert.ToString(reader["last_name"]);
                        DateTime birthDate = Convert.ToDateTime(reader["birth_date"]);
                        string gender = Convert.ToString(reader["gender"]);
                        DateTime hireDate = Convert.ToDateTime(reader["hire_date"]);

                        Employee item = new Employee(employeeId, departmentId, jobTitle, firstName, lastName, birthDate, gender, hireDate);
                        employeeList.Add(item);

                    }
                }
            }
            catch (Exception ex)
            {
                employeeList = new List<Employee>();
            }

            return employeeList;
        }

        /// <summary>
        /// Searches the system for an employee by first name or last name.
        /// </summary>
        /// <remarks>The search performed is a wildcard search.</remarks>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns>A list of employees that match the search.</returns>
        public IList<Employee> Search(string firstname, string lastname)
        {
            List<Employee> searchResults = new List<Employee>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_EmployeeSearch, conn);

                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@lastname", lastname);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        int employeeId = Convert.ToInt32(reader["employee_id"]);
                        int departmentId = Convert.ToInt32(reader["department_id"]);
                        string jobTitle = Convert.ToString(reader["job_title"]);
                        string firstName = Convert.ToString(reader["first_name"]);
                        string lastName = Convert.ToString(reader["last_name"]);
                        DateTime birthDate = Convert.ToDateTime(reader["birth_date"]);
                        string gender = Convert.ToString(reader["gender"]);
                        DateTime hireDate = Convert.ToDateTime(reader["hire_date"]);

                        Employee item = new Employee(employeeId, departmentId, jobTitle, firstName, lastName, birthDate, gender, hireDate);
                        searchResults.Add(item);
                    }

                }
            }
            catch
            {
                searchResults = new List<Employee>();
            }
            return searchResults;
        }

        /// <summary>
        /// Gets a list of employees who are not assigned to any active projects.
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetEmployeesWithoutProjects()
        {
            List<Employee> employeesWithNoProject = new List<Employee>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_EmployeeNoProject, conn);

                    cmd.Parameters.AddWithValue("@currentDate", DateTime.Today.ToString("yyyy-MM-dd"));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        int employeeId = Convert.ToInt32(reader["employee_id"]);
                        int departmentId = Convert.ToInt32(reader["department_id"]);
                        string jobTitle = Convert.ToString(reader["job_title"]);
                        string firstName = Convert.ToString(reader["first_name"]);
                        string lastName = Convert.ToString(reader["last_name"]);
                        DateTime birthDate = Convert.ToDateTime(reader["birth_date"]);
                        string gender = Convert.ToString(reader["gender"]);
                        DateTime hireDate = Convert.ToDateTime(reader["hire_date"]);

                        Employee item = new Employee(employeeId, departmentId, jobTitle, firstName, lastName, birthDate, gender, hireDate);
                        employeesWithNoProject.Add(item);
                    }

                }
            }
            catch
            {
                employeesWithNoProject = new List<Employee>();
            }
            return employeesWithNoProject;
        }
    }
}
