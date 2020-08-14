using System;
using System.Collections.Generic;
using System.Text;
using WorldServer.Models;

namespace WorldServer.DAL
{
    public interface ICountryDAO
    {
        List<Country> GetCountries();
        List<Country> GetCountries(string continent);
        Country GetCountry(string countryCode);
    }
}
