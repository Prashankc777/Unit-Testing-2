using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
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
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            Calculator calculator = new();
            bool isOdd = calculator.IsOddNumber(a);
            Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculator calculator = new();
            return calculator.IsOddNumber(a);
        }

        [Test]
        [TestCase(5.4 , 10.5)]
        [TestCase(5.43 , 10.53)]
        [TestCase(5.49 , 10.59)]
        public void AddNumberDouble_InputTwoDouble_GetCorrectAddition(double a , double b)
        {
            //Arrange
            Calculator calc = new();
            //Act
            double result = calc.AddNumbersDouble(a, b);
            //Assert
            //Delta vaneko expected ra result ko difference 1 vayo vane its ok

            Assert.AreEqual(15.9, result , 1);
        }



    }
}
