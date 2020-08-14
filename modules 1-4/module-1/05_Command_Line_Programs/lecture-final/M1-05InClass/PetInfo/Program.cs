using System;

namespace PetInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;

            string[] petNames = new string[0];
            string petType = "";

            while (!done)
            {

                //Console.Clear();
                Console.WriteLine("1 for Pet type");
                Console.WriteLine("2 to Set number of pets");
                Console.WriteLine("3 Enter Pet names");
                Console.WriteLine("4 to Display Information");
                Console.WriteLine("Q to quit");

                string userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        Console.WriteLine("Please enter the type of pet (dog, cat, parrot, etc.)");
                        petType = Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("Please enter the number of pets.");
                        string petCount = Console.ReadLine();
                        int count = int.Parse(petCount);
                        petNames = new string[count];
                        break;

                    case "3":
                        Console.WriteLine("Please enter pet names");

                        for (int i = 0; i < petNames.Length; i++)
                        {
                            Console.WriteLine("Pet: " +(i+1));
                            petNames[i] = Console.ReadLine();
                        }
                        break;

                    case "4":
                        Console.WriteLine("Pet Type: " + petType);

                        for (int i = 0; i < petNames.Length; i++)
                        {
                            Console.WriteLine(petNames[i]);
                        }

                        break;

                    case "Q":
                    case "q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a correct value");
                        break;
                }
            }

            Console.WriteLine("Finished. Press ENTER to end");
            Console.ReadLine();
        }
    }
}
