using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Tests
{
    [TestClass()]
    public class RoverTests
    {
        [TestMethod()]
        public void RoverTest()
        {
            Rover rover = new Rover((Area)null, (Coordinate)null, Utility.Direction.N);
            Assert.IsNotNull((object)rover);
            Assert.IsNull(rover.currentCoordinate);
            Assert.AreEqual<Utility.Direction>(Utility.Direction.N, rover.currentDirection);
            Assert.IsNull(rover.area);
        }

        [TestMethod()]
        public void executeCommandTest()
        {
            string comm = "MML";
            Area a = new Area();
            a.bottomLeft = new Coordinate(0, 0);
            a.topRight = new Coordinate(4, 4);
            Rover r = new Rover(a,new Coordinate(2,2),Utility.Direction.E);
            r.executeCommand(comm);
            Assert.AreEqual(4, r.currentCoordinate.X);
            Assert.AreEqual(2, r.currentCoordinate.Y);
            Assert.AreEqual(Utility.Direction.N, r.currentDirection);
        }
    }
}