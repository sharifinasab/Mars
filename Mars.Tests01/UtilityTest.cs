// <copyright file="UtilityTest.cs">Copyright ©  2017</copyright>

using System;
using Mars;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mars.Tests
{
    [TestClass]
    [PexClass(typeof(Utility))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class UtilityTest
    {

        [PexMethod]
        public Utility.Direction translateDirection([PexAssumeUnderTest]Utility target, string str)
        {
            Utility.Direction result = target.translateDirection(str);
            return result;
            // TODO: add assertions to method UtilityTest.translateDirection(Utility, String)
        }
    }
}
