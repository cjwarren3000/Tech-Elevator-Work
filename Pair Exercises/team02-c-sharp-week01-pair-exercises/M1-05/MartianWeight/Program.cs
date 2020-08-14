using System;

namespace MartianWeight
{
    /*
    In case you've ever pondered how much you weight on Mars, here's the calculation:
    Wm = We* 0.378
    where 'Wm' is the weight on Mars, and 'We' is the weight on Earth

    Write a command line program which accepts a series of Earth weights from the user  
    and displays each Earth weight as itself, and its Martian equivalent.


    C:\Users> MartianWeight  
    Enter a series of Earth weights (space-separated): 98 235 185

    98 lbs.on Earth, is 37 lbs.on Mars.
    235 lbs.on Earth, is 88 lbs.on Mars.
    185 lbs.on Earth, is 69 lbs.on Mars. 
    */
    class Program
    {
        static void Main(string[] args)
        {

            bool done = false;
            while (!done)
            {
                Console.WriteLine("Enter a series of Earth weights in pounds (separated by a space).");
                string userInput1 = Console.ReadLine();

                string[] earthWeights = userInput1.Split(' ');
                for(int i = 0; i < earthWeights.Length; i++)
                {
                    int parsedWeights = int.Parse(earthWeights[i]);
                    double marsWeights = parsedWeights * 0.378;

                    Console.WriteLine(parsedWeights + " lbs. on Earth is " + marsWeights + " lbs. on Mars");
                }
                Console.WriteLine(" ");
                Console.WriteLine("Do you have more weights to convert? Y/N");
                string quit = Console.ReadLine();
                if (quit == "n" || quit == "N" || quit == "no" || quit == "No")
                {
                    done = true;
                }
            }
            Console.WriteLine("Press ENTER to quit");
            Console.ReadLine();

        }
    }
}
