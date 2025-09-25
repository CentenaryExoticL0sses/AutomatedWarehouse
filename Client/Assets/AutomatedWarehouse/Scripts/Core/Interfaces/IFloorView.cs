using UnityEngine;
using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Core.Interfaces
{
    public interface IFloorView
    {
        public void DisplayView(SizeModel size);

        public void HideView();
    }
}