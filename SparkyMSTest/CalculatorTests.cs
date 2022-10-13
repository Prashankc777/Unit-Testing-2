using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparky;

namespace SparkyMSTest
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void AddNumber_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new();

            //Act
            int result = calc.AddNumber(1, 2);

            //Assert
            Assert.AreEqual(3 , result);
            

        }

    }
}
