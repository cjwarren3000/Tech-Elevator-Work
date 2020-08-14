using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Please enter a series of integer values (separated by spaces)");
                string input = Console.ReadLine();
                string[] conversionNumbers = input.Split(' ');
                for (int i = 0; i < conversionNumbers.Length; i++)
                {

                    int numbersInput = int.Parse(conversionNumbers[i]);
                    string binaryConversion = Convert.ToString(numbersInput, 2);

                    Console.WriteLine(numbersInput + " is " + binaryConversion + " in binary.");

                }
                Console.WriteLine("Do you want to convert any other numbers? Y/N");
                string finishConverting = Console.ReadLine();
                string finishConvertingLowercase = finishConverting.ToLower();
                if(finishConvertingLowercase == "no" || finishConvertingLowercase == "n")
                {

                    done = true;

                }
            }
            Console.WriteLine("Hit ENTER to exit.");
            Console.ReadLine();
           
        }
    }
}
