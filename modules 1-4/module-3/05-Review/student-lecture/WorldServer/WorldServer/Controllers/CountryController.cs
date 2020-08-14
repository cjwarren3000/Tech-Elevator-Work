using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldServer.APIServices;
using WorldServer.DAL;
using WorldServer.Models;

namespace WorldServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICityDAO cityDao;
        private ICountryDAO countryDao;
        private ILanguageDAO languageDao;

        public CountryController(ICityDAO cityDao, ICountryDAO countryDao, ILanguageDAO languageDao)
        {
            this.cityDao = cityDao;
            this.countryDao = countryDao;
            this.languageDao = languageDao;
        }

        [HttpGet]
        public List<Country> GetCountries()
        {
            List<Country> countries = countryDao.GetCountries();
            return countries;
        }

        [HttpGet("{countryCode}")]
        public CountryDetail GetCountry( string countryCode)
        {
            Country country = countryDao.GetCountry(countryCode);

            CountryDetail countryDetail = new CountryDetail(country);

            //get news
            NewsAPIService newsAPIService = new NewsAPIService();
            countryDetail = newsAPIService.GetCountry(countryDetail);

            return countryDetail;
        }
    }
}