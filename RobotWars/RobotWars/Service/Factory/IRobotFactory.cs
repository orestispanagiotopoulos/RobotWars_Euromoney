using RobotWars.Model;

namespace RobotWars.Service.Factory
{
    public interface IRobotFactory
    {
        Robot CreateRobot(int intialX, int initialY, string direction);
    }
}
