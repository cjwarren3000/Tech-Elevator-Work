using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public sealed class Cat : FarmAnimal
    {
        public int LivesLeft { get; set; } = 9;

        public override string Name
        {
            get
            {
                return "CAT (still kind of a jerk)";
            }
        }

        protected override string MakeSound()
        {
            return "Fine. Meow. Happy now?";
        }

        public override string MakeSoundTwice()
        {
            return "Actually, I'm no longer a jerk. Give me milk and scritches please.";
        }
    }
}
