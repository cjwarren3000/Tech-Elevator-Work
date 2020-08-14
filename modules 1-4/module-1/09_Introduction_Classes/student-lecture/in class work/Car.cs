using System;
using System.Collections.Generic;
using System.Text;

namespace in_class_work
{
    public class Car
    {
       private string make = "";
       //public string model = "";
       public int year = 0;

       public string Make //this is a property. It usually uses the name of
                          //the variable it represents. You usually set the 
                          //variable this is representing as private.
        {
            get //get must return the same value type as the property, often 
                //just the variable that is defined in the class.
            {
                return make;
            }
            set //often sets the value to the variable defined with the same name
                //as the property. Value is a keyword, and whenever the property
                //appears on the left side of an assignment statement, the value
                //it is assigned appears in the keyword value. 
            {
                make = value;
            }
        }

        public string Model //this is a shorthanded version of the previous
        {                  //property. it makes it so that you don't need
            get; set;      //an explicitly stated public or private variable
        }                  //it creates a hidden variable that it uses once
                           //compiled. If you want to do any sort of code
                           //during the get and the set, you HAVE to use the
                           //longhand version of the property. The shorthand
                           //doesn't allow you to change any code.

        public bool IsStandard // this is a derived property. It does not 
                               // have it's own variables that is set, it 
                               //calculates it's own stuff using other variables.
                               // an actual property has variables set within it.
                               //derived get's do not have a 'set' at all. they use the
                               //formula to return their value.
        {
            get
            {
                return (make == "honda" && Model == "civic");
            }
        }





        public Car() //this is a constructor. it has the same name as 
        {           //the class, and no return type (string, int, void, etc).
                    //the empty constructor is the default that will be there
        }           //if you do not make a constructor anywhere manually.
                    //if you make any constructors, you have to make an empty
                    //constructor, because it will not be created if you have
                    //made any constructors manually. You don't *need* an
                    //empty constructor if you don't want an empty one to be an
                    //option, but it will not be created by default.



        public Car(string make, string model, int year) //this is an explicit constructor, it
        {                               //tells you what to return when it
            this.make = make;           //gets the input after the ()
            Model = model;              
            this.year = year;           //the this keyword tells the code that
        }                               //it should be looking at the variables
                                        //up at the start of the class, instead
                                        //of the one in the constructor.


        public void Display() //this is the method signature. 
        {
            Console.WriteLine($"Make: {make}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Year: {year}");
            Console.WriteLine();
        }

        public override string ToString()
        {
            string result = $"Make: {make}";
            result = $"Model: {Model}";
            result = $"Year: {year}";
            return result;
        }

        public bool Equals(Car car)
        {
            if (car.Make == Make && car.Model == Model && car.year == year)
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

// overloading is the idea that we can use the same method name for mutiple
//methods
