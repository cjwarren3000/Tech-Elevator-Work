using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Tractor : ISingAbout
    {
        public string Name
        {
            get
            {
                return "Tractor";
            }
        }

        public string MakeSoundOnce()
        {
            return "Vruuuuuum (sputter) / rumble";
        }

        public string MakeSoundTwice()
        {
            return "VROOOOOOOOOOOOOOOOOOOOOOM! (boom boom)";
        }
    }
}
