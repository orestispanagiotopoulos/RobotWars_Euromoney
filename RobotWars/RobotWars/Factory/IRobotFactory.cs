using RobotWars.Model;

namespace RobotWars.Factory
{
    public interface IRobotFactory
    {
        Robot CreateRobot(int intialX, int initialY, string direction);
    }
}
