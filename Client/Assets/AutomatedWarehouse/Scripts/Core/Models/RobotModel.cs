using System;

namespace AutomatedWarehouse.Core.Models
{
    public class RobotModel
    {
        public string Id;
        public PositionModel Position;
        public string Status;
        public string OrderId;

        public RobotModel
        (
            string id, 
            PositionModel position, 
            string status, 
            string orderId
        )
        {
            Id = id;
            Position = position;
            Status = status;
            OrderId = orderId;
        }

        public override string ToString()
        {
            return $"[Robot] Id: {Id}, Position: {Position}, Status: {Status}, Order: {OrderId ?? "none"}";
        }
    }
}