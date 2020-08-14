using System;
using System.Collections.Generic;
using System.Text;

namespace classes_and_objects
{
    public class Television
    {
        public int screenSize = 0;
        public string model = " ";
        public void PrintInfo()
        {
            Console.WriteLine("Screensize is: " + screenSize + " inches");
            Console.WriteLine("Model number is " + model);
        }
    }
}
