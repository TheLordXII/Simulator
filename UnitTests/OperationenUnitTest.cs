using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simulator
{
    [TestClass]
    public class OperationenUnitTest
    {
        [TestMethod]
        public void TestOperationen_clrwdt()
        {
            //Arrange
            Operationen operation = new Operationen();
            
            int programmcounter = 1;

            //Act
            int returnwert = operation.clrwdt(programmcounter);

            //Assert
            Assert.AreEqual(1, returnwert);
            //Assert.AreEqual(3, returnwert); --> Seperater Test auf den Sonderfall nötig.
            Assert.AreEqual(0, operation.watchdog);
        }
    }
}
