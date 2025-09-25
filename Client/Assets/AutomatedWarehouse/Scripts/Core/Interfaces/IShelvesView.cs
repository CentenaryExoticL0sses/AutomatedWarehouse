using System.Collections.Generic;
using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Core.Interfaces
{
    public interface IShelvesView
    {
        public void GenerateView(IEnumerable<ShelfModel> shelves);

        public void DestroyView();
    }
}