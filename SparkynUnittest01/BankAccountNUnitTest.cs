using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Moq;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class BankAccountNUnitTest
    {

        private BankAccount bankAccount;
        [SetUp]

        public void SetUp()
        {

        }

        //        [Test]

        //public void BankDepositFakeMethod_Add100_ReturnTrue()
        //{
        //    BankAccount BankAccount = new BankAccount(new LogFaker());
        //    var result = BankAccount.Deposit(100);
        //    Assert.IsTrue(result);
        //    Assert.That(BankAccount.GetCurrentBalance, Is.EqualTo(100));
        //}

        [Test]
        public void BankDepositMethod_Add100_ReturnTrue()
        {
            //fake object 
            var logMock = new Mock<IlogBook>();
            BankAccount BankAccount = new BankAccount(logMock.Object);

            var result = BankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(BankAccount.GetCurrentBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        public void BankWithdrawal_WithDraw100With200Balance_ReturnTrue(int balance, int withdrawl)

        {
            var logMock = new Mock<IlogBook>();
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            BankAccount BankAccount = new BankAccount(logMock.Object);
            BankAccount.Deposit(balance);
            var result = BankAccount.WithDraw(withdrawl);
            Assert.IsTrue(result);
        }

        [Test]
        public void BankWithDraw_WithDraw300With200Balance_ReturnFalse()
        {
            var logMock = new Mock<IlogBook>();

            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(true);
            BankAccount BankAccount = new BankAccount(logMock.Object);
            BankAccount.Deposit(300);
            var result = BankAccount.WithDraw(200);
            Assert.IsTrue(result);
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<IlogBook>();
            string desiredOutput = "Hello";
            logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str);
            Assert.That(logMock.Object.MessageWithReturnStr("Hello"), Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<IlogBook>();
            string desiredOutput = "Hello";
            logMock.Setup(u => u.LogWithOutputResult(It.IsAny<string>() , out desiredOutput)).Returns(true);
            string result = string.Empty;
            Assert.IsTrue(logMock.Object.LogWithOutputResult("ben", out result));
            Assert.That(logMock.Object.MessageWithReturnStr("Hello"), Is.EqualTo(desiredOutput));
        }



    }
}
