using Lecture.Farming;
using System;
using System.Collections.Generic;

namespace Lecture
{
    class Program
    {
        private static void SingAbout(ISingAbout animal)
        {
            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");
            Console.WriteLine("And on his farm there was a " + animal.Name + " ee ay ee ay oh");
            Console.WriteLine("With a " + animal.MakeSoundTwice() + " here and a " + animal.MakeSoundTwice() + " there");
            Console.WriteLine("Here a " + animal.MakeSoundOnce() + ", there a " + animal.MakeSoundOnce() + " everywhere a " + animal.MakeSoundTwice());
            Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
            Console.WriteLine();
        }

        static IFlyable GetFlyingThing()
        {
            return new Dragon();
        }

        static void Main(string[] args)
        {
            //
            // OLD MACDONALD
            //

            List<ISingAbout> animals = new List<ISingAbout>();
            animals.Add(new Horse());
            animals.Add(new Elephant());
            animals.Add(new Dragon());
            animals.Add(new Tractor());

            FarmAnimal flyingThing = new Dragon();

            IFlyable trogdor = GetFlyingThing();


            foreach (ISingAbout item in animals)
            {
                SingAbout(item);
            }

            /*

            // Let's try singing about a Farm Animal
            FarmAnimal animal = new Horse();
            SingAbout(animal);

            // Horse horse = (Horse)animal;
            // horse.Gallop();

            Elephant elephant = new Elephant();
            SingAbout(elephant);

            Dragon dragon = new Dragon();
            SingAbout(dragon);
            // Same thing as: SingAbout(new Dragon());
            */

            // What if we wanted to sing about other things on the farm that were 
            // singable but not farm animals?
            // Can it be done? 

            Console.ReadLine();
        }
    }
}