using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Core.Interfaces
{
    public interface IFloorController
    {
        public void DisplayView(SizeModel size);

        public void HideView();
    }
}