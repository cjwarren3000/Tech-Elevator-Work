using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Farm
    {
        public Horse MrEd { get; }
        public Dragon Trogdor { get; } = null;
        public Tractor Tractor { get; }
        public Cat Whiskers { get; }

        public Elephant Dumbo { get; set; }

        private Elephant dumbosMom;
        public Elephant DumbosMom
        {
            get
            {
                return dumbosMom;
            }
            set
            {
                DumbosMom = value;
            }
        }

        public Farm()
        {
            MrEd = new Horse();
            Trogdor = new Dragon();
            Whiskers = new Cat();
            Dumbo = new Elephant();
            Tractor = new Tractor();

            Animals = new List<ISingAbout>();
            Animals.Add(MrEd);
            Animals.Add(Dumbo);
            Animals.Add(Trogdor);
            Animals.Add(Tractor);
            Animals.Add(new Horse());
            Animals.Add(Whiskers);
            //Animals.Add(null);

            /* Hidden for ease of illustrating testing concepts. Sorry, bird lovers
              
            Animals.Add(new Bird("Eagle"));
            Animals.Add(new Bird("Condor"));
            Animals.Add(new Bird("Pterodactyl"));
            Animals.Add(new Bird("Robot Chicken"));
            */

            Produce = new List<string>();
            Produce.Add("Carrots");
            Produce.Add("Potatoes");
            Produce.Add("Wheat");
            Produce.Add("Oranges");
            //Produce.Add("Java");
            Produce.Add("C# Code");
            //Produce.Add("Compiler Errors");
        }

        public List<ISingAbout> Animals { get; }

        public List<string> Produce { get; }
    }
}
