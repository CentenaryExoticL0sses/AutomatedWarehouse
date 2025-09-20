using System;

namespace AutomatedWarehouse.Infrastructure.API.DTO
{
    [Serializable]
    public struct SizeData
    {
        public int width;
        public int length;

        public override readonly string ToString()
        {
            return $"{width}x{length}";
        }
    }
}