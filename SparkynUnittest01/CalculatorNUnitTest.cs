using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture] 
    public class CalculatorNUnitTest
    {
        [Test]
        public void AddNumber_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new();
            //Act
            int result = calc.AddNumber(1, 2);
            //Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void IsOddCheckher_InputEvenNumber_ReturnFalse()
        {
            Calculator calculator = new();
            bool isOdd = calculator.IsOddNumber(10);
            Assert.IsFalse(isOdd);
        }

        [Test]
        public void IsOddChecker_InputOddNumber_ReturnTrue()
        {
            Calculator calculator = new();
            bool isOdd = calculator.IsOddNumber(9);
            Assert.IsTrue(isOdd);
        }



    }
}
