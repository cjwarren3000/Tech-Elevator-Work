using Lecture.Farming;
using Lecture.Stubs;
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

        static void Main(string[] args)
        {
            Farm farm = new Farm();

            for (int i = 0; i < farm.Animals.Count; i++)
            {
                SingAbout(farm.Animals[i]);
            }

            foreach (ISingAbout item in farm.Animals)
            {
                SingAbout(item);
            }

            Console.ReadLine();
        }
    }
}