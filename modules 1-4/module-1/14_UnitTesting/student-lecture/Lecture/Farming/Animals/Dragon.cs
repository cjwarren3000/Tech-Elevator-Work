using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Dragon : FlyingFarmAnimal, ISingAbout
    {
        public override string Name
        {
            get
            {
                return "TROGDOR";
            }
        }

        public int VillagersBurninated { get; set; }

        public void BreathFire()
        {

        }

        public override string MakeSoundTwice()
        {
            return base.MakeSoundTwice();
        }

        protected override string MakeSound()
        {
            return "ROOOAAARRRRRRRR";
        }

        public override void PoopOnPedestrian()
        {
            Console.WriteLine("Ouch");
        }
    }
}
