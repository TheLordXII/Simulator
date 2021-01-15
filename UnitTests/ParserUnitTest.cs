using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Simulator
{
    [TestClass]
    public class ParserUnitTest
    {
        [TestMethod]
        public void TestParserMain()
        {
            //Arrange


            //Act

            //Assert
        }

        [TestMethod]
        public void TestParserProgrammspeicherLeeren()
        {
            //Arrange
            String[] matches = new String[1024];
            Parser parser = new Parser();
            parser.setCounter(100);

            //Act
            parser.ProgrammspeicherLeeren();

            //Assert
            Assert.AreEqual(0, parser.counter);
        }
    }
}
