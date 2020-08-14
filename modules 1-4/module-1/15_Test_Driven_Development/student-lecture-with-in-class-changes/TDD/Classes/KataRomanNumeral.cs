using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Classes
{
    public class KataRomanNumeral
    {
       public string ConvertToRomanNumeral(int n)
        {
            string result = "";

            result += ConvertDigit(ref n, 1000, "M");
            result += ConvertDigit(ref n, 500, "D");
            result += ConvertDigit(ref n, 100, "C");
            result += ConvertDigit(ref n, 50, "L");
            result += ConvertDigit(ref n, 10, "X");
            result += ConvertDigit(ref n, 5, "V");
            result += ConvertDigit(ref n, 1, "I");

            result = result.Replace("LXXXX", "XC");
            result = result.Replace("XXXX", "XL");
            result = result.Replace("VIIII", "IX");
            result = result.Replace("IIII", "IV");

            return result;
        }

        private string ConvertDigit(ref int n, int target, string roman)
        {
            string result = "";
            while (n >= target)
            {
                result += roman;
                n -= target;
            }

            return result;
        }
    }
}
