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

        [TestMethod]
        public void TestOperationen_andwf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 1281;
            int programmcounter = 1;
            operation.w = 0b0000_0001;
            operation.Bank1[1] = 0b1111_1111;

            //Act
            int NeuerProgrammcounter = operation.andwf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b0000_0001, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_clrf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 385;
            int programmcounter = 1;
            operation.Bank1[1] = 0b1111_1111;
            operation.Bank1[3] = 0b1111_1111;

            //Act
            int NeuerProgrammcounter = operation.clrf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b0000_0000, operation.Bank1[1]);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_clrw()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 256;
            int programmcounter = 1;
            operation.w = 0b1111_1111;

            //Act
            int NeuerProgrammcounter = operation.clrw(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b0000_0000, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_comf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 2305;
            int programmcounter = 1;
            operation.Bank1[1] = 0b1010_1010;


            //Act
            int NeuerProgrammcounter = operation.comf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b0101_0101, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_decf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 769;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0010;


            //Act
            int NeuerProgrammcounter = operation.decf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b0000_0001, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_decfsz()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 2817;
            int programmcounter = 1;
            operation.Bank1[129] = 0b0000_0010;
            operation.Bank1[3] = 0b1111_1111;


            //Act
            int NeuerProgrammcounter = operation.decfsz(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b0000_0001, operation.w);
            Assert.AreEqual(0b1111_1011, operation.Bank1[3]);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_incf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 2561;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0001;
            operation.Bank1[3] = 0b1111_1111;


            //Act
            int NeuerProgrammcounter = operation.incf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b0000_0010, operation.Bank1[1]);
            Assert.AreEqual(0b1111_1011, operation.Bank1[3]);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }
    }
}
