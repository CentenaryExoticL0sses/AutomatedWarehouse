using UnityEngine;
using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Core.Interfaces
{
    public interface IFloorView
    {
        public void GenerateView(SizeModel size);

        public void DestroyView();
    }
}