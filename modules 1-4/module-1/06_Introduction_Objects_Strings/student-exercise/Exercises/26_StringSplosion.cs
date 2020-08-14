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
         Given a non-empty string like "Code" return a string like "CCoCodCode".
         StringSplosion("Code") → "CCoCodCode"
         StringSplosion("abc") → "aababc"
         StringSplosion("ab") → "aab"
         */
        public string StringSplosion(string str)
        {
            string partialString = "";
            string partialString2 = "";
            string fullString = "";

            for (int i = 1; i <= str.Length; i ++)
            {
                partialString = str.Substring(0, i);
                partialString2 = fullString;
                fullString = partialString2 + partialString;
            }
            return fullString;
        }
    }
}
