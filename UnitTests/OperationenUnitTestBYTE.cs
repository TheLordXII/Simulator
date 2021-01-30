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

        [TestMethod]
        public void TestOperationen_incfsz()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 3841;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0001;
            operation.Bank1[3] = 0b1111_1111;


            //Act
            int NeuerProgrammcounter = operation.incfsz(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b0000_0010, operation.Bank1[1]);
            Assert.AreEqual(0b1111_1011, operation.Bank1[3]);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_iorwf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 1025;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0001;
            operation.w = 0b1111_1110;
            operation.Bank1[3] = 0b1111_1111;


            //Act
            int NeuerProgrammcounter = operation.iorwf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b1111_1110, operation.w);
            Assert.AreEqual(0b1111_1011, operation.Bank1[3]);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_movf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 2049;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0001;
            operation.w = 0b1111_1110;


            //Act
            int NeuerProgrammcounter = operation.movf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b0000_0001, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_movwf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 129;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0001;
            operation.w = 0;


            //Act
            int NeuerProgrammcounter = operation.movwf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(1, operation.Bank1[1]);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_nop()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 0;
            int programmcounter = 1;

            //Act
            int NeuerProgrammcounter = operation.nop(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_rlf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 3329;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0001;
            operation.w = 0;
            int c = 0;


            //Act
            int NeuerProgrammcounter = operation.rlf(programminhalt, c, programmcounter);

            //Assert
            Assert.AreEqual(0b0000_0010, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_rrf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 3073;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0010;
            operation.w = 0;
            int c = 1;


            //Act
            int NeuerProgrammcounter = operation.rrf(programminhalt, c, programmcounter);

            //Assert
            Assert.AreEqual(0b1000_0001, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_subwf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 513;
            int programmcounter = 1;
            operation.Bank1[1] = 0b0000_0011;
            operation.Bank1[3] = 0b1111_1100;
            operation.w = 1;


            //Act
            int NeuerProgrammcounter = operation.subwf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b1111_1111, operation.w);
            Assert.AreEqual(0b1111_1000, operation.Bank1[3]);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_swapf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 3585;
            int programmcounter = 1;
            operation.Bank1[1] = 0b1111_0000;
            operation.w = 1;


            //Act
            int NeuerProgrammcounter = operation.swapf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b0000_1111, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }

        [TestMethod]
        public void TestOperationen_xorwf()
        {
            //Arrange 
            Operationen operation = new Operationen();
            int programminhalt = 1537;
            int programmcounter = 1;
            operation.Bank1[1] = 0b1111_0000;
            operation.w = 0b1010_1010;


            //Act
            int NeuerProgrammcounter = operation.swapf(programminhalt, programmcounter);

            //Assert
            Assert.AreEqual(0b0000_1111, operation.w);
            Assert.AreEqual(1, NeuerProgrammcounter);
        }
    }
}
