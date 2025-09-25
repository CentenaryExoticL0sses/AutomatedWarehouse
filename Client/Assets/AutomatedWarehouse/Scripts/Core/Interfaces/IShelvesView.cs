using System.Collections.Generic;
using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Core.Interfaces
{
    public interface IShelvesView
    {
        public void DisplayView(IEnumerable<ShelfModel> shelves);

        public void HideView();
    }
}