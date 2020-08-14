using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrganizer.DAL
{
    public class ProjectSqlDAO : IProjectDAO
    {
        private string connectionString;
        private string sql_ProjectTable = "SELECT * FROM project";
        private string sql_AddEmployeeToProject = "INSERT INTO project_employee (project_id, employee_id)" +
            "VALUES (@projectid, @employeeid)";
        private string sql_RemoveEmployeeFromProject = "DELETE project_employee" +
            "WHERE employee_id = @employeeid AND project_id = @projectid";
        private string sql_AddNewProject = "INSERT INTO project (project_id, name, from_date, to_date)" +
            "VALUES (@newProjectID, @newProjectName, @newProjectFromDate, @newProjectToDate)";
        private string sql_FindNewProjectID = "SELECT project_id FROM project" +
            "WHERE project_id = @projectID";


        // Single Parameter Constructor
        public ProjectSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns all projects.
        /// </summary>
        /// <returns></returns>
        public IList<Project> GetAllProjects()
        {

            List<Project> projects = new List<Project>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_ProjectTable, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        int projectId = Convert.ToInt32(reader["project_id"]);
                        string name = Convert.ToString(reader["name"]);
                        DateTime fromDate = Convert.ToDateTime(reader["from_date"]);
                        DateTime toDate = Convert.ToDateTime(reader["to_date"]);

                        Project item = new Project(projectId, name, fromDate, toDate);
                        projects.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                projects = new List<Project>();
            }

            return projects;
        }

        /// <summary>
        /// Assigns an employee to a project using their IDs.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool AssignEmployeeToProject(int projectId, int employeeId)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_AddEmployeeToProject, conn);

                    cmd.Parameters.AddWithValue("@projectid", projectId);
                    cmd.Parameters.AddWithValue("@employeeid", employeeId);

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

        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_RemoveEmployeeFromProject, conn);

                    cmd.Parameters.AddWithValue("@projectid", projectId);
                    cmd.Parameters.AddWithValue("@employeeid", employeeId);

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

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="newProject">The new project object.</param>
        /// <returns>The new id of the project.</returns>
        public int CreateProject(Project newProject)
        {
            int id = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_AddNewProject, conn);

                    cmd.Parameters.AddWithValue("@newProjectID",newProject.ProjectId);
                    cmd.Parameters.AddWithValue("@newProjectName", newProject.Name);
                    cmd.Parameters.AddWithValue("@newProjectFromDate", newProject.StartDate);
                    cmd.Parameters.AddWithValue("@newProjectToDate", newProject.EndDate);

                    SqlCommand cmd2 = new SqlCommand(sql_FindNewProjectID, conn);

                    SqlDataReader reader = cmd2.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        id = Convert.ToInt32(reader["project_id"]);
                    }
                }
            }
            catch (Exception ex)
            {
                id = 0;
            }
            return id;
        }

    }
}
