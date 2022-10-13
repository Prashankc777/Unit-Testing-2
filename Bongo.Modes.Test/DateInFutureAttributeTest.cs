using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bongo.Models.ModelValidations;
using NUnit.Framework;

namespace Bongo.Models
{
    [TestFixture]
    public class DateInFutureAttributeTest
    {

        [TestCase(100 , ExpectedResult = true)]
        [TestCase(-100 , ExpectedResult = false)]
        [TestCase(0 , ExpectedResult = false)]
        public bool DateValidation_InputExpectedDate_DateValidity(int time)
        {
            DateInFutureAttribute attribute = new DateInFutureAttribute(() => DateTime.Now);

            return attribute.IsValid(DateTime.Now.AddSeconds(time));
            
        }

        [Test]
        public void DateValidator_NotValidDate_ReturnErrorMessage()
        {
            var result = new DateInFutureAttribute();
            Assert.AreEqual("Date must be in the future", result.ErrorMessage!);
        }
    }
}
