using UnityEngine;
using AutomatedWarehouse.Core.Interfaces;
using AutomatedWarehouse.Infrastructure.API.DTO;

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

        public void BuildWarehouse(LayoutResponse layout)
        {
            _floorView.GenerateView(layout.grid_size.width, layout.grid_size.length);
            _shelvesView.GenerateView(layout.shelves);
        }

        public void ClearWarehouse()
        {
            _floorView.DestroyView();
            _shelvesView.DestroyView();
        }
    }
}