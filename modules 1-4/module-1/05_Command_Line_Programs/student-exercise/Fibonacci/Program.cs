using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Please enter the Fibonacci number:");
                string userInput1 = Console.ReadLine();
                int limit = int.Parse(userInput1);

                Console.Write("0, 1");

                int oldest = 0;
                int old = 1;
                int fibSum = oldest + old;

                while (fibSum <= limit)
                {
                    Console.Write(", " + fibSum);
                    oldest = old;
                    old = fibSum;
                    fibSum = oldest + old;
                }
                Console.ReadLine();
                Console.WriteLine(" ");
                Console.WriteLine("Do you want to run the program again? Y/N");
                string quit = Console.ReadLine();
                string quitLowercase = quit.ToLower();

                if (quitLowercase == "no" || quitLowercase == "n")
                {
                    done = true;
                }




            }
            Console.WriteLine("Please hit ENTER to quit.");
            Console.ReadLine();


        }

    }
}


