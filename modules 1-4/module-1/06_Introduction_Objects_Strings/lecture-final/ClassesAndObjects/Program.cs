using System;

namespace ClassesAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dogAges = new int[4];

            Television myTelevision = new Television();

            myTelevision.model = "Sony";
            myTelevision.screenSize = 10;

            myTelevision.PrintInfo();

            Television lisasTelevision = new Television();
            lisasTelevision.model = "Sony";
            lisasTelevision.screenSize = 56;
            lisasTelevision.PrintInfo();


            Console.ReadLine();
        }
    }
}
