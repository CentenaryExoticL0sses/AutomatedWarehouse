using System;

namespace AutomatedWarehouse.Infrastructure.API.DTO
{
    [Serializable]
    public struct PositionData
    {
        public int x;
        public int y;

        public override readonly string ToString()
        {
            return $"({x}, {y})";
        }
    }
}