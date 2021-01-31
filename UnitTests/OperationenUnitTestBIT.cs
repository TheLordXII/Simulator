using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    [TestClass]
    public class OperationenUnitTestBIT
    {
        [TestMethod]
        public void TestOperationen_bcf()
        {
            //Arrange
            Operationen operation = new Operationen();
            int programminhalt = 4097;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0011;

            //Act
            int result = operation.bcf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(2, operation.Bank1[1]);
            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void TestOperationen_bsf()
        {
            //Arrange
            Operationen operation = new Operationen();
            int programminhalt = 5121;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0000;

            //Act
            int result = operation.bsf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(1, operation.Bank1[1]);
            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void TestOperationen_btfsc()
        {
            //Arrange
            Operationen operation = new Operationen();
            int programminhalt = 6145;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0000;

            //Act
            int result = operation.btfsc(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(2, result);

        }

        [TestMethod]
        public void TestOperationen_btfss()
        {
            //Arrange
            Operationen operation = new Operationen();
            int programminhalt = 6145;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0001;

            //Act
            int result = operation.btfss(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(2, result);

        }
    }
}
