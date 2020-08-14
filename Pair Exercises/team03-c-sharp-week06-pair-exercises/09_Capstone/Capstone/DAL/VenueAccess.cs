using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class VenueAccess
    {
        private string connectionString;

        public VenueAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public VenueAccess()
        {

        }


        public List<Venue> VenueList()
        {
            string sql_GetVenueList = "SELECT * FROM venue ORDER BY name;";
            List<Venue> venues = new List<Venue>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_GetVenueList, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = Convert.ToString(reader["name"]);
                        int cityId = Convert.ToInt32(reader["city_id"]);
                        string description = Convert.ToString(reader["description"]);

                        Venue Item = new Venue(id, name, cityId, description);
                        venues.Add(Item);

                    }
                }
            }
            catch (Exception ex)
            {
                venues = new List<Venue>();
            }

            return venues;
        }




        public VenueDetails Details(Venue userInput)
        {
            List<string> categories = new List<string>();
            VenueDetails result = new VenueDetails();
            string sql_GetCityInfo = "SELECT * FROM city" +
                " WHERE @userInput = id";
            string sql_GetCategoryInfo = "SELECT category.name FROM venue" +
                " JOIN category_venue ON venue.id = category_venue.venue_id" +
                " JOIN category ON category_venue.category_id = category.id" +
                " WHERE venue.name = @userInputName";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cityInfo = new SqlCommand(sql_GetCityInfo, conn);

                    cityInfo.Parameters.AddWithValue("@userInput", userInput.CityId);

                    SqlDataReader cityReader = cityInfo.ExecuteReader();


                    while (cityReader.Read() == true)
                    {
                        string name = Convert.ToString(cityReader["name"]);
                        string stateAbbreviation = Convert.ToString(cityReader["state_abbreviation"]);

                        result.CityName = name;
                        result.StateAbbreviation = stateAbbreviation;
                    }
                    cityReader.Close();

                    SqlCommand categoryInfo = new SqlCommand(sql_GetCategoryInfo, conn);

                    categoryInfo.Parameters.AddWithValue("@userInputName", userInput.Name);

                    SqlDataReader categoryReader = categoryInfo.ExecuteReader();


                    while (categoryReader.Read() == true)
                    {
                        string name = Convert.ToString(categoryReader["name"]);

                        categories.Add(name);
                    }




                }
            }
            catch (Exception ex)
            {

            }

            result.Categories = categories;
            return result;
        }

        public List<VenueSpace> DisplayVenueSpace(Venue userVenue)
        {
            List<VenueSpace> spaceList = new List<VenueSpace>();

            string sql_GetSpaceInfo = "SELECT s.id, s.name, s.open_from, s.open_to, s.daily_rate, s.max_occupancy FROM venue v" +
                    " JOIN space s ON s.venue_id = v.id" +
                    " WHERE v.name = @userInput";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand spaceInfo = new SqlCommand(sql_GetSpaceInfo, conn);

                    spaceInfo.Parameters.AddWithValue("@userInput", userVenue.Name);

                    SqlDataReader spaceReader = spaceInfo.ExecuteReader();

                    while (spaceReader.Read() == true)
                    {

                        string open = Convert.ToString(spaceReader["open_from"]);
                        string close = Convert.ToString(spaceReader["open_to"]);

                        if (string.IsNullOrEmpty(open))
                        {
                            open = "0";
                        }
                        if (string.IsNullOrEmpty(close))
                        {
                            close = "";
                        }


                        string name = Convert.ToString(spaceReader["name"]);
                        decimal dailyRate = Convert.ToDecimal(spaceReader["daily_rate"]);
                        int maxOccupancy = Convert.ToInt32(spaceReader["max_occupancy"]);
                        int spaceId = Convert.ToInt32(spaceReader["id"]);

                        VenueSpace result = new VenueSpace(spaceId, name, open, close, dailyRate, maxOccupancy);

                        spaceList.Add(result);
                    }




                }
            }
            catch (Exception ex)
            {
                spaceList = new List<VenueSpace>();
            }




            return spaceList;
        }



        public List<Reservation> SpaceReservationSearch(string userVenueName, string userStartDate, string userEndDate)
        {
            List<Reservation> searchResults = new List<Reservation>();
            string sql_ReservationSearch = "SELECT space.name, number_of_attendees, start_date, end_date, reserved_for, space.venue_id FROM reservation" +
                        " JOIN space ON reservation.space_id = space.id" +
                        " JOIN venue ON space.venue_id = venue.id" +
                        " WHERE venue.name = @userVenueName" +
                        " AND ((start_date > @userStartDate AND start_date< @userEndDate)" +
                        " OR (end_date > @userStartDate AND end_date< @userEndDate))";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand reservationSearch = new SqlCommand(sql_ReservationSearch, conn);

                    DateTime dateStart = DateTime.Parse(userStartDate);
                    DateTime dateEnd = DateTime.Parse(userEndDate);

                    reservationSearch.Parameters.AddWithValue("@userVenueName", userVenueName);
                    reservationSearch.Parameters.AddWithValue("@userStartDate", dateStart);
                    reservationSearch.Parameters.AddWithValue("@userEndDate", dateEnd);

                    SqlDataReader search = reservationSearch.ExecuteReader();

                    while (search.Read() == true)
                    {
                        string name = Convert.ToString(search["name"]);
                        int numberOfAttendees = Convert.ToInt32(search["number_of_attendees"]);
                        DateTime startDate = Convert.ToDateTime(search["start_date"]);
                        DateTime endDate = Convert.ToDateTime(search["end_date"]);
                        string reservedFor = Convert.ToString(search["reserved_for"]);
                        int venueId = Convert.ToInt32(search["venue_id"]);

                        Reservation item = new Reservation(name, numberOfAttendees, startDate, endDate, reservedFor, venueId);
                        searchResults.Add(item);

                    }

                }
            }
            catch
            {

            }

            return searchResults;
        }


        public HashSet<VenueSpace> DisplayTop5(List<Reservation> takenSpaces, Venue userVenue, int peopleAmt)
        {
            HashSet<VenueSpace> availableSpaces = new HashSet<VenueSpace>();

            string sql_FindAvailableSpaces = "SELECT TOP 5 * FROM space" +
                " WHERE name != @venueName" +
                " AND venue_id = @venueId" +
                " AND max_occupancy >= @peopleAmt" +
                " ORDER BY daily_rate desc";

            string sql_FindAllAvailableSpaces = "SELECT TOP 5 space.id, venue_id, space.name, is_accessible, open_from, open_to, daily_rate, max_occupancy FROM space" +
                " JOIN venue ON space.venue_id = venue.id" +
                " WHERE venue.name = @venueName" +
                " AND max_occupancy >= @peopleAmt" +
                " ORDER BY daily_rate desc";

            if (takenSpaces.Count > 0)
            {
                foreach (Reservation item in takenSpaces)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand findSpaces = new SqlCommand(sql_FindAvailableSpaces, conn);

                        findSpaces.Parameters.AddWithValue("@venueName", item.Name);
                        findSpaces.Parameters.AddWithValue("@venueId", item.VenueId);
                        findSpaces.Parameters.AddWithValue("@peopleAmt", peopleAmt);

                        SqlDataReader findSpaceReader = findSpaces.ExecuteReader();

                        while (findSpaceReader.Read() == true)
                        {

                            string open = Convert.ToString(findSpaceReader["open_from"]);
                            string close = Convert.ToString(findSpaceReader["open_to"]);

                            if (string.IsNullOrEmpty(open))
                            {
                                open = "0";
                            }
                            if (string.IsNullOrEmpty(close))
                            {
                                close = "";
                            }


                            string name = Convert.ToString(findSpaceReader["name"]);
                            decimal dailyRate = Convert.ToDecimal(findSpaceReader["daily_rate"]);
                            int maxOccupancy = Convert.ToInt32(findSpaceReader["max_occupancy"]);
                            int spaceId = Convert.ToInt32(findSpaceReader["id"]);

                            VenueSpace result = new VenueSpace(spaceId, name, open, close, dailyRate, maxOccupancy);

                            bool spaceIsTaken = false;

                            foreach (Reservation reservation in takenSpaces)
                            {
                                if (reservation.Name == result.Name)
                                {
                                    spaceIsTaken = true;
                                }
                            }
                            if (spaceIsTaken == false)
                            {
                                availableSpaces.Add(result);
                            }
                        }
                    }
                }
            }

            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand findSpaces = new SqlCommand(sql_FindAllAvailableSpaces, conn);

                    findSpaces.Parameters.AddWithValue("@venueName", userVenue.Name);
                    findSpaces.Parameters.AddWithValue("@peopleAmt", peopleAmt);

                    SqlDataReader findSpaceReader = findSpaces.ExecuteReader();

                    while (findSpaceReader.Read() == true)
                    {

                        string open = Convert.ToString(findSpaceReader["open_from"]);
                        string close = Convert.ToString(findSpaceReader["open_to"]);

                        if (string.IsNullOrEmpty(open))
                        {
                            open = "0";
                        }
                        if (string.IsNullOrEmpty(close))
                        {
                            close = "";
                        }


                        string name = Convert.ToString(findSpaceReader["name"]);
                        decimal dailyRate = Convert.ToDecimal(findSpaceReader["daily_rate"]);
                        int maxOccupancy = Convert.ToInt32(findSpaceReader["max_occupancy"]);
                        int spaceId = Convert.ToInt32(findSpaceReader["id"]);

                        VenueSpace result = new VenueSpace(spaceId, name, open, close, dailyRate, maxOccupancy);

                        availableSpaces.Add(result);

                    }
                }
            }

            return availableSpaces;
        }

        public bool AddReservation(int spaceId, int attendees, string startDate, string endDate, string reservedFor)
        {
            string sql_AddReservation = "INSERT INTO reservation (space_id, number_of_attendees, start_date, end_date, reserved_for)" +
                " VALUES (@spaceID, @attendees, @startDate, @endDate, @reservedFor)";

            bool success = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand addRes = new SqlCommand(sql_AddReservation, conn);

                    addRes.Parameters.AddWithValue("@spaceID", spaceId);
                    addRes.Parameters.AddWithValue("@attendees", attendees);
                    addRes.Parameters.AddWithValue("@startDate", startDate);
                    addRes.Parameters.AddWithValue("@endDate", endDate);
                    addRes.Parameters.AddWithValue("@reservedFor", reservedFor);


                    int rowsAffected = addRes.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        success = true;
                    }
                }
            }
            catch
            {

            }
            return success;
        }
    }
}
