using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class RobotDinosaurPoliceOfficer : FlyingFarmAnimal
    {
        public override string Name
        {
            get
            {
                return "RoboCoptor";
            }
        }

        protected override string MakeSound()
        {
            base.GiveScritches();

            return "Beep Boop Roar. I am ze law";
        }

        public override void PoopOnPedestrian()
        {
            // Best not to think about this one...
        }
    }
}
