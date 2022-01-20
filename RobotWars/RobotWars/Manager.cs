using RobotWars.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWars
{
    public class Manager
    {
        private const int GridWidth = 5;
        private const int GridHeight = 5;
        private Grid _grid;
        private Robot _robot;

        public RobotState ExecuteRobotMoves(int intialX, int initialY, string initialDirection, string robotInstuctions)
        {
            // TODO: Validate input
            InitialiseGrid(GridWidth, GridHeight);
            InitialiseRobot(intialX, initialY, initialDirection);
            return _robot.ExecuteMoveInstructions(robotInstuctions, _grid);
        }

        private void InitialiseGrid(int width, int height)
        {
            _grid = new Grid(width, height);
        }

        private void InitialiseRobot(int intialX, int initialY, string direction)
        {
            Enum.TryParse(direction, out Direction directionEnum);

            _robot = new Robot(new RobotState
            {
                Position =  new Point(intialX, initialY),
                Direction = directionEnum
            });
        }
    }
}
