using System;
using System.Collections.Generic;

namespace AbstractExercise
{
    class Program
    {
        static void Main(string[] args)
        {

            RectangleWall newWall = new RectangleWall("Office", "Blue", 5, 10);

            Console.WriteLine(newWall.GetArea());

            Console.ReadLine();

        }
    }
}
