using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractExercise
{
    class RectangleWall : Wall
    {
        public RectangleWall (string name, string color, int length, int height) : base(name, color)
        {
            Length = length;
            Height = height;
        }

        public int Length
        {
            get;
        }

        public int Height
        {
            get;
        }

        public override int GetArea()
        {
            int totalAreaOfWall = Length * Height;
            return totalAreaOfWall;
        }

        public override string ToString()
        {
            string nameLengthHeight = $"{Name} ({Length}x{Height}) rectangle";
            return nameLengthHeight;
        }
    }
}
