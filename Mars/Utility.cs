using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars
{
    public class Utility
    {
        public enum Direction
        {
            N,
            E,
            S,
            W
        }
        public enum commandType
        {
            AreaDimension,
            InitialPoint,
            Instruction
        }
        public string[] commandParser(string command, commandType comm)
        {
            string[] retValue = command.Split(' ');
            int n;

            switch (comm)
            {
                case commandType.AreaDimension:
                    if (retValue.Length != 2 || !int.TryParse(retValue[0], out n) || !int.TryParse(retValue[1], out n))
                        throw new Exception("Dimension is not correct!");
                    break;
                case commandType.InitialPoint:
                    if(retValue.Length != 3)
                        throw new Exception("Initial point is not correct!");
                    break;
                case commandType.Instruction:
                    if (retValue.Length != 1)
                        throw new Exception("Command is not correct!");
                    break;
            }
            return retValue;
        }
        public Direction translateDirection(string str)
        {
            Direction d;

            switch (str)
            {
                case "E":
                    d = Direction.E;
                    break;
                case "N":
                    d = Direction.N;
                    break;
                case "W":
                    d = Direction.W;
                    break;
                case "S":
                    d = Direction.S;
                    break;
                default:
                    throw new Exception("Direction is not correct!");
            }
            return d;
        }
    }
}
