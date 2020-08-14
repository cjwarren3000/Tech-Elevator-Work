using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractExercise
{
    public class TriangleWall : Wall
    {
        public TriangleWall(string name, string color, int baseLength, int height) : base(name, color)
        {
            Base = baseLength;
            Height = height;
        }

        public int Base
        {
            get;
        }

        public int Height
        {
            get;
        }

        public override int GetArea()
        {
            int totalAreaOfWall = (Base * Height) / 2;
            return totalAreaOfWall;
        }

        public override string ToString()
        {
            string nameBaseHeight = $"{Name} ({Base}x{Height}) triangle";
            return nameBaseHeight;
        }
    }
}
