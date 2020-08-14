using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class KataPrimeFactors
    {
       public List<int> Factorize(int n)
        {
            List<int> listOfPRimeFactors = new List<int>();
            int checkIfPrime = n;

            for (int i = 2; i < 10; i++)
            {
               while (checkIfPrime % i == 0)
               {
                        listOfPRimeFactors.Add(i);
                        checkIfPrime /= i;

               }
            }

            if (checkIfPrime == 1)
            {

            }
            else
            {
                listOfPRimeFactors.Add(checkIfPrime);
            }

            return listOfPRimeFactors;
        }
    }
}
