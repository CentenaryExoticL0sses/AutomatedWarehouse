using System.Collections.Generic;
using System.Linq;

namespace AutomatedWarehouse.Core.Models
{
    public class LayoutModel
    {
        public SizeModel Size;
        public List<ShelfModel> Shelves;

        public LayoutModel(SizeModel size, IEnumerable<ShelfModel> shelves)
        {
            Size = size;
            Shelves = new(shelves);
        }

        public override string ToString()
        {
            return $"[Layout] Grid: {Size}, Shelves: {Shelves?.Count ?? 0}";
        }
    }
}