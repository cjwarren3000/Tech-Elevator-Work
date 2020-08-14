using System;

namespace M1_05InClass
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;

            while (!done)
            {

                Console.WriteLine("Please enter your name.");
                string input = Console.ReadLine();

                Console.WriteLine("Hello, " + input);

                Console.WriteLine("How many dogs do you have?");
                input = Console.ReadLine();
                int dogCount = int.Parse(input);

                switch (dogCount)
                {
                    case 0:
                        Console.WriteLine("You don't have any dogs?");
                        break;
                    case 1:
                    case 2:
                        Console.WriteLine("You have just the right number of dogs.");
                        break;
                    case 3:
                        Console.WriteLine("You are buiding a pack");
                        break;
                    default:
                        Console.WriteLine("You have a pack");
                        break;
                }

                Console.WriteLine("If you added one dog, you would have " + (dogCount + 1));

                Console.WriteLine("Please enter your favorite quote");
                string quote = Console.ReadLine();
                string[] words = quote.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    Console.WriteLine(words[i]);
                }

                Console.WriteLine("Do you want to continue (Y/N)");
                string keepGoing = Console.ReadLine();

                if (keepGoing == "N")
                {
                    done = true;
                }

            }

            Console.ReadLine();

        }
    }
}
