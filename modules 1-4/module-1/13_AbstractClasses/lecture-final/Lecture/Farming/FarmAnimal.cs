using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    /// <summary>
    /// A base farm animal class.
    /// </summary>
    public abstract class FarmAnimal : ISingAbout
    {       
        /// <summary>
        /// The farm animal's name.
        /// </summary>
        public abstract string Name { get; }

        protected abstract string MakeSound();

        private void EatFood()
        {

        }

        /// <summary>
        /// The noise made when the farm animal makes its sound twice.
        /// </summary>
        /// <returns></returns>
        public virtual string MakeSoundTwice()
        {
            return MakeSoundOnce() + " " + MakeSoundOnce();
        }

        /// <summary>
        /// Determines whether or not the animal is asleep
        /// </summary>
        public bool IsAsleep { get; set; } = false;

        /*
        /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        protected FarmAnimal(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        protected FarmAnimal(string name, int favoriteNumber)
        {
            this.Name = name;
        }
        */

        public bool IsCaffenated { get; set; } = false;

        /// <summary>
        /// The noise made when the farm animal makes a sound.
        /// </summary>
        /// <returns></returns>
        public string MakeSoundOnce()
        {
            if (IsAsleep)
            {
                return "Zzzzzzzzzz";
            }

            if (IsCaffenated)
            {
                return "RED BULL???";
            }

            return MakeSound();
        }

        public void GiveScritches()
        {
            
        }

        public void Slaughter() // Kidding, PETA
        {

        }


    }
}
