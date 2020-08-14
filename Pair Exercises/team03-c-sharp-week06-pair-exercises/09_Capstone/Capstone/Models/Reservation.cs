using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Reservation
    {
        public Reservation()
        {

        }
        
        public Reservation(string name, int numberOfAttendees, DateTime startDate, DateTime endDate, string reservedFor, int venueId)
        {
            Name = name;
            NumberOfAttendees = numberOfAttendees;
            StartDate = startDate;
            EndDate = endDate;
            ReservedFor = reservedFor;
            VenueId = venueId;
        }

        public string Name { get; set; }

        public int NumberOfAttendees { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ReservedFor { get; set; }

        public int VenueId { get; set; }

        
    }
}
