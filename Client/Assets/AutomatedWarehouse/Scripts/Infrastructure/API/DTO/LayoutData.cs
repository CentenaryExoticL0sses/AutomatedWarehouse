using System;

namespace AutomatedWarehouse.Infrastructure.API.DTO
{
    [Serializable]
    public class LayoutData
    {
        public SizeData grid_size;
        public ShelfData[] shelves;

        public override string ToString()
        {
            return $"[Layout] Grid: {grid_size}, Shelves: {shelves?.Length ?? 0}";
        }
    }
}