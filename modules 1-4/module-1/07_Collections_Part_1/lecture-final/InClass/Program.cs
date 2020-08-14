using System;
using System.Collections.Generic;

namespace InClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<int> dogAges = new List<int>();

            dogAges.Add(3);
            dogAges.Add(4);

            dogAges.Reverse();

            foreach(int item in dogAges)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }
    }
}
