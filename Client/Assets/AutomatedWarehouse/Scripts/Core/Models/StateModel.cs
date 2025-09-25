using System.Collections.Generic;

namespace AutomatedWarehouse.Core.Models
{
    public class StateModel
    {
        public string Timestamp;
        public List<RobotModel> Robots;

        public StateModel(string timestamp, IEnumerable<RobotModel> robots)
        {
            Timestamp = timestamp;
            Robots = new(robots);
        }

        public override string ToString()
        {
            return $"[State] Timestamp: {Timestamp}, Robots: {Robots?.Count ?? 0}";
        }
    }
}