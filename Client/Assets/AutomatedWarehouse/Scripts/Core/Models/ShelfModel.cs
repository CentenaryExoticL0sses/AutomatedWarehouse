using System;

namespace AutomatedWarehouse.Core.Models
{
    public class ShelfModel
    {
        public string Id;
        public PositionModel Position;
        public SizeModel Size;

        public ShelfModel
        (
            string id, 
            PositionModel position, 
            SizeModel size
        )
        {
            Id = id;
            Position = position;
            Size = size;
        }

        public override string ToString()
        {
            return $"[Shelf] Id: {Id}, Position: {Position}, Size: {Size}";
        }
    }
}