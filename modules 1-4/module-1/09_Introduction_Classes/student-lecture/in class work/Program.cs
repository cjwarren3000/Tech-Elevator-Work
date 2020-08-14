using System;

namespace in_class_work
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();

            myCar.Make = "Honda";
            myCar.Model = "Civic";
            myCar.year = 2016;

            Car hisCar = new Car();

            hisCar.Make = "Subaru";
            hisCar.Model = "Impreza";
            hisCar.year = 2019;

            Car johnCar = new Car("Honda", "CR-V", 2010);

            myCar.Display();
            hisCar.Display();
            johnCar.Display();

            Console.ReadLine();

            if (myCar.Equals(johnCar))
            {
                Console.WriteLine("They are equal");
            }
        }
        
    }
}
