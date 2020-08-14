using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone
{
    public class UserInterface
    {
        //ALL Console.ReadLine and WriteLine in this class
        //NONE in any other class


        private string connectionString;


        public UserInterface(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public void Run()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Welcome to Excelsior Venues' Reservation Platform");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1) List Venues");
                Console.WriteLine("Q) Quit");

                string choice = Console.ReadLine();
                string choiceUp = choice.ToUpper();

                switch (choiceUp)
                {
                    case "1":
                        done = true;
                        DisplayVenueItems();
                        break;
                    case "Q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please input a valid selection.");
                        break;

                }

            }
        }

        public void DisplayVenueItems()
        {
            VenueAccess va = new VenueAccess(connectionString);
            bool venueItems = false;
            bool ifR = false;
            int choiceInt = 0;
            Venue userVenue = new Venue();
            List<Venue> listOfVenues = new List<Venue>();
            listOfVenues = va.VenueList();

            while (!venueItems)
            {

                Console.WriteLine("Which venue would you like to view?");
                for (int i = 0; i < listOfVenues.Count; i++)
                {
                    Console.WriteLine((i + 1) + ") " + listOfVenues[i].Name);
                }
                Console.WriteLine("R) Return to previous screen");

                string choice = Console.ReadLine();


                try
                {
                    choiceInt = int.Parse(choice);

                    for (int i = 0; i < listOfVenues.Count; i++)
                    {
                        if (choiceInt - 1 == i)
                        {
                            venueItems = true;
                            userVenue = listOfVenues[i];
                            break;
                        }
                        else if (i == listOfVenues.Count - 1)
                        {
                            Console.WriteLine("Please make a valid selection.");
                        }
                    }
                }
                catch
                {
                    string choiceUp = choice.ToUpper();
                    if (choiceUp == "R")
                    {
                        ifR = true;
                        venueItems = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please make a valid selection.");
                    }

                }
            }

            if (ifR)
            {
                Run();
            }

            else if (venueItems)
            {
                DisplayVenueDetails(userVenue);
            }

        }

        public void DisplayVenueDetails(Venue userVenue)
        {
            VenueAccess va = new VenueAccess(connectionString);
            VenueDetails venueInfo = va.Details(userVenue);

            Console.WriteLine(userVenue.Name);
            Console.WriteLine("Location: " + venueInfo.CityName + ", " + venueInfo.StateAbbreviation);
            Console.Write("Categories: ");
            if (venueInfo.Categories.Count == 0)
            {
                Console.WriteLine("No Category associated with this venue.");
            }
            else
            {
                for (int i = 0; i < venueInfo.Categories.Count; i++)
                {
                    if (i == venueInfo.Categories.Count - 1)
                    {
                        Console.WriteLine(venueInfo.Categories[i]);
                    }
                    else
                    {
                        Console.Write(venueInfo.Categories[i] + ", ");
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine(userVenue.Description);
            Console.WriteLine();

            int pick = 0;
            bool done = false;
            while (!done)
            {
                Console.WriteLine("What would you like to do next?");
                Console.WriteLine("1) View Spaces");
                Console.WriteLine("2) Search for reservation availability");
                Console.WriteLine("R) Return to previous screen");

                string choice = Console.ReadLine();
                string choiceUp = choice.ToUpper();

                switch (choiceUp)
                {
                    case "1":
                        done = true;
                        pick = 1;
                        break;
                    case "2":
                        done = true;
                        pick = 2;
                        break;
                    case "R":
                        done = true;
                        pick = 3;
                        break;
                    default:
                        Console.WriteLine("Please input a valid selection.");
                        break;
                }

            }
            if (pick == 1)
            {
                ViewSpaces(userVenue);
            }
            else if (pick == 2)
            {
                ReservationSearch(userVenue, true);
            }
            else if (pick == 3)
            {
                DisplayVenueItems();
            }
        }

        public void ViewSpaces(Venue userVenue)
        {
            VenueAccess va = new VenueAccess(connectionString);
            List<VenueSpace> spaceList = new List<VenueSpace>();
            Console.WriteLine(userVenue.Name);
            Console.WriteLine();
            Console.WriteLine("Name".PadLeft(7) + "Open".PadLeft(30) + "Close".PadLeft(11) + "Daily Rate".PadLeft(14) + "Max. Occupancy".PadLeft(20));

            spaceList = va.DisplayVenueSpace(userVenue);

            for (int i = 0; i < spaceList.Count; i++)
            {
                string dailyRate = spaceList[i].DailyRate.ToString();
                string maxOccupancy = spaceList[i].MaxOccupancy.ToString();
                Console.Write("#" + (i + 1) + " ");
                Console.WriteLine(spaceList[i].Name.PadRight(30) + spaceList[i].Open.PadRight(10) + spaceList[i].Close.PadRight(9) + "$" +
                    dailyRate.PadRight(15) + maxOccupancy);
            }
            Console.WriteLine();


            int pick = 0;
            bool done = false;
            while (!done)
            {
                Console.WriteLine("What would you like to do next?");
                Console.WriteLine("1) Reserve a Space");
                Console.WriteLine("R) Return to previous screen");

                string choice = Console.ReadLine();
                string choiceUp = choice.ToUpper();

                switch (choiceUp)
                {
                    case "1":
                        done = true;
                        pick = 1;
                        break;
                    case "R":
                        done = true;
                        pick = 2;
                        break;
                    default:
                        Console.WriteLine("Please input a valid selection.");
                        break;
                }

            }
            if (pick == 1)
            {
                ReservationSearch(userVenue, false);
            }
            else if (pick == 2)
            {
                DisplayVenueDetails(userVenue);
            }

        }

        public void ReservationSearch(Venue userVenue, bool spaceSearch)
        {
            string startDate = "";
            string endDate = "";
            int peopleAmtNum = 0;
            bool reserveSpace = false;
            bool search = false;
            bool searchComplete = false;
            HashSet<VenueSpace> top5Spaces = new HashSet<VenueSpace>();
            while (!searchComplete)
            {
                VenueAccess va = new VenueAccess(connectionString);
                Console.WriteLine("What day does your event start? (yyyy-mm-dd)");
                startDate = Console.ReadLine();

                Console.WriteLine("What day does your event end? (yyyy-mm-dd)");
                endDate = Console.ReadLine();

                Console.WriteLine("How many people will be in attendance? (Numbers only)");
                string peopleAmt = Console.ReadLine();
                peopleAmtNum = int.Parse(peopleAmt);

                Console.WriteLine();
                Console.WriteLine("Here are the open spaces we found:");
                Console.WriteLine();
                Console.WriteLine("Name".PadRight(30) + "Daily Price");

                List<Reservation> searchResults = va.SpaceReservationSearch(userVenue.Name, startDate, endDate);
                top5Spaces = va.DisplayTop5(searchResults, userVenue, peopleAmtNum);

                if (top5Spaces.Count == 0)
                {
                    Console.WriteLine("Sorry, there are no available spaces.");
                }
                else
                {
                    foreach (VenueSpace item in top5Spaces)
                    {
                        Console.WriteLine(item.Name.PadRight(30) + " " + item.DailyRate);
                    }
                }

                Console.WriteLine();
                if (spaceSearch)
                {

                    bool decision = false;
                    while (!decision)
                    {

                        Console.WriteLine("Would you like to reserve a space? Y/N");
                        string reserve = Console.ReadLine();
                        string reserveUpper = reserve.ToUpper();
                        if (reserveUpper == "Y")
                        {
                            decision = true;
                            reserveSpace = true;
                        }
                        else if (reserveUpper == "N")
                        {
                            bool loop = false;
                            while (!loop)
                            {

                                Console.WriteLine("Would you like to search again? Y/N");
                                string searchAgain = Console.ReadLine();
                                string searchAgainCapitol = searchAgain.ToUpper();

                                if (searchAgainCapitol == "N")
                                {
                                    decision = true;
                                    search = true;
                                    searchComplete = true;
                                    loop = true;
                                }
                                else if (searchAgainCapitol == "Y")
                                {
                                    decision = true;
                                    loop = true;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid selection.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid selection.");
                        }
                    }
                }
                else
                {
                    searchComplete = true;
                    reserveSpace = true;
                }

            }

            if (search)
            {
                DisplayVenueDetails(userVenue);
            }
            if (reserveSpace)
            {
                ReserveSpace(userVenue, top5Spaces, peopleAmtNum, startDate, endDate);
            }

        }

        public void ReserveSpace(Venue userVenue, HashSet<VenueSpace> venueSpaces, int peopleAmt, string startDate, string endDate)
        {
            VenueAccess va = new VenueAccess(connectionString);

            DateTime start = Convert.ToDateTime(startDate);
            DateTime end = Convert.ToDateTime(endDate);

            int diff = (end.Date - start.Date).Days;



            bool done = false;
            while (!done)
            {

                Console.WriteLine("Which Space would you like to reserve?");
                string choice = Console.ReadLine();


                Console.WriteLine("Who is this reservation for?");

                string reservationName = Console.ReadLine();

                foreach (VenueSpace item in venueSpaces)
                {
                    if (item.Name == choice)
                    {
                        va.AddReservation(item.SpaceId, peopleAmt, startDate, endDate, reservationName);

                        Random generator = new Random();
                        int randomNumber = generator.Next(10000000, 99999999);
                        Console.WriteLine("Thanks for submitting your reservation! The details for your event are listed below:");
                        Console.WriteLine();
                        Console.WriteLine("Confirmation #: " + randomNumber);
                        Console.WriteLine("Venue: " + userVenue.Name);
                        Console.WriteLine("Space: " + item.Name);
                        Console.WriteLine("Reserved For: " + reservationName);
                        Console.WriteLine("Attendees: " + peopleAmt);
                        Console.WriteLine("Arrival Date: " + startDate);
                        Console.WriteLine("Depart Date: " + endDate);
                        Console.WriteLine("Total Cost: " + (item.DailyRate * diff));
                        done = true;
                    }
                }
                if (!done)
                {
                    Console.WriteLine("please make a valid selection. Check your spelling.");
                }
            }
                Console.WriteLine("Press enter to return to the main menu.");
                Console.ReadLine();
                Console.Clear();
                Run();


        }
    }
}
