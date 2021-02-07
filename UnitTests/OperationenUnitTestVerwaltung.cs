using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simulator
{
    [TestClass]
    public class OperationenUnitTestVerwaltung
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
        public void TestOperationen_ChangeZ()
        {
            //Arrange
            Operationen operation = new Operationen();
            operation.Bank1[3] = 0b1111_1111;
            operation.Bank1[131] = 0b1111_1111;

            //Act
            operation.ChangeZ(1);

            //Assert
            Assert.AreEqual(251, operation.Bank1[3]);
            Assert.AreEqual(251, operation.Bank1[131]);
        }

        [TestMethod]
        public void TestOperationen_ChangeC()
        {
            //Arrange
            Operationen operation = new Operationen();
            operation.Bank1[3] = 0b1111_1111;
            operation.Bank1[131] = 0b1111_1111;

            //Act
            operation.ChangeC(1);

            //Assert
            Assert.AreEqual(254, operation.Bank1[3]);
            Assert.AreEqual(254, operation.Bank1[131]);
        }

        [TestMethod]
        public void TestOperationen_ChangeCSUB()
        {
            //Arrange
            Operationen operation = new Operationen();
            operation.Bank1[3] = 0b1111_1111;
            operation.Bank1[131] = 0b1111_1111;

            //Act
            operation.ChangeCSUB(-1);

            //Assert
            Assert.AreEqual(254, operation.Bank1[3]);
            Assert.AreEqual(254, operation.Bank1[131]);

        }

        [TestMethod]
        public void TestOperationen_ChangeDCADD()
        {
            //Arrange
            Operationen operation = new Operationen();
            operation.Bank1[3] = 0b1111_1111;
            operation.Bank1[131] = 0b1111_1111;
            int data = 15;
            int w = 15;

            //Act
            operation.ChangeDCADD(w, data);

            //Assert
            Assert.AreEqual(255, operation.Bank1[3]);
            Assert.AreEqual(255, operation.Bank1[131]);
        }

        [TestMethod]
        public void TestOperationen_ChangeDCSUB()
        {
            //Arrange
            Operationen operation = new Operationen();
            operation.Bank1[3] = 0b1111_1111;
            operation.Bank1[131] = 0b1111_1111;
            int data = 31;
            int w = 15;

            //Act
            operation.ChangeDCSUB(w, data);

            //Assert
            Assert.AreEqual(255, operation.Bank1[3]);
            Assert.AreEqual(255, operation.Bank1[131]);
        }

        [TestMethod]
        public void TestOperationen_IsIndirect()
        {
            //Arrange
            Operationen operation = new Operationen();
            int cutvalue = 128;

            //Act
            int ergebnis = operation.isIndirect(cutvalue);

            //Assert
            Assert.AreEqual(0, ergebnis);
        }

        [TestMethod]
        public void TestOperationen_SyncFSR()
        {
            //Arrange
            Operationen operation = new Operationen();
            operation.Bank1[4] = 128;

            //Act
            operation.syncFSR();

            //Assert
            Assert.AreEqual(operation.Bank1[4], operation.Bank1[132]);
        }

        [TestMethod]
        public void TestOperationen_DestinationSet()
        {
            //Arrange
            Operationen operation = new Operationen();
            Management man = new Management();
            int cutvalue = 128;

            //Act
            bool result = man.DestinationSet(cutvalue);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestOperationen_Bank()
        {
            //Arrange
            Operationen operation = new Operationen();
            int cutvalue = 128;

            //Act
            int result = operation.Bank(cutvalue);

            //Assert
            Assert.AreEqual(128, result);
        }

        [TestMethod]
        public void TestOperationen_getPrescaler()
        {
            //Arrange
            Operationen operation = new Operationen();

            //Act
            int result = operation.getPrescaler();

            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestOperationen_WTDorTMR()
        {
            //Arrange
            Operationen operation = new Operationen();

            //Act
            bool result = operation.WTDorTMR();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestOperationen_calcTMR()
        {
            //Arrange
            Operationen operation = new Operationen();
            int programmcounter = 5;
            
            //Act
            int result = operation.calcTMR(programmcounter);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestOperationen_calcWTD()
        {
            //Arrange
            Operationen operation = new Operationen();


            //Act
            operation.calcWTD();

            //Assert
            Assert.AreEqual(1, operation.watchdog);
        }

        [TestMethod]
        public void TestOperationen_IsInterrupt()
        {
            //Arrange
            Operationen operation = new Operationen();
            operation.Bank1[11] = 0b1000_0000;


            //Act
            int res = operation.isInterrupt(3);

            //Assert
            Assert.AreEqual(3, res);
        }

        [TestMethod]
        public void TestOperationen_einzelnesBitAuslesen()
        {
            //Arrange
            Operationen operation = new Operationen();
            int stelle = 7;
            int cutvalue = 3;
            operation.Bank1[3] = 0b1111_1111; 


            //Act
            bool result = operation.einzelnesBitAuslesen(stelle, cutvalue);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestOperationen_ReadProgrammspeicherInhalt()
        {
            //Arrange
            Operationen operation = new Operationen();
            Management man = new Management();
            int programminhalt = 1793;

            //Act
            int result = man.ReadProgrammspeicherInhalt(programminhalt);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestOperationen_ReadProgrammspeicherInhalt7()
        {
            //Arrange
            Operationen operation = new Operationen();
            Management man = new Management();
            int programminhalt = 385;

            //Act
            int result = man.ReadProgrammspeicherInhalt7(programminhalt);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestOperationen_ReadProgrammspeicherInhalt3()
        {
            //Arrange
            Operationen operation = new Operationen();
            Management man = new Management();
            int programminhalt = 1793;

            //Act
            int result = man.ReadProgrammspeicherInhalt7(programminhalt);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestOperationen_ReadProgrammspeicherInhalt11()
        {
            //Arrange
            Operationen operation = new Operationen();
            Management man = new Management();
            int programminhalt = 1793;

            //Act
            int result = man.ReadProgrammspeicherInhalt7(programminhalt);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestOperationen_getFinalCut()
        {
            //Arrange
            Operationen operation = new Operationen();
            int programminhalt = 2817;

            //Act
            int result = operation.getFinalCut(programminhalt);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestOperationen_getDestination()
        {
            //Arrange
            Operationen operation = new Operationen();
            Management man = new Management();
            int programminhalt = 1793;

            //Act
            bool result = man.getDestination(programminhalt);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
