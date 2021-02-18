using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Simulator.Models.Commands;
using Simulator.Models;
using Moq;

namespace Simulator
{
    [TestClass]
    public class UnitTestLiteralCommands
    {
        [TestMethod]
        public void Test_ADDLW()
        {
            //Arrange 
            Mock<Memory> memoryMock = new Mock<Memory>();

            memoryMock.SetupGet(m => m.W).Returns(5);

            LiteralCommands LComs = new LiteralCommands(memoryMock.Object);
            short literal = 5;

            //Act
            LComs.ADDLW(literal);

            //Assert
            Assert.AreEqual(10, memoryMock.Object.W);
        }
    }
}
