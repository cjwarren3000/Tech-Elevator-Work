using System;
using System.Collections.Generic;
using System.Text;

namespace InClass
{
    public class Car
    {
        private string make = "";
        //public string model = "";
        public int year = 0;

        public string Make
        {
            get
            {
                return make;
            }
             set
            {
                make = value;
            }
        }

        public string Model
        {
            get; set;
        }

        public bool IsStandard
        {
            get
            {
                return (make == "Honda" && Model == "Civic");
            }
        }


        public Car()
        {
        }

        public Car(string make, string model, int year)
        {
            this.make = make;
            Model = model;
            this.year = year;
        }

        public void Display()
        {
            Console.WriteLine("Make: " + make);
            Console.WriteLine("Model: " + Model);
            Console.WriteLine("Year: " + year);
            Console.WriteLine();
        }

        public override string ToString()
        {
            string result = "Make: " + make + "\n";
            result += "Model: " + Model + "\n";
            result += "Year: " + year  + "\n";
            return result;
        }

        public bool AreDoorsOpen()
        {
            return false;
        }

        public bool Equals(Car car)
        {
            if (car.Make == Make &&
                car.Model == Model &&
                car.year == year)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
