using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Models;

namespace WorldServer.APIServices
{
    public class NewsAPIService
    {
        private readonly string API_START = @"http://newsapi.org/v2/everything?q=";
        private readonly string API_END = @"&apiKey=8bee824932ee4380af56611454a2a59f";
        private readonly RestClient client = new RestClient();

        public CountryDetail GetCountry(CountryDetail detail)
        {
            RestRequest request = new RestRequest(API_START + detail.Name + API_END);
            IRestResponse<List<News>> response = client.Get<List<News>>(request);
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
                try
                {


                    //add news stories
                    News news = response.Data[0];

                    foreach (Article article in news.Articles)
                    {
                        string temp = "";
                        temp = (article.Title != null) ? temp + article.Title : temp;
                        temp += " - ";

                        temp = (article.Author != null) ? temp + article.Author : temp;
                        temp += " - ";

                        int length = 200;
                        if (article.Content != null && article.Content.Length < 200)
                        {
                            length = article.Content.Length;
                        }

                        temp = (article.Content != null) ? temp + article.Content.Substring(0, length) : temp;

                        detail.Stories.Add(temp);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occurred - getting news stories " + ex.Message);
                }

                return detail;
            }
        }

    }
}
