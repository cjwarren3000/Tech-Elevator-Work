using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    public class Company
    {
        //constructors
        public Company()
        {

        }

        //properties
        public string Name
        {
            get; set;
        }

        public int NumberOfEmployees
        {
            get; set;
        }

        public decimal Revenue
        {
            get; set;
        }

        public decimal Expenses
        {
            get; set;
        }

        //methods
        public string GetCompanySize()
        {
            if (NumberOfEmployees < 50)
            {
                return "small";
            }
            else if (NumberOfEmployees >= 50 && NumberOfEmployees <= 250)
            {
                return "medium";
            }
            else
            {
                return "large";
            }
        }

        public decimal GetProfit()
        {
            return Revenue - Expenses;
        }
    }
}
