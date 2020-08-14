﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace HTTP_Web_Services_GET_lecture
{
    class UserInterface
    {
         readonly string API_URL = "http://localhost:3001/";
         readonly RestClient client = new RestClient();

        public  void Run()
        {
            Console.WriteLine("Welcome to Online Hotels! Please make a selection:");
            MenuSelection();
        }

        private  void MenuSelection()
        {
            int menuSelection = -1;
            while (menuSelection != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Menu:");
                Console.WriteLine("1: List Hotels");
                Console.WriteLine("2: List Reviews");
                Console.WriteLine("3: Show Details for Hotel ID 1");
                Console.WriteLine("4: List Reviews for Hotel ID 1");
                Console.WriteLine("5: List Hotels with star rating 3");
                Console.WriteLine("6: Public API Query");
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("Invalid input. Only input a number.");
                }
                else if (menuSelection == 1)
                {
                    PrintHotels(GetHotels());
                }
                else if (menuSelection == 2)
                {
                    PrintReviews(GetReviews());
                }
                else if (menuSelection == 3)
                {
                    PrintHotel(GetDetailsForHotel(1));
                }
                else if (menuSelection == 4)
                {
                    PrintReviews(GetReviewsForHotel(1));
                }
                else if (menuSelection == 5)
                {
                    PrintHotels(GetHotelsWithStarRating(3));
                }
                else if (menuSelection == 6)
                {
                    PrintCity(GetPublicAPIQuery());
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
            }
        }

        //API methods:

        private  List<Hotel> GetHotels()
        {
            RestRequest request = new RestRequest(API_URL + "hotels");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            return response.Data;
        }

        private  List<Review> GetReviews()
        {
            RestRequest request = new RestRequest(API_URL + "reviews");
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);
            return response.Data;
        }

        private  Hotel GetDetailsForHotel(int hotelId)
        {
            RestRequest request = new RestRequest(API_URL + "hotels/" + hotelId);
            IRestResponse<Hotel> response = client.Get<Hotel>(request);
            if (response.Data == null)
            {
                response.Data = new Hotel();
            }
            return response.Data;
        }

        private  List<Review> GetReviewsForHotel(int hotelId)
        {
            RestRequest request = new RestRequest(API_URL + "hotels/" + hotelId + "/reviews");
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);
            return response.Data;
        }

        private  List<Hotel> GetHotelsWithStarRating(int starRating)
        {
            RestRequest request = new RestRequest(API_URL + "hotels?stars=" + starRating);
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            return response.Data;
        }

        private  City GetPublicAPIQuery()
        {
            RestRequest request = new RestRequest("https://api.teleport.org/api/cities/geonameid:5128581/");
            IRestResponse<City> response = client.Get<City>(request);
            return response.Data;
        }


        //Print methods:

        private  void PrintHotels(List<Hotel> hotels)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotels");
            Console.WriteLine("--------------------------------------------");
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine(hotel.Id + ": " + hotel.Name);
            }
        }

        private  void PrintHotel(Hotel hotel)
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

        private  void PrintReviews(List<Review> reviews)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Review Details");
            Console.WriteLine("--------------------------------------------");
            foreach (Review review in reviews)
            {
                Console.WriteLine(" Hotel ID: " + review.HotelID);
                Console.WriteLine(" Title: " + review.Title);
                Console.WriteLine(" Review: " + review.ReviewText);
                Console.WriteLine(" Author: " + review.Author);
                Console.WriteLine(" Stars: " + review.Stars);
                Console.WriteLine("---");
            }
        }

        private  void PrintCity(City city)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("City Details");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Full Name: " + city.Full_name);
            Console.WriteLine(" Geoname Id: " + city.Geoname_id);
        }
    }
}
