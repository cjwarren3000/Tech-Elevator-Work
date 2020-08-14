using RestSharp;
using System;
using System.Collections.Generic;
using WorldClient.Models;

namespace WorldClient.APIServices
{
    public class CityAPIService : LoginAPIServcie
    {
        private readonly string API_URL = "https://localhost:44349/city/";

        public List<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> cities = new List<City>();

            RestRequest request = new RestRequest(API_URL + countryCode);
            IRestResponse<List<City>> response = client.Get<List<City>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
        }

        public void AddCity(City city)
        {
            List<City> cities = new List<City>();

            RestRequest request = new RestRequest(API_URL);
            request.AddJsonBody(city);
            IRestResponse<City> response = client.Post<City>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
        }
    }
}
