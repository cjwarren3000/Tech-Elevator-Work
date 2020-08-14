using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldServer.APIServices;
using WorldServer.DAL;
using WorldServer.Models;
using System.Web;

namespace WorldServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryDAO countryDAO;

        public CountryController(ICountryDAO countryDAO)
        {
            this.countryDAO = countryDAO;
        }

        [AllowAnonymous]
        [HttpGet]
        public List<Country> GetCountries()
        {
            //owner?
            var user = User.Identity.Name;

            List<Country> countries = countryDAO.GetCountries();
            return countries;
        }

        [Authorize]
        [HttpGet("{countryCode}")]
        public CountryDetail GetCountry(string countryCode)
        {
            //owner?
            // https://docs.microsoft.com/en-us/dotnet/api/system.web.httpcontext.user?view=netframework-4.8
            // https://docs.microsoft.com/en-us/dotnet/api/system.security.claims.claim?view=netcore-3.1

            var user = User.Identity.Name;
            int id = -1;

            foreach (var claim in User.Claims)
            {
                if (claim.Type == "sub")
                {
                    id = int.Parse(claim.Value);
                }
            }

            System.Diagnostics.Debug.WriteLine("".PadRight(20,'-') + " from GetCounty " + "".PadRight(20, '-'));
            System.Diagnostics.Debug.WriteLine("User: " + user);
            System.Diagnostics.Debug.WriteLine("User id: " + id);

            Country country = countryDAO.GetCountry(countryCode);

            CountryDetail countryDetail = new CountryDetail(country);

            //get news
            NewsAPIService newsAPIService = new NewsAPIService();
            countryDetail = newsAPIService.GetCountry(countryDetail);

            return countryDetail;
        }
    }
}