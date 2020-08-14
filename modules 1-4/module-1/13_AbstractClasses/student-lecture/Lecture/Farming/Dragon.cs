using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Dragon : FarmAnimal, ISingAbout, IFlyable
    {
        public Dragon() : base("DRAGON!!!")
        {

        }

        public int VillagersBurninated { get; set; }

        public void BreathFire()
        {

        }

        public void Fly()
        {

        }

        public override string MakeSoundOnce()
        {
            return "ROOOAAARRRRRRRR";
        }

        public override string MakeSoundTwice()
        {
            return "TROGDOOOOORRRRR";
        }
    }
}
