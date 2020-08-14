using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Please enter the temperature (using only numbers)");
                string userInput1 = Console.ReadLine();
                double temperature = double.Parse(userInput1);
                

                Console.WriteLine("Is this temperature in Celsius (C) or Fahrenheit (F)?");
                string userInput2 = Console.ReadLine();
                string userInput2Lowercase = userInput2.ToLower();
                if (userInput2Lowercase == "c")
                {
                    Console.WriteLine(temperature + userInput2 + " is " + (temperature * 1.8 + 32 ) + "F");
                }
                else if (userInput2Lowercase == "f")
                {
                    Console.WriteLine(temperature + userInput2 + " is " + ((temperature - 32) / 1.8) + "C");
                }
                else
                {
                    Console.WriteLine("Please only use C for Celsius or F for Fahrenheit.");
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
