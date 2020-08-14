using Lecture.Farming;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Stubs
{
    public static class AnimalHelpers
    {
        public static void SingAbout(this ISingAbout animal)
        {
            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");
            Console.WriteLine("And on his farm there was a " + animal.Name + " ee ay ee ay oh");
            Console.WriteLine("With a " + animal.MakeSoundTwice() + " here and a " + animal.MakeSoundTwice() + " there");
            Console.WriteLine("Here a " + animal.MakeSoundOnce() + ", there a " + animal.MakeSoundOnce() + " everywhere a " + animal.MakeSoundTwice());
            Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
            Console.WriteLine();
        }

    }

    public static class NiceGuy
    {
        public static void SingAbout(this ISingAbout animal)
        {
            // Be nice
        }
    }
}
