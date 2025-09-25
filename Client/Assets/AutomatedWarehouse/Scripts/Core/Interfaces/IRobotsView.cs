using AutomatedWarehouse.Core.Models;
using System.Collections.Generic;
using UnityEngine;

namespace AutomatedWarehouse.Core.Interfaces
{
    public interface IRobotsView
    {
        public void DisplayView(IEnumerable<RobotModel> shelves);

        public void HideView();
    }
}
