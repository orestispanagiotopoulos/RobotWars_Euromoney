using RobotWars.Extentions;
using RobotWars.Model;

namespace RobotWars.Service.Factory
{
    public class RobotFactory : IRobotFactory
    {
        public Robot CreateRobot(int intialX, int initialY, string direction)
        {
            return new Robot(new RobotState
            {
                Position = new Point(intialX, initialY),
                Direction = direction.GetDirection()
            });
        }
    }
}
