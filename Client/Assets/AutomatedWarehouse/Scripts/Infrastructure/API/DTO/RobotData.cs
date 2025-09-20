using System;

namespace AutomatedWarehouse.Infrastructure.API.DTO
{
    [Serializable]
    public class RobotData
    {
        public string id;
        public PositionData position;
        public string status;
        public string current_order_id;

        public override string ToString()
        {
            return $"[Robot] Id: {id}, Position: {position}, Status: {status}, Order: {current_order_id ?? "none"}";
        }
    }
}