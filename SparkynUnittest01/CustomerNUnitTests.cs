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

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnNull()
        {
            customer.GreetAndCombinedName("ben", "" , "");
            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Test]

        public void GreetChecker_EmptyFirsName_ThrowsException()
        {
            // exception with messgae
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombinedName("", "", "Spark"));
            Assert.AreEqual("Empty First name", exceptionDetails.Message);
            Assert.That(() =>  customer.GreetAndCombinedName("", "" , ""), 
                Throws.ArgumentException.With.Message.EqualTo("Empty First name"));

            //excpetoin thrown or not matra check agrne 

            Assert.Throws<ArgumentException>(() => customer.GreetAndCombinedName("", "", "Spark"));
            
            Assert.That(() => customer.GreetAndCombinedName("", "", ""),
                Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithlessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetail();
            Assert.That(result, Is.TypeOf<Customer.BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetail();
            Assert.That(result, Is.TypeOf<Customer.PlatinumCustomer>());
        }

    }
}
