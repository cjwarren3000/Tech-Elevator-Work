using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class KataFizzBuzz
    {

        public string FizzBuzz(int number)
        {
            string numberAsString = number.ToString();

            if(number >= 101 || number <= 0)
            {
                return "";
            }


            else if (number % 3 == 0 && number % 5 == 0 || 
                (numberAsString.Contains('3') && numberAsString.Contains('5')))
            {
                return "FizzBuzz.";
            }


            else if (number % 5 == 0 || numberAsString.Contains('5'))
            {
                return "Buzz.";
            }


            else if (number % 3 == 0 || numberAsString.Contains('3'))
            {
                return "Fizz.";
            }


            else if (number <= 100 || number >= 1)
            {
                return numberAsString;
            }


            return "";
        }
    }
}
