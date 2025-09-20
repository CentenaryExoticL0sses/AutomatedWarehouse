using System;

namespace AutomatedWarehouse.Infrastructure.API.DTO
{
    [Serializable]
    public class ShelfData
    {
        public string id;
        public PositionData position;
        public SizeData size;

        public override string ToString()
        {
            return $"[Shelf] Id: {id}, Position: {position}, Size: {size}";
        }
    }
}