using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class FiboNUnitTest
    {

        private Fibo Fibo;
        [SetUp]
        public void SetUp()
        {
            Fibo = new Fibo();
        }

        [Test]
        public void FiboSeries_Input1_ReturnsFiboSeries()
        {
            List<int> expectedRange = new() {0};
            Fibo.Range = 1;

            List<int> result = Fibo.GetFiboSeries();

            Assert.That(result , Is.Not.Empty);
            Assert.That(result , Is.Ordered);
            Assert.That(result , Is.EquivalentTo(expectedRange));
        }

        [Test]
        public void FiboSeries_Input6_ReturnsFiboSeries()
        {
            List<int> expectedRange = new() { 0 , 1,1,2,3,5 };
            Fibo.Range = 6;

            List<int> result = Fibo.GetFiboSeries();

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Empty);
                Assert.That(result, Does.Contain(3));
                Assert.That(result.Count, Is.EqualTo(6));
                Assert.That(result, Is.Ordered);
                Assert.That(result, Has.No.Member(4));
                Assert.That(result, Is.EquivalentTo(expectedRange));
            });

           
        }
    }
}
