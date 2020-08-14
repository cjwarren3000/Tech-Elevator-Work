using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public sealed class Elephant : FarmAnimal, ISingAbout
    {
        public override string Name
        {
            get
            {
                return "ELEPHANT";
            }
        }

        public int TrunkLength { get; set; }

        public int PeanutsEaten { get; set; }

        public void Stomp()
        {

        }

        public void StalkPoacher()
        {

        }

        public void Stampede()
        {

        }

        protected override string MakeSound()
        {
            return "TRUMPET";
        }
    }
}
