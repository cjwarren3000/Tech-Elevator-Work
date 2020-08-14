using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Elephant : FarmAnimal, ISingAbout
    {
        public Elephant() : base("ELEPHANT")
        {

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

        public override string MakeSoundOnce()
        {
            return "TRUMPET";
        }

        public override string MakeSoundTwice()
        {
            return "<accent type=\"Brit-ish\">TRUMPAT</accent>";
        }
    }
}
