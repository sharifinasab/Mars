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
    public class UtilityTests
    {
        [TestMethod()]
        [ExpectedException(typeof(Exception),
            "Direction is not correct!")]
        public void translateDirectionTest()
        {
            string direction = string.Empty;
            Utility u = new Utility();
            u.translateDirection(direction);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void commandParserTest()
        {
            string comm = "1 2 N";
            Utility u = new Utility();
            u.commandParser(comm, Utility.commandType.AreaDimension);
        }
    }
}