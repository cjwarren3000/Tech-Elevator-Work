using RestSharp;
using System;
using System.Collections.Generic;
using WorldClient.Models;

namespace WorldClient.APIServices
{
    class LanguageAPIService: LoginAPIServcie
    {
        private readonly string API_URL = "https://localhost:44349/language/";

        public List<Language> GetLanguages(string countryCode)
        {
            RestRequest request = new RestRequest(API_URL + countryCode);
            IRestResponse<List<Language>> response = client.Get<List<Language>>(request);
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
