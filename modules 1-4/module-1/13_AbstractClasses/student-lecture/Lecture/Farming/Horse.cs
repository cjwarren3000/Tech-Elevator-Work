using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Horse : FarmAnimal, ISingAbout
    {
        /// <summary>
        /// Creates a new horse.
        /// </summary>
        /// <param name="name">The name which the horse goes by.</param>
        public Horse() : base("HORSE")
        {
        }

        public void Gallop()
        {
            // TODO: Implement me!
        }

        public int NumCarrotsEaten { get; set; }

        /// <summary>
        /// The single noise the horse makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeSoundOnce()
        {
            return "NEIGH";
        }

        /// <summary>
        /// The double noise the horse makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeSoundTwice()
        {
            return "NEIGH NEIGH";
        }
    }
}
