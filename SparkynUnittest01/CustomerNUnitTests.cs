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
        private Customer customer;
        [SetUp]
        public void SetUp()
        {
            customer = new Customer();
        }

        [Test]
        public void Combine_InputFirstNameAndLastName_ReturnFullName()
        {
            //uta assert ma issue ayo vane aru run hudaina esari multiple ma rakhyo vane RUn huncha 
            Assert.Multiple(() =>
            {
                customer.GreetAndCombinedName("Ben", "Spark", "Test");
                Assert.That(customer.GreetMessage, Is.EqualTo("Ben Spark Test"));
                //Assert.AreEqual(customer.GreetMessage, "Ben Spark Test");
                //Assert.That(customer.GreetMessage, Does.Contain(",").IgnoreCase);
                //Assert.That(customer.GreetMessage, Does.StartWith("B"));
            });
           
        }

        [Test]

        public void GreetMessage_NotGreeted_ReturnNull()
        {
            // no act
            Assert.IsNull(customer.GreetMessage);

        }


        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountRange()
        {
            int result = customer.Discount;
            Assert.That(result , Is.InRange(10 , 25));
        }

    }
}
