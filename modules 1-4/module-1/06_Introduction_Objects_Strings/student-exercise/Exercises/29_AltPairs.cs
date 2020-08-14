using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string, return a string made of the chars at 
         indexes 0,1, 4,5, 8,9 ... so "kittens" yields "kien".
         AltPairs("kitten") → "kien"
         AltPairs("Chocolate") → "Chole"
         AltPairs("CodingHorror") → "Congrr"
         */
        public string AltPairs(string str)
        {
            string firstPair = "";
            string secondPair = "";
            string otherPairs = "";
            for (int i = 0; i < str.Length; i += 4)
            {
                if (i + 1 < str.Length)
                {
                    firstPair = str.Substring(i, 2);
                    secondPair = otherPairs;
                    otherPairs = secondPair + firstPair;
                }
                else
                {
                    otherPairs = secondPair + firstPair + str.Substring(str.Length - 1, 1);
                }
            }
            return otherPairs;
        }
    }
}
