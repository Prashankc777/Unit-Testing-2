using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        [Test]
        public void Combine_InputFirstNameAndLastName_ReturnFullName()
        {
            var customer = new Customer();

            string fullName = customer.GreetAndCombinedName("Ben", "Spark", "Test");

            Assert.That(fullName, Is.EqualTo("Ben Spark Test"));
            Assert.AreEqual(fullName, "Ben Spark Test");
            Assert.That(fullName, Does.Contain(","));
            Assert.That(fullName, Does.StartWith("B"));

        }
    }
}
