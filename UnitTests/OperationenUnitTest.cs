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
        public void TestOperationen_Push()
        {
            //Arrange
            Operationen operation = new Operationen();

            //Act
            operation.push(3);

            //Assert
            Assert.AreEqual(0, operation.stackindex);
            Assert.AreEqual(3, operation.stack[0]);
        }

        [TestMethod]
        public void TestOperationen_Pop()
        {
            //Arrange 
            Operationen operation = new Operationen();

            //Act
            operation.push(2);
            operation.push(3);
            operation.push(4);

            int ergebnis = operation.pop();

            //Assert
            Assert.AreEqual(1, operation.stackindex);
            Assert.AreEqual(4, ergebnis);
        }

        [TestMethod]
        public void TestOperationen_InitialisierungBaenke()
        {
            //Arrange
            Operationen operation = new Operationen();

            //Act
            operation.InitialisierungBaenke();

            //Assert
            Assert.AreEqual(0, operation.Bank1[0]);
            Assert.AreEqual(0, operation.Bank1[1]);
            Assert.AreEqual(0, operation.Bank1[2]);
            Assert.AreEqual(24, operation.Bank1[3]);
            Assert.AreEqual(0, operation.Bank1[4]);
            Assert.AreEqual(0, operation.Bank1[5]);
            Assert.AreEqual(0, operation.Bank1[6]);
            Assert.AreEqual(0, operation.Bank1[7]);
            Assert.AreEqual(0, operation.Bank1[8]);
            Assert.AreEqual(0, operation.Bank1[9]);
            Assert.AreEqual(0, operation.Bank1[10]);
            Assert.AreEqual(0, operation.Bank1[11]);

            Assert.AreEqual(0, operation.Bank1[128]);
            Assert.AreEqual(255, operation.Bank1[129]);
            Assert.AreEqual(0, operation.Bank1[130]);
            Assert.AreEqual(24, operation.Bank1[131]);
            Assert.AreEqual(0, operation.Bank1[132]);
            Assert.AreEqual(255, operation.Bank1[133]);
            Assert.AreEqual(255, operation.Bank1[134]);
            Assert.AreEqual(0, operation.Bank1[135]);
            Assert.AreEqual(0, operation.Bank1[136]);
            Assert.AreEqual(0, operation.Bank1[137]);
            Assert.AreEqual(0, operation.Bank1[138]);
        }

        [TestMethod]
        public void TestOperationen_ClearW()
        {
            //Arrange
            Operationen operation = new Operationen();

            //Act
            operation.clearW();

            //Assert
            Assert.AreEqual(0, operation.w);
        }

        [TestMethod]
        public void TestOperationen_ExtractRP0()
        {
            //Arrange
            Operationen operation = new Operationen();
            operation.Bank1[3] = 0b0001_1000;

            //Act
            int ergebnis = operation.ExtractRP0();

            //Assert
            Assert.AreEqual(16, ergebnis);
        }

        [TestMethod]
        public void TestOperationen_ChangeZ()
        {
            //Arrange
            Operationen operation = new Operationen();
            operation.Bank1[3] = 0b1111_1111;

            //Act
            operation.ChangeZ(1);

            //Assert
            Assert.AreEqual(251, operation.Bank1[3]);
        }

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
