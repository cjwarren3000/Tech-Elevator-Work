using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public sealed class Horse : FarmAnimal, ISingAbout
    {
        public override string Name
        {
            get
            {
                return "HORSE";
            }
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
        protected override string MakeSound()
        {
            return "NEIGH";
        }
    }
}
