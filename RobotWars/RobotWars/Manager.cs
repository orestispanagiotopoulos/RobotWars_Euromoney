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


        public void InitializeGrid(int width, int height)
        {
            _grid = new Grid(width, height);
        }

        public void InitializeRobot(int intialX, int initialY, string direction)
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
