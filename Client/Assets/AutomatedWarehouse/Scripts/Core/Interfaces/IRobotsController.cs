using AutomatedWarehouse.Core.Models;
using System.Collections.Generic;

namespace AutomatedWarehouse.Core.Interfaces
{
    public interface IRobotsController
    {
        public void DisplayView(IEnumerable<RobotModel> shelves);

        public void HideView();
    }
}
