using System;
using System.Collections.Generic;
using System.Text;

namespace RobotMarte
{
    public class RobotPosition
    {
        public int xValue { get; set; }
        public int yValue { get; set; }
        public Orientation orientation { get; set; }

        public RobotPosition()
        {
        }

        public RobotPosition(int x, int y, Orientation o)
        {
            xValue = x;
            yValue = y;
            orientation = o;
        }

    }
}
