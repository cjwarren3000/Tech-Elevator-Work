using System;
using System.Collections.Generic;

namespace HotelReservationsClient
{
    class ConsoleService
    {
        private static readonly APIService apiService = new APIService("https://localhost:44322/");

        public void Run()
        {
            Console.WriteLine("Welcome to Online Hotels! Please make a selection:");
            MenuSelection();
        }

        private void MenuSelection()
        {
            int menuSelection = -1;
            while (menuSelection != 0)
            {
                string logInOut = apiService.LoggedIn ? "Log out" : "Log in";

                Console.WriteLine("");
                Console.WriteLine("Menu:");
                Console.WriteLine("1: List Hotels");
                Console.WriteLine("2: List Reservations for Hotel");
                Console.WriteLine("3: Create new Reservation for Hotel");
                Console.WriteLine("4: Update existing Reservation for Hotel");
                Console.WriteLine("5: Delete Reservation");
                Console.WriteLine("6: " + logInOut);
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                try
                {


                    if (!int.TryParse(Console.ReadLine(), out menuSelection))
                    {
                        Console.WriteLine("Invalid input. Only input a number.");
                    }
                    else if (menuSelection == 1)
                    {
                        List<Hotel> hotels = apiService.GetHotels();
                        if (hotels != null && hotels.Count > 0)
                        {
                            PrintHotels(hotels);
                        }
                    }
                    else if (menuSelection == 2)
                    {
                        List<Hotel> hotels = apiService.GetHotels();
                        if (hotels != null && hotels.Count > 0)
                        {
                            int hotelId = PromptForHotelID(hotels, "list reservations");
                            if (hotelId != 0)
                            {
                                List<Reservation> reservations = apiService.GetReservations(hotelId);
                                if (reservations != null)
                                {
                                    PrintReservations(reservations, hotelId);
                                }
                            }
                        }
                    }
                    else if (menuSelection == 3)
                    {
                        // Create new reservation
                        string newReservationString = PromptForReservationData();
                        Reservation reservationToAdd = new Reservation(newReservationString);

                        if (reservationToAdd.IsValid)
                        {
                            Reservation addedReservation = apiService.AddReservation(reservationToAdd);
                            if (addedReservation != null)
                            {
                                Console.WriteLine("Reservation successfully added.");
                            }
                            else
                            {
                                Console.WriteLine("Reservation not added.");
                            }
                        }
                    }
                    else if (menuSelection == 4)
                    {
                        // Update an existing reservation
                        List<Reservation> reservations = apiService.GetReservations();
                        if (reservations != null)
                        {
                            int reservationId = PromptForReservationID(reservations, "update");
                            Reservation oldReservation = apiService.GetReservation(reservationId);
                            if (oldReservation != null)
                            {
                                string updReservationString = PromptForReservationData(oldReservation);
                                Reservation reservationToUpdate = new Reservation(updReservationString);

                                if (reservationToUpdate.IsValid)
                                {
                                    Reservation updatedReservation = apiService.UpdateReservation(reservationToUpdate);
                                    if (updatedReservation != null)
                                    {
                                        Console.WriteLine("Reservation successfully updated.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Reservation not updated.");
                                    }
                                }
                            }
                        }
                    }
                    else if (menuSelection == 5)
                    {
                        // Delete reservation
                        List<Reservation> reservations = apiService.GetReservations();
                        if (reservations != null)
                        {
                            int reservationId = PromptForReservationID(reservations, "delete");
                            apiService.DeleteReservation(reservationId);
                        }
                    }
                    else if (menuSelection == 6)
                    {
                        if (apiService.LoggedIn)
                        {
                            apiService.Logout();
                            Console.WriteLine("You are now logged out");
                        }
                        else
                        {
                            Console.Write("Please enter username: ");
                            string username = Console.ReadLine();
                            Console.Write("Please enter password: ");
                            string password = Console.ReadLine();
                            var login = apiService.Login(username, password);
                            if (login)
                            {
                                Console.WriteLine("You are now logged in");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex.Message);
                    Console.WriteLine();
                }
            }
        }


        //Print methods

        private void PrintHotels(List<Hotel> hotels)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotels");
            Console.WriteLine("--------------------------------------------");
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine(hotel.Id + ": " + hotel.Name);
            }
        }

        private void PrintHotel(Hotel hotel)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotel Details");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Id: " + hotel.Id);
            Console.WriteLine(" Name: " + hotel.Name);
            Console.WriteLine(" Stars: " + hotel.Stars);
            Console.WriteLine(" Rooms Available: " + hotel.RoomsAvailable);
            Console.WriteLine(" Cover Image: " + hotel.CoverImage);
        }

        private void PrintReservations(List<Reservation> reservations, int hotelId = -1)
        {
            string msg = hotelId == -1 ? "All Reservations" : "Reservations for hotel: " + hotelId;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(msg);
            Console.WriteLine("--------------------------------------------");
            if (reservations.Count > 0)
            {
                foreach (Reservation reservation in reservations)
                {
                    PrintReservationDetails(reservation);
                }
            }
            else
            {
                Console.WriteLine("There are no reservations for hotel: " + hotelId);
            }
        }

        private void PrintReservationDetails(Reservation reservation)
        {
            Console.WriteLine(" Id: " + reservation.id);
            Console.WriteLine(" Hotel ID: " + reservation.hotelID);
            Console.WriteLine(" Name: " + reservation.FullName);
            Console.WriteLine(" Check-in Date: " + reservation.CheckinDate);
            Console.WriteLine(" Check-out Date: " + reservation.CheckoutDate);
            Console.WriteLine(" Guests: " + reservation.Guests);
            Console.WriteLine("");
        }



        //Prompt methods

        private int PromptForHotelID(List<Hotel> hotels, string action)
        {
            PrintHotels(hotels);
            Console.WriteLine("");
            Console.Write("Please enter a hotel ID to " + action + ": ");
            if (!int.TryParse(Console.ReadLine(), out int hotelId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }
            else
            {
                return hotelId;
            }
        }

        private int PromptForReservationID(List<Reservation> reservations, string action)
        {
            PrintReservations(reservations);
            Console.WriteLine("");
            Console.Write("Please enter a reservation ID to " + action + ": ");
            if (!int.TryParse(Console.ReadLine(), out int reservationId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }
            else
            {
                return reservationId;
            }
        }

        private string PromptForReservationData(Reservation reservation = null)
        {
            string reservationString;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Enter reservation data as a comma separated list containing:");
            Console.WriteLine("Hotel ID, Full Name, Checkin Date, Checkout Date, Number of Guests");
            if (reservation != null)
            {
                PrintReservationDetails(reservation);
            }
            else
            {
                Console.WriteLine("Example: 1, John Smith, 10/10/2020, 10/14/2020, 2");
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("");
            reservationString = Console.ReadLine();
            if (reservation != null && reservation.id.HasValue)
            {
                reservationString += "," + reservation.id.Value;
            }
            return reservationString;
        }

    }
}
