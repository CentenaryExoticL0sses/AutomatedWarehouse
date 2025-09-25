using System.Collections.Generic;
using System.Linq;
using AutomatedWarehouse.Core.Models;

namespace AutomatedWarehouse.Infrastructure.API.DTO
{
    public static class DTOExtensions
    {
        public static SizeModel ToDomain(this SizeData size)
        {
            return new(size.width, size.length);
        }

        public static PositionModel ToDomain(this PositionData position)
        {
            return new(position.x, position.y);
        }

        public static RobotModel ToDomain(this RobotData robot)
        {
            return new
            (
                robot.id,
                robot.position.ToDomain(),
                robot.status,
                robot.current_order_id
            );
        }

        public static IEnumerable<RobotModel> ToDomain(this IEnumerable<RobotData> robots)
        {
            return robots.Select(robot => robot.ToDomain());
        }

        public static ShelfModel ToDomain(this ShelfData shelf)
        {
            return new
            (
                shelf.id,
                shelf.position.ToDomain(),
                shelf.size.ToDomain()
            );
        }

        public static IEnumerable<ShelfModel> ToDomain(this IEnumerable<ShelfData> robots)
        {
            return robots.Select(robot => robot.ToDomain());
        }

        public static LayoutModel ToDomain(this LayoutData layoutData)
        {
            return new
            (
                layoutData.grid_size.ToDomain(), 
                layoutData.shelves.ToDomain()
            );
        }

        public static StateModel ToDomain(this StateData stateData)
        {
            return new(stateData.timestamp, stateData.robots.ToDomain());
        }

    }
}
