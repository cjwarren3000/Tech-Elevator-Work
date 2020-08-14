using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            while (!done) {
                Console.WriteLine("Please enter a length (using only numbers)");
                string userInput1 = Console.ReadLine();

                Console.WriteLine("Is this measurement in meters (m) or feet (f)?");
                string userInput2 = Console.ReadLine();

                double length = double.Parse(userInput1);
                string userInput2Lowercase = userInput2.ToLower();
                if (userInput2Lowercase == "m")
                {
                    Console.WriteLine(length + userInput2 + " is " + (length * 3.2808399) + "f");
                }
                else if (userInput2Lowercase == "f")
                {
                    Console.WriteLine(length + userInput2 + " is " + (length * 0.3048) + "m");
                }
                else
                {
                    Console.WriteLine("Please only use m for meters or f for feet.");
                }
                Console.WriteLine(" ");

                Console.WriteLine("Do you want to make more conversions? Y/N");
                string userQuit = Console.ReadLine();
                string yesNo = userQuit.ToLower();

                if (yesNo == "no" || yesNo == "n")
                {
                    done = true;
                }
            }

            Console.WriteLine("Please hit ENTER to exit");
            Console.ReadLine();
        }
    }
}
