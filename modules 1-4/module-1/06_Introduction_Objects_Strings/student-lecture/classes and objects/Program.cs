using System;

namespace classes_and_objects
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] dogCount = new int[4];


            Television /*classname*/ myTelevision /*objectname*/ = new /*creating a new instance of an object*/ Television() /*the type of object it is*/;
            myTelevision.model = "Sony";
            myTelevision.screenSize = 10;

            myTelevision.PrintInfo();

            Console.ReadLine();

            Television sebsTelevision = new Television();
            sebsTelevision.model = "tgs-2321ds";
            sebsTelevision.screenSize = 69;

            sebsTelevision.PrintInfo();
            Console.ReadLine();
        }
    }
}
