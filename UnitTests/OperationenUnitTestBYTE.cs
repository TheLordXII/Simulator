using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    [TestClass]
    public class OperationenUnitTestBYTE
    {
        [TestMethod]
        public void TestOperationen_addwf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 1793;
            int programmcounter = 1;
            operation.w = 1;
            operation.Bank1[1] = 1;

            //Act
            int NeuerProgrammcounter = operation.addwf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(2, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }


    }
}
