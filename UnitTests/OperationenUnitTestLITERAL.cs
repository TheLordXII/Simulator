using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    [TestClass]
    public class OperationenUnitTestLITERAL
    {
        [TestMethod]
        public void TestOperationen_addlw()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 15873;
            int programmcounter = 1;
            operation.w = 1;
            operation.Bank1[1] = 1;

            //Act
            int NeuerProgrammcounter = operation.addlw(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(2, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_andlw()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 14593;
            int programmcounter = 1;
            operation.w = 0b1010_1011;

            //Act
            int NeuerProgrammcounter = operation.andlw(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(1, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_call()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 8194;
            int programmcounter = 3;

            //Act
            int NeuerProgrammcounter = operation.call(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(1, NeuerProgrammcounter);
            Assert.AreEqual(3, operation.stack[0]);
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

        [TestMethod]
        public void TestOperationen_goto()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 10242;
            int programmcounter = 3;

            //Act
            int NeuerProgrammcounter = operation.Goto(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_iorlw()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 14337;
            int programmcounter = 1;
            operation.w = 0b1010_1010;

            //Act
            int NeuerProgrammcounter = operation.iorlw(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b1010_1011, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_movlw()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 12289;
            int programmcounter = 1;
            operation.w = 0;

            //Act
            int NeuerProgrammcounter = operation.iorlw(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(1, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_retfie()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 9;
            int programmcounter = 1;
            operation.Bank1[11] = 128;
            operation.push(3);

            //Act
            int NeuerProgrammcounter = operation.retfie(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(3, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_retlw()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 13313;
            int programmcounter = 1;
            operation.push(3);

            //Act
            int NeuerProgrammcounter = operation.retlw(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(1, operation.w);
            Assert.AreEqual(3, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_RETURN()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 8;
            int programmcounter = 1;
            operation.push(3);

            //Act
            int NeuerProgrammcounter = operation.RETURN(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(3, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_sleep()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 99;
            int programmcounter = 1;

            //Act
            int NeuerProgrammcounter = operation.sleep(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_sublw()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 15363;
            int programmcounter = 1;
            operation.w = 1;

            //Act
            int NeuerProgrammcounter = operation.sublw(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(2, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_xorlw()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 14849;
            int programmcounter = 1;
            operation.w = 0b0000_0000;

            //Act
            int NeuerProgrammcounter = operation.sublw(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(1, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }
    }
}
