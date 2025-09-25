using AutomatedWarehouse.Core.Interfaces;
using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Features.Warehouse
{
    public class WarehouseController : IWarehouseController
    {
        private readonly IFloorView _floorView;
        private readonly IShelvesView _shelvesView;
        private readonly IRobotsView _robotsView;

        public WarehouseController
        (
            IFloorView floorView, 
            IShelvesView shelvesView, 
            IRobotsView robotsView
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