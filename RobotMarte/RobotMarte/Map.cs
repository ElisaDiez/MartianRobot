using System;
using System.Collections.Generic;
using System.Text;

namespace RobotMarte
{
    public static class Map
    {
        public static int GridX { get; set; }
        public static int GridY { get; set; }

        public static List<RobotPosition> LostRobots { get; set; } = new List<RobotPosition>();

        public static bool CheckLostPoints(RobotPosition robotPosition)
        {
            bool pointFound = false;

            foreach (RobotPosition position in LostRobots)
            {
                if (robotPosition.xValue == position.xValue &&
                    robotPosition.yValue == position.yValue)
                    
                    pointFound = true;
            }

            return pointFound;
        }

    }
}
