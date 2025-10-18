using System.Collections.Generic;
using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Core.Interfaces
{
    public interface IShelvesController
    {
        public void DisplayView(IEnumerable<ShelfModel> shelves);

        public void HideView();
    }
}