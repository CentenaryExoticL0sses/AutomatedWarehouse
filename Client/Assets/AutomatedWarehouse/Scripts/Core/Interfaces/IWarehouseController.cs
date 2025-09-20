using AutomatedWarehouse.Infrastructure.API.DTO;

namespace AutomatedWarehouse.Core.Interfaces
{
    public interface IWarehouseController
    {
        public void BuildWarehouse(LayoutResponse layout);

        public void ClearWarehouse();
    }
}