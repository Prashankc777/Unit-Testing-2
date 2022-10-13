using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculatorNUnitTest
    {

        private GradingCalculator gradingCalculator;

        [SetUp]
        public void SetUp()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void GradingCal_InputScore95Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;

            string result = gradingCalculator.GetGrade();

            Assert.That(result , Is.EqualTo("A"));
           // Assert.Equals(result, "A");
        }

        [Test]
        public void GradingCal_InputScore85Attendance90_GetBGrade()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;

            string result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("B"));
            // Assert.Equals(result, "A");
        }


        [Test]
        public void GradingCal_InputScore65Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;

            string result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("C"));
            // Assert.Equals(result, "A");
        }

        [Test]
        [TestCase(95 , 65 , ExpectedResult = "B")]
        public string GradingCal_InputScore95Attendance65_GetAGrade(int score , int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            string result = gradingCalculator.GetGrade();

            return result;
            // Assert.Equals(result, "A");
        }


        [Test]
        [TestCase(95 ,55)]
        
        [TestCase(65 , 55)]
        [TestCase(50 , 90)]
        public void GradingCal_FailureScenario_GetAGrade(int score , int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            string result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("F"));
            // Assert.Equals(result, "A");
        }


    }
}
