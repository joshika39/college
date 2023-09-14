﻿using Labyrinth.BL.Base;
using Labyrinth.BL.Labyrinth;

namespace Labyrinth.BL.Impl.Base
{
    internal class Position2D : IPosition2D
    {

        public int X { get; }
        public int Y { get; }

        public Position2D(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
