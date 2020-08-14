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
         Given a List of Integers, and an int value, return true if the
         int value appears two or more times in
         the list.
         FoundIntTwice( [5, 7, 9, 5, 11], 5 ) -> true
         FoundIntTwice( [6, 8, 10, 11, 13], 8 -> false
         FoundIntTwice( [9, 23, 44, 2, 88, 44], 44) -> true
         */
        public bool FoundIntTwice(List<int> integerList, int intToFind)
        {
            int numberOfTimesFound = 0;
            bool numberIsRepeated = false;
            foreach(int number in integerList)
            {
                if(number == intToFind)
                {
                    numberOfTimesFound++;
                }
                else
                {

                }
            }
            if(numberOfTimesFound >= 2)
            {
                numberIsRepeated = true;
            }
            else
            {

            }

            return numberIsRepeated;
        }

    }
}
