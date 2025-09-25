using System;

namespace AutomatedWarehouse.Core.Models
{
    public struct PositionModel
    {
        public int X;
        public int Y;

        public PositionModel(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override readonly string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}