using System;

namespace AutomatedWarehouse.Infrastructure.API.DTO
{
    [Serializable]
    public class StateData
    {
        public string timestamp;
        public RobotData[] robots;

        public override string ToString()
        {
            return $"[State] Timestamp: {timestamp}, Robots: {robots?.Length ?? 0}";
        }
    }
}