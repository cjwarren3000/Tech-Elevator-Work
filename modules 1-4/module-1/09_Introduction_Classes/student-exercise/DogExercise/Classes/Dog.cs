using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    /**
    * This class represents a dog that can sleep, wake, and make a sound, so it's pretty much like most dogs,
    * with a few essential methods missing. Thankfully.
    */
    public class Dog
    {
        //constructor
        public Dog()
        {

        }

        private bool isSleeping = false;

        //properties
        public bool IsSleeping
        {
            get
            {
                return isSleeping;
            }
            private set
            {
                isSleeping = value;
            }
            
        }

        //methods
        public string MakeSound()
        {
            if (IsSleeping == true)
            {


                return "Zzzzz...";
            }
            else
            {
                return "Woof!";
            }
        }
         public void Sleep()
        {
            IsSleeping = true;
        }
        public void WakeUp()
        {
            IsSleeping = false;
        }


    }
}
