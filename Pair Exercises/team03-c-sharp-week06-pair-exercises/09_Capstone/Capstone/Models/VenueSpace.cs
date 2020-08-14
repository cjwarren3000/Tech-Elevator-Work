using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class VenueSpace
    {
        public string Name { get; set; }

        public string Open { get; set; }

        public string Close { get; set; }

        public decimal DailyRate { get; set; }

        public int MaxOccupancy { get; set; }

        public int SpaceId { get; set; }

        public VenueSpace()
        {

        }

        public VenueSpace(int spaceId, string name, string open, string close, decimal dailyRate, int maxOccupancy)
        {
            Name = name;
            Open = ConvertToMonth(open);
            Close = ConvertToMonth(close);
            DailyRate = Math.Round(dailyRate, 2);
            MaxOccupancy = maxOccupancy;
            SpaceId = spaceId;
        }

        public string ConvertToMonth(string num)
        {
            if (num == "")
            {
                return "";
            }

            int monthNum = int.Parse(num);

            if (monthNum <= 0) return "All Year";

            DateTime testDate = new DateTime(DateTime.Now.Year, monthNum, 1);
            return testDate.ToString("MMM");
        }

    }
}
