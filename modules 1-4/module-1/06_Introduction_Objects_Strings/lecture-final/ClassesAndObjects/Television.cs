using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndObjects
{
    public class Television
    {
        public int screenSize = 0;
        public string model = "";

        public void PrintInfo()
        {
            Console.WriteLine("Screen size is " + screenSize + " inches");
            Console.WriteLine("Model number is " + model);
        }
    }
}
