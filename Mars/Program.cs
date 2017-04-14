using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility u = new Utility();
            Rover r1 = null;
            Rover r2;
            Area a = new Area();
            a.bottomLeft = new Coordinate(0, 0);
            Console.Write("Plateau:");
            try
            {
                string[] str = u.commandParser(Console.ReadLine(), Utility.commandType.AreaDimension);
                a.topRight = new Coordinate(int.Parse(str[0]), int.Parse(str[1]));

                try
                {
                    Console.Write("Rover1 Landing:");
                    str = u.commandParser(Console.ReadLine(), Utility.commandType.InitialPoint);
                    Coordinate r1InitPoint = new Coordinate(int.Parse(str[0]), int.Parse(str[1]));
                    r1 = new Rover(a, r1InitPoint, u.translateDirection(str[2]));
                    Console.Write("Rover1 Instructions:");
                    r1.executeCommand(u.commandParser(Console.ReadLine(), Utility.commandType.Instruction)[0]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write("Rover2 Landing:");
                str = u.commandParser(Console.ReadLine(), Utility.commandType.InitialPoint);
                Coordinate r2IinitPoint = new Coordinate(int.Parse(str[0]), int.Parse(str[1]));
                r2 = new Rover(a, r2IinitPoint, u.translateDirection(str[2]));
                Console.Write("Rover2 Instructions:");
                r2.executeCommand(u.commandParser(Console.ReadLine(), Utility.commandType.Instruction)[0]);

                Console.WriteLine(string.Format("Rover1:{0} {1} {2}",r1.currentCoordinate.X,r1.currentCoordinate.Y,r1.currentDirection));
                Console.WriteLine(string.Format("Rover2:{0} {1} {2}", r2.currentCoordinate.X, r2.currentCoordinate.Y, r2.currentDirection));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
