using System;
using System.Collections.Generic;
namespace new_lecture_notes
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello world!");
            List<int> dogAges = new List<int>();

            dogAges.Add(3);
            dogAges.Add(4);

            foreach (int item in dogAges)
            {
                Console.WriteLine(item);

            }
            Console.ReadLine();
        }
    
    }
}
