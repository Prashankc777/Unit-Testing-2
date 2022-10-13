using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTest
    {

        [Test]
        public void AddNumber_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new Calculator();
            //Act

            int result = calc.AddNumber(1, 2);

            //Assert

            Assert.AreEqual(3, result);




        }
    }
}
