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
        Given a string, return a version where all the "x" have been removed.
        Except an "x" at the very start or end should not be removed.
        StringX("xxHxix") → "xHix"
        StringX("abxxxcd") → "abcd"
        StringX("xabxxxcdx") → "xabcdx"
        */
        public string StringX(string str)
        {
            if (str.Length > 2)
            {
                string firstLetter = str.Substring(0, 1);
                string middleLetters = str.Substring(1, str.Length - 2);
                string lastLetter = str.Substring(str.Length - 1, 1);

                string middleWithoutX = middleLetters.Replace("x", "");

                return firstLetter + middleWithoutX + lastLetter;
            }
            else
            {
                return str;
            }
        }
    }
}
