using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars
{
    public class Rover
    {
        private Coordinate simCoordinate; // simulation variables
        private Utility.Direction simDirection;
        public Coordinate currentCoordinate { get; set; }
        public Utility.Direction currentDirection { get; set; }
        public Area area { get; set; }
        public Rover(Area a, Coordinate c, Utility.Direction d)
        {
            if(a != null && c != null)
            {
                currentCoordinate = new Coordinate(c.X, c.Y);
                area = a;
                simDirection = currentDirection = d;
                simCoordinate = new Coordinate(currentCoordinate.X, currentCoordinate.Y);
            }
            
        } 
        private void TurnRight()
        {
            switch (simDirection)
            {
                case Utility.Direction.N:
                    simDirection = Utility.Direction.E;
                    break;
                case Utility.Direction.E:
                    simDirection = Utility.Direction.S;
                    break;
                case Utility.Direction.S:
                    simDirection = Utility.Direction.W;
                    break;
                case Utility.Direction.W:
                    simDirection = Utility.Direction.N;
                    break;
            }
        }
        private void TurnLeft()
        {
            switch (simDirection)
            {
                case Utility.Direction.N:
                    simDirection = Utility.Direction.W;
                    break;
                case Utility.Direction.E:
                    simDirection = Utility.Direction.N;
                    break;
                case Utility.Direction.S:
                    simDirection = Utility.Direction.E;
                    break;
                case Utility.Direction.W:
                    simDirection = Utility.Direction.S;
                    break;
            }
        }
        private void Move()
        {
            switch (simDirection)
            {
                case Utility.Direction.N:
                    simCoordinate.Y += 1;
                    break;
                case Utility.Direction.E:
                    simCoordinate.X += 1;
                    break;
                case Utility.Direction.S:
                    simCoordinate.Y -= 1;
                    break;
                case Utility.Direction.W:
                    simCoordinate.X -= 1;
                    break;
                default:
                    break;
            }
        }
        public void executeCommand(string strCommand)
        {
            simulateMove(strCommand);
            if(!isOutOfArea(simCoordinate))
            {
                currentCoordinate = simCoordinate;
                currentDirection = simDirection;
            }
            else
            {
                simCoordinate = currentCoordinate;
                simDirection = currentDirection;
                throw new Exception("Error in command, Final point will be out of area!");
            }
        }
        private void simulateMove(string strCommand)
        {
            char[] commandList = strCommand.ToCharArray();
            foreach (char item in commandList)
            {
                switch (item)
                {
                    case 'R':
                        TurnRight();
                        break;
                    case 'L':
                        TurnLeft();
                        break;
                    case 'M':
                        Move();
                        break;
                }
            }
        }
        private bool isOutOfArea(Coordinate newCoordinate)
        {
            return newCoordinate.X > area.topRight.X || newCoordinate.X < area.bottomLeft.X
                || newCoordinate.Y > area.topRight.Y || newCoordinate.Y < area.bottomLeft.Y
                ? true : false;
        }
    }
}
