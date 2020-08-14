using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldServer.DAL;
using WorldServer.Models;

namespace WorldServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private ICityDAO cityDAO;

        public CityController(ICityDAO cityDAO)
        {
            this.cityDAO = cityDAO;
        }

        [HttpGet("{countryCode}")]
        public List<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> cities = cityDAO.GetCitiesByCountryCode(countryCode);
            return cities;
        }

        [HttpPost]
        public ActionResult AddCity (City city)
        {
            bool result = cityDAO.AddCity(city);

            if (result)
            {
                return Created("", city);
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}