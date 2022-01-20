using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWars.Model
{
    public class Grid
    {
        public int Width { get; }
        public int Height { get; }

        public Grid(int width, int height)
        {
            if (width < 1)
                throw new ArgumentOutOfRangeException(nameof(width));

            if (height < 1)
                throw new ArgumentOutOfRangeException(nameof(height));

            Height = height;
            Width = width;
        }
    }
}
