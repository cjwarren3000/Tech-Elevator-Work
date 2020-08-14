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
         Given a string, return a new string made of every other char starting with the first, so "Hello" yields "Hlo".
         StringBits("Hello") → "Hlo"
         StringBits("Hi") → "H"
         StringBits("Heeololeo") → "Hello"
         */
        public string StringBits(string str)
        {
            string firstChar = "";
            string secondChar = "";
            string everyOtherChar = "";

            for (int i = 0; i < str.Length; i += 2)
            {
                firstChar = str.Substring(i, 1);
                secondChar = everyOtherChar;
                everyOtherChar = secondChar + firstChar;
            }
            return everyOtherChar;
        }
    }
}
