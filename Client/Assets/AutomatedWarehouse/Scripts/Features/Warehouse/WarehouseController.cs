using AutomatedWarehouse.Core.Interfaces;
using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Features.Warehouse
{
    public class WarehouseController : IWarehouseController
    {
        private readonly IFloorView _floorView;
        private readonly IShelvesView _shelvesView;

        public WarehouseController(IFloorView floorView, IShelvesView shelvesView)
        {
            _floorView = floorView;
            _shelvesView = shelvesView;
        }

        public void BuildWarehouse(LayoutModel layout)
        {
            _floorView.GenerateView(layout.Size);
            _shelvesView.GenerateView(layout.Shelves);
        }

        public void ClearWarehouse()
        {
            _floorView.DestroyView();
            _shelvesView.DestroyView();
        }
    }
}