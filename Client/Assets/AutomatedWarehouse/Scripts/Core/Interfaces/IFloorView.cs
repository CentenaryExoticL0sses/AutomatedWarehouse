using UnityEngine;

namespace AutomatedWarehouse.Core.Interfaces
{
    public interface IFloorView
    {
        public void GenerateView(int width, int length);

        public void DestroyView();
    }
}