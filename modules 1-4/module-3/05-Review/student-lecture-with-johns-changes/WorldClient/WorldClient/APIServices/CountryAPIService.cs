using System;
using System.Collections.Generic;
using RestSharp;
using System.Net;
using WorldClient.Models;

namespace WorldClient.APIServices
{ 
    public class CountryAPIService
    {
        private readonly string API_URL = "https://localhost:44349/country/";
        private readonly RestClient client = new RestClient();

        public List<Country> GetCountries()
        {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<List<Country>> response = client.Get<List<Country>>(request);
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

        public CountryDetail GetCountry(string country)
        {
            RestRequest request = new RestRequest(API_URL + country);
            IRestResponse<CountryDetail> response = client.Get<CountryDetail>(request);
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
    }
}


