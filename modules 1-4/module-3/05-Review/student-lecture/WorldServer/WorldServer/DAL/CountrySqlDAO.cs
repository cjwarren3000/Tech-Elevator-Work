using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldServer.Models;

namespace WorldServer.DAL
{
    public class CountrySqlDAO : ICountryDAO
    {
        private string connectionString;

        public CountrySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public List<Country> GetCountries()
        {
            // Declare the output variable
            List<Country> countries = new List<Country>();

            try
            {
                // Create a connection to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create a command to send to the database
                    SqlCommand cmd = new SqlCommand("SELECT * FROM country;", conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read each row
                    while (reader.Read())
                    {
                        Country ctry = ConvertReaderToCountry(reader);
                        countries.Add(ctry);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }

            // Return the output
            return countries;
        }

        public List<Country> GetCountries(string continent)
        {
            List<Country> countries = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                                                                                // column    // param name  
                    SqlCommand cmd = new SqlCommand("SELECT * FROM country WHERE continent = @continent;", conn);
                                               // param name    // param value
                    cmd.Parameters.AddWithValue("@continent", continent);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Country ctry = ConvertReaderToCountry(reader);
                        countries.Add(ctry);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred reading countries by continent.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return countries;
        }

        public Country GetCountry(string countryCode)
        {
            Country country = new Country();

            try
            {
                // Create a connection to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create a command to send to the database
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM country where code = @countryCode;", conn);

                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read each row
                    if (reader.Read())
                    {
                        country = ConvertReaderToCountry(reader);  
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }

            // Return the output
            return country;
        }

        private Country ConvertReaderToCountry(SqlDataReader reader)
        {
            Country ctry = new Country();

            ctry.Code = Convert.ToString(reader["code"]);
            ctry.Name = Convert.ToString(reader["name"]);
            ctry.Continent = Convert.ToString(reader["continent"]);
            ctry.Region = Convert.ToString(reader["region"]);
            ctry.SurfaceArea = Convert.ToDouble(reader["surfacearea"]);
            ctry.Population = Convert.ToInt32(reader["population"]);
            ctry.GovernmentForm = Convert.ToString(reader["governmentform"]);

            return ctry;
        }

    }
}
