using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public abstract class FlyingFarmAnimal : FarmAnimal, IFlyable
    {
        public FlyingFarmAnimal()
        {

        }

        public FlyingFarmAnimal(int maxAltitude)
        {
            MaximumAltitude = maxAltitude;
        }

        public abstract void PoopOnPedestrian();

        public void Fly()
        {
            // Lots and lots of aerodynamic code...
        }

        public int Wingspan { get; set; }

        public int MaximumAltitude { get; set; }
    }

    public class Bird : FlyingFarmAnimal
    {
        public Bird(string species, int maxAltitude) : base(maxAltitude)
        {
            this.Name = species;
        }

        public Bird(string species) : base(10000)
        {

        }

        public override string Name
        {
            get;
        }

        protected override string MakeSound()
        {
            return "Caw caw";
        }

        public override void PoopOnPedestrian()
        {
            Console.WriteLine("Splat");
        }

        public static Bird CreatePterodactyl()
        {
            return new Bird("Pterodactyl");
        }
    }
}
