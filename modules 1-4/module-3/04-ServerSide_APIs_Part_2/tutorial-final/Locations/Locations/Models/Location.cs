using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locations.Models
{
    public class Location
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "The field Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The field City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The field State is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "The field Zip is required.")]
        [RegularExpression("^(?!00000)[0-9]{5,5}$", ErrorMessage = "The zip field does not look like a zipcode")]
        public string Zip { get; set; }

        //public int? Id { get; set; }
        //public string Name { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string Zip { get; set; }

        public Location(int? id, string name, string address, string city, string state, string zip)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
        }

        public bool IsValid
        {
            get
            {
                return true;
                //return Name != null && Address != null && City != null && State != null && Zip != null;
            }
        }
    }
}
