using System;

namespace command_line_input_exercises_pairs
{
    class Program
    {
        /*
        Write a command line program which prompts the user for the total bill, and the amount tendered. It should then display the change required.

        C:\Users> MakeChange

        Please enter the amount of the bill: 23.65
        Please enter the amount tendered: 100.00
        The change required is 76.35
        */
        static void Main(string[] args)
        {

            bool done = false;
            
            while (!done)
            {
                Console.WriteLine("Please enter the amount of the bill: (As a number) ");
                string userInput1 = (Console.ReadLine());
                double amountOfBill = double.Parse(userInput1);

                Console.WriteLine("Bill: " + amountOfBill);

                Console.WriteLine("Please enter the amount tendered: (As a number) ");
                string userInput2 = Console.ReadLine();
                double amountTendered = double.Parse(userInput2);

                Console.WriteLine("Amount Tendered: " + amountTendered);

                double amountChange = amountTendered - amountOfBill;
                Console.WriteLine("The change required is " + amountChange);

                Console.WriteLine("Do you have any other bills? Y/N");
                string userInput3 = Console.ReadLine();

                if (userInput3 == "No" || userInput3 == "N")
                {
                    done = true;
                }
            }
            Console.ReadLine();
        }
    }
}
