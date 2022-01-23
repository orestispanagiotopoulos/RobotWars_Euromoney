using RobotWars.Model.Enums;

namespace RobotWars.Model
{
    public class Robot
    {
        public Robot(RobotState robotState)
        {
            RobotState = robotState;
        }
        public RobotState RobotState { get; private set; }

        public void Move(MoveTo move, Grid grid)
        {
            switch (move)
            {
                case MoveTo.L:
                    TurnLeft();
                    break;
                case MoveTo.R:
                    TurnRight();
                    break;
                case MoveTo.M:
                    MoveForward(grid);
                    break;
            }
        }

        private void TurnLeft()
        {
            RobotState.Direction = RobotState.Direction == Direction.N ? Direction.W : RobotState.Direction - 1;
        }

        private void TurnRight()
        {
            RobotState.Direction = RobotState.Direction == Direction.W ? Direction.N : RobotState.Direction + 1;
        }

        private void MoveForward(Grid grid)
        {
            var currentPosition = new Point(this.RobotState.Position.X, this.RobotState.Position.Y);

            switch(RobotState.Direction)
            {
                case Direction.N:
                    currentPosition.Y++;
                    TryMoveForward(grid, currentPosition);
                    break;
                case Direction.E:
                    currentPosition.X++;
                    TryMoveForward(grid, currentPosition);
                    break;
                case Direction.S:
                    currentPosition.Y--;
                    TryMoveForward(grid, currentPosition);
                    break;
                case Direction.W:
                    currentPosition.X--;
                    TryMoveForward(grid, currentPosition);
                    break;
            }
        }

        private void TryMoveForward(Grid grid, Point newPosition)
        {
            if (IsValidRobotPosition(newPosition, grid))
            {
                this.RobotState.Position = newPosition;
            }
            else
            {
                this.RobotState.PenaltyCount++;
            }
        }

        private bool IsValidRobotPosition(Point position, Grid grid)
        {
            return (position.X > -1 && position.X < grid.Width)
                && (position.Y > -1 && position.Y < grid.Height);
        }
    }
}
