using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractExercise
{
    class SquareWall : RectangleWall
    {
        public SquareWall(string name, string color, int sideLength) : base(name, color, sideLength, sideLength)
        {

        }

        public override string ToString()
        {
            string nameSideLengthSquare = $"{Name} ({Length}x{Height}) square";
            return nameSideLengthSquare;
        }
    }
}
