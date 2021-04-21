using System;
using System.Collections.Generic;
using System.Text;

namespace RobotMarte
{
    public class MartianRobot
    {
        public MartianRobot(RobotPosition position)
        {
            CurrentPosition = position;

        }

        public string IsLost { get; private set; } = string.Empty;
        public RobotPosition CurrentPosition { get; private set; }

        public void TurnLeft()
        {
            switch (CurrentPosition.orientation)
            {
                case Orientation.N:
                    CurrentPosition.orientation = Orientation.W;
                    break;
                case Orientation.W:
                    CurrentPosition.orientation = Orientation.S;
                    break;
                case Orientation.S:
                    CurrentPosition.orientation = Orientation.E;
                    break;
                case Orientation.E:
                    CurrentPosition.orientation = Orientation.N;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (CurrentPosition.orientation)
            {
                case Orientation.N:
                    CurrentPosition.orientation = Orientation.E;
                    break;
                case Orientation.E:
                    CurrentPosition.orientation = Orientation.S;
                    break;
                case Orientation.S:
                    CurrentPosition.orientation = Orientation.W;
                    break;
                case Orientation.W:
                    CurrentPosition.orientation = Orientation.N;
                    break;
            }
        }

        public bool Fordward()
        {
            switch (CurrentPosition.orientation)
            {
                case Orientation.N:
                    CurrentPosition.yValue++;
                    if (CurrentPosition.yValue > Map.GridY && !Map.CheckLostPoints(CurrentPosition))
                    //Me salgo del mapa y anteriormente ningún robot se ha perdido por ese punto
                    {
                        Map.LostRobots.Add(new RobotPosition(CurrentPosition.xValue, CurrentPosition.yValue, CurrentPosition.orientation));
                        CurrentPosition.yValue--;
                        IsLost = "LOST";
                        return false;
                    }
                    if (Map.CheckLostPoints(CurrentPosition)) 
                        //Previamente un robot se ha perdido por ese punto por lo que ignoro la istruccion de F
                        CurrentPosition.yValue--;
                    break;
                case Orientation.W:
                    CurrentPosition.xValue--;
                    if (CurrentPosition.xValue < 0 && !Map.CheckLostPoints(CurrentPosition))
                    {
                        Map.LostRobots.Add(new RobotPosition(CurrentPosition.xValue, CurrentPosition.yValue, CurrentPosition.orientation));
                        CurrentPosition.xValue++;
                        IsLost = "LOST";
                        return false;
                    }
                    if (Map.CheckLostPoints(CurrentPosition))
                        //Previamente un robot se ha perdido por ese punto por lo que ignoro la istruccion de F
                        CurrentPosition.xValue++;
                    break;
                case Orientation.S:
                    CurrentPosition.yValue--;
                    if (CurrentPosition.yValue < 0 && !Map.CheckLostPoints(CurrentPosition))
                    {
                        Map.LostRobots.Add(new RobotPosition(CurrentPosition.xValue, CurrentPosition.yValue, CurrentPosition.orientation));
                        CurrentPosition.yValue++;
                        IsLost = "LOST";
                        return false;
                    }
                    if (Map.CheckLostPoints(CurrentPosition))
                        //Previamente un robot se ha perdido por ese punto por lo que ignoro la istruccion de F
                        CurrentPosition.yValue++;
                    break;
                case Orientation.E:
                    CurrentPosition.xValue++;
                    if (CurrentPosition.xValue > Map.GridX && !Map.CheckLostPoints(CurrentPosition))
                    {
                        Map.LostRobots.Add(new RobotPosition(CurrentPosition.xValue, CurrentPosition.yValue, CurrentPosition.orientation));
                        CurrentPosition.xValue--;
                        IsLost = "LOST";
                        return false;
                    }
                    if (Map.CheckLostPoints(CurrentPosition))
                        //Previamente un robot se ha perdido por ese punto por lo que ignoro la istruccion de F
                        CurrentPosition.xValue--;
                    break;
            }

            return true;
        }
    }
}
