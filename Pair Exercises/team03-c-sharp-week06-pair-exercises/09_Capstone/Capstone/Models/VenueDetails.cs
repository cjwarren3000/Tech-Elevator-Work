using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class VenueDetails
    { 

        public string Name { get; set; }

        public string CityName { get; set; }

        public string StateAbbreviation { get; set; }

        public string Description { get; set; }

        public List<string> Categories { get; set; }

        public VenueDetails(string cityName, string name, string stateAbbreviation, string description, List<string> categories)
        {
            CityName = cityName;
            Name = name;
            StateAbbreviation = stateAbbreviation;
            Description = description;
            Categories = categories;
        }

        public VenueDetails()
        {

        }
    }
}
