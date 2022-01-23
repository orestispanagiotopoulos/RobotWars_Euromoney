using RobotWars.Model.Enums;

namespace RobotWars.Model
{
    public class RobotState
    {
        public Point Position { get; set; }
        public Direction Direction { get; set; }
        public int PenaltyCount { get; set; } = 0;
    }
}
