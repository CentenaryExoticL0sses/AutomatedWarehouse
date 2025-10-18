using AutomatedWarehouse.Core.Interfaces;
using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Features.Warehouse
{
    public class WarehouseController : IWarehouseController
    {
        private readonly IFloorController _floorView;
        private readonly IShelvesController _shelvesView;
        private readonly IRobotsController _robotsView;

        public WarehouseController
        (
            IFloorController floorView,
            IShelvesController shelvesView,
            IRobotsController robotsView
        )
        {
            _floorView = floorView;
            _shelvesView = shelvesView;
            _robotsView = robotsView;
        }

        public void BuildWarehouse(LayoutModel layout)
        {
            _floorView.DisplayView(layout.Size);
            _shelvesView.DisplayView(layout.Shelves);
        }

        public void UpdateWarehouse(StateModel stateModel)
        {
            _robotsView.HideView();
            _robotsView.DisplayView(stateModel.Robots);
        }

        public void ClearWarehouse()
        {
            _floorView.HideView();
            _shelvesView.HideView();
            _robotsView.HideView();
        }
    }
}