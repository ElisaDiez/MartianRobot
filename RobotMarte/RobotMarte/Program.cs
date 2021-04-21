using System;

namespace RobotMarte
{
    class Program
    {
        static void Main(string[] args)
        {
            const string EXIT = "EXIT";
            string inputX = string.Empty;
            string inputY = string.Empty;
            int gridX = 0;
            int gridY = 0;
            RobotPosition robotInitialPoistion = new RobotPosition();

            Console.WriteLine("Welcome to Martian Robot App\r");
            Console.WriteLine("Type 'EXIT' to end ------------------------\n");

            #region VALIDATIONGRID

            Console.WriteLine("Please, enter the upper-right dimensions (integer positive number) of the rectangular grid, and then press Enter:");
            Console.Write("X Value: ");

            inputX = Console.ReadLine();

            while (!int.TryParse(inputX, out gridX) || gridX <= 0 || gridX > 50)
            {
                Console.Write("This is not valid input. Please enter a positive integer value lower than 50: ");
                inputX = Console.ReadLine();
            }

            Console.Write("Y Value: ");

            inputY = Console.ReadLine();

            while (!int.TryParse(inputY, out gridY) || gridY <= 0 || gridY > 50)
            {
                Console.Write("This is not valid input. Please enter a positive integer value lower than 50: ");
                inputY = Console.ReadLine();
            }

            Map.GridX = gridX;
            Map.GridY = gridY;

            #endregion

            while (true) //mientras no se escriba la palabra EXIT
            {
                Console.Write("Please enter robot position (ej. 2 3 N): ");

                string robotPositionInstruction = Console.ReadLine().ToUpper();

                if (robotPositionInstruction != EXIT)
                {

                    while (!setRobotPosition(robotPositionInstruction, robotInitialPoistion))
                    {
                        Console.Write("This is not valid input. Please enter robot pisition (ej. 2 3 N): ");
                        robotPositionInstruction = Console.ReadLine().ToUpper();
                    }

                    MartianRobot robot = new MartianRobot(robotInitialPoistion);

                    Console.Write("Please, enter the instruction command sequence: ");

                    string instructionList = Console.ReadLine().ToUpper();

                    if (instructionList != EXIT)
                    {
                        var instructionArray = instructionList.ToUpper().ToCharArray();
                        bool exitForeach = false;

                        foreach (char instruction in instructionArray)
                        {

                            switch (instruction)
                            {
                                //Move Forward
                                case 'F':
                                    if (!robot.Fordward())
                                        exitForeach = true;
                                    break;
                                // Turn Left
                                case 'L':
                                    robot.TurnLeft();
                                    break;
                                // Turn Right
                                case 'R':
                                    robot.TurnRight();
                                    break;
                                default:
                                    Console.WriteLine("Command {0} not recognized. Only L, R and F is allowed. Command ignored.", instruction);
                                    break;
                            }

                            if (exitForeach) break;

                        }

                        Console.WriteLine("Posición final: {0} {1} {2} {3}", robot.CurrentPosition.xValue, robot.CurrentPosition.yValue, robot.CurrentPosition.orientation, robot.IsLost);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private static bool setRobotPosition(string positionInstruction, RobotPosition robotInitialPoistion)
        {
            int intResult = 0;
            bool result = true;

            string [] paramsInstruction = positionInstruction.Split(" ");

            //Cada instrucción se compone de 3 partes
            if (paramsInstruction.Length == 3)
            {
                if (int.TryParse(paramsInstruction[0], out intResult) && intResult >= 0 && intResult <= 50)
                    robotInitialPoistion.xValue = intResult;
                else
                    result = false;

                if (int.TryParse(paramsInstruction[1].ToString(), out intResult) && intResult >= 0 && intResult <= 50)
                    robotInitialPoistion.yValue = intResult;
                else
                    result = false;

                if (Enum.IsDefined(typeof(Orientation), paramsInstruction[2]))
                    robotInitialPoistion.orientation = (Orientation) Enum.Parse(typeof(Orientation), paramsInstruction[2]);
                else
                    result = false;
            }
            else
                result = false;

            return result;
        }
    }
}
