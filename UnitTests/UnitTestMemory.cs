using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Simulator.Models;

namespace Simulator
{
    [TestClass]
    public class UnitTestMemory
    {
        Memory _memory;

        [TestMethod]
        public void Test_ChangeC()
        {
            //Arrange
            _memory = new Memory();
            int value = 257;

            //Act
            int result = _memory.ChangeC(value);

            //Assert
            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void Test_ChangeZ()
        {
            //Arrange
            _memory = new Memory();
            int value = 0;

            //Act
            _memory.ChangeZ(value);

            //Assert
            Assert.AreEqual(0b0000_0100, _memory.GetFromFileRegister(3));
        }

        [TestMethod]
        public void Test_ChangeDC()
        {
            //Arrange
            _memory = new Memory();
            _memory.WriteToMemory(2, 3);
            _memory.W = 14;
            int value = 0;
            bool op = true;

            //Act
            _memory.ChangeDC(value, op);

            //Assert
            Assert.AreEqual(0b0000_0000, _memory.GetFromFileRegister(3));

        }

        [TestMethod]
        public void Test_WriteToMemory_W()
        {
            //Arrange
           _memory = new Memory();

            //Act
            _memory.WriteToMemory(5);

            //Assert
            Assert.AreEqual(5, _memory.W);

        }

        [TestMethod]
        public void Test_WriteToMemory_FileReg()
        {
            //Arrange
            _memory = new Memory();
            int value = 5;
            int position = 5;

            //Act
            _memory.WriteToMemory(value, position);

            //Assert
            Assert.AreEqual(5, _memory.GetFromFileRegister(position));
        }

        [TestMethod]
        public void Test_WriteToMemory_W_WithOperator()
        {
            //Arrange
            _memory = new Memory();
            bool op = true;

            //Act
            _memory.WriteToMemory(5, op);

            //Assert
            Assert.AreEqual(5, _memory.W);
        }

        [TestMethod]
        public void Test_WriteToMemory_FileReg_WithOperator()
        {
            //Arrange
            _memory = new Memory();
            int value = 5;
            bool op = false;
            int position = 5;

            //Act
            _memory.WriteToMemory(value, op, position);

            //Assert
            Assert.AreEqual(5, _memory.GetFromFileRegister(position));
        }

        [TestMethod]
        public void Test_SetBit()
        {
            //Arrange
            _memory = new Memory();
            short position = 5;
            short bit = 3;

            //Act
            _memory.SetBit(position, bit);

            //Assert
            Assert.AreEqual(8, _memory.GetFromFileRegister(position));

        }

        [TestMethod]
        public void Test_ClearBit()
        {
            //Arrange
            _memory = new Memory();
            short position = 5;
            _memory.WriteToMemory(8, position);
            short bit = 3;

            //Act
            _memory.ClearBit(position, bit);

            //Assert
            Assert.AreEqual(0, _memory.GetFromFileRegister(position));

        }

        [TestMethod]
        public void Test_BitSet()
        {
            //Arrange
            _memory = new Memory();
            short position = 5;
            short bit = 3;
            _memory.SetBit(position, bit);

            //Act
            bool result = _memory.BitSet(position, bit);

            //Assert
            Assert.AreEqual(true, result);
        }

    }
}
