using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Core.Interfaces
{
    public interface IWarehouseController
    {
        public void BuildWarehouse(LayoutModel layout);

        public void UpdateWarehouse(StateModel state);

        public void ClearWarehouse();
    }
}