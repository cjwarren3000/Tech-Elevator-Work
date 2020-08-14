using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class StudentSqlDAO : IStudentDAO
    {
        private const string SelectAllSql = "SELECT FirstName, LastName, Id, Email, Phone, GPA, Notes FROM Students";
        private const string SelectOneSql = "SELECT FirstName, LastName, Id, Email, Phone, GPA, Notes FROM Students WHERE Id = @StudentId";
        private const string DeleteOneSql = "DELETE FROM Students WHERE Id = @StudentId";
        private const string CreateOneSql = "INSERT INTO Students (FirstName, LastName, Email, Phone, GPA, Notes) VALUES (@First, @Last, @Email, @Phone, @GPA, @Notes); SELECT @@IDENTITY;";
        private const string UpdateOneSql = "UPDATE Students SET FirstName = @First, LastName = @Last, Email = @Email, Phone = @Phone, GPA = @GPA, Notes = @Notes WHERE Id = @StudentId";

        private readonly string _connectionString;

        public StudentSqlDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(SelectAllSql, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student student = GetStudentFromReader(reader);

                        students.Add(student);
                    }
                }
            }

            return students;
        }

        public Student GetStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(SelectOneSql, conn);
                command.Parameters.AddWithValue("@StudentId", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return GetStudentFromReader(reader);
                    }
                }
            }

            return null;
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(DeleteOneSql, conn);
                command.Parameters.AddWithValue("@StudentId", id);

                command.ExecuteNonQuery();
            }
        }

        public Student CreateStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(CreateOneSql, conn);
                command.Parameters.AddWithValue("@First", student.FirstName);
                command.Parameters.AddWithValue("@Last", student.LastName);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Phone", student.Phone);
                command.Parameters.AddWithValue("@GPA", student.GPA);
                command.Parameters.AddWithValue("@Notes", student.Notes);

                int id = Convert.ToInt32(command.ExecuteScalar());

                student.Id = id;

                return student;
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(UpdateOneSql, conn);
                command.Parameters.AddWithValue("@StudentId", student.Id);
                command.Parameters.AddWithValue("@First", student.FirstName);
                command.Parameters.AddWithValue("@Last", student.LastName);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Phone", student.Phone);
                command.Parameters.AddWithValue("@GPA", student.GPA);
                command.Parameters.AddWithValue("@Notes", student.Notes);

                command.ExecuteNonQuery();
            }
        }

        private static Student GetStudentFromReader(SqlDataReader reader)
        {
            return new Student
            {
                FirstName = Convert.ToString(reader["FirstName"]),
                LastName = Convert.ToString(reader["LastName"]),
                Id = Convert.ToInt32(reader["Id"]),
                Email = Convert.ToString(reader["Email"]),
                Phone = Convert.ToString(reader["Phone"]),
                GPA = Convert.ToDecimal(reader["GPA"]),
                Notes = Convert.ToString(reader["Notes"]),
            };
        }

    }
}
