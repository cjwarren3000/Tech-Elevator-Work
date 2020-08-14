using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of int values, return a Dictionary<int, int> with
         * a key for each int, with the value the
         * number of times that int appears in the array.
         *
         * ** The lesser known cousin of the the classic WordCount **
         *
         * IntCount([1, 99, 63, 1, 55, 77, 63, 99, 63, 44]) → {1: 2, 44: 1, 55: 1, 63: 3, 77: 1, 99:2}
         * IntCount([107, 33, 107, 33, 33, 33, 106, 107]) → {33: 4, 106: 1, 107: 3}
         * IntCount([]) → {}
         *
         */
        public Dictionary<int, int> IntCount(int[] ints)
        {

            Dictionary<int, int> intCountDict = new Dictionary<int, int>();

            int[] intsTwo = ints;
            List<int> timesRepeated = new List<int>();

            foreach (int number in ints)
            {
                int repeated = 0;
                foreach (int integer in intsTwo)
                {
                    if (number == integer)
                    {
                        repeated++;
                    }

                }
                timesRepeated.Add(repeated);
            }

            int listLocation = -1;
            foreach (int number in ints)
            {
                listLocation++;

                if (intCountDict.ContainsKey(number))
                {

                }
                else
                {
                    intCountDict.Add(number, timesRepeated[listLocation]);

                }
            }
            
            return intCountDict;
        }
    }
}
            //line 26 sets up my dictionary for future use
            //line 28 adds a copy of the array to check against
            //line 29 makes a list that will hold all the repeated values
            //lines 31 - 43 check and record how many times a number is repeated
            //line 46 provides a starting point for pulling the 
            //repeated count from the list
            //lines 48 - 61 loop adds numbers and values to the dictionary, and
            //makes sure keys aren't used twice
