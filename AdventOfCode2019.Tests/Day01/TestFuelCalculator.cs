using AdventOfCode2019.Day01;
using NUnit.Framework;

namespace AdventOfCode2019.Tests.Day01
{
    [TestFixture]
    public class TestFuelCalculator
    {
        private FuelCalculator systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            systemUnderTest = new FuelCalculator();
        }

        [Test]
        public void Calculate_WhenMassEvenlyDivisibleBy3_ReturnsMassDividedBy3Minus2()
        {
            int actual = Calculate(12);
            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void Calculate_WhenMassNotEvenlyDivisibleBy3_ReturnsMassDividedBy3RoundedDownMinus2()
        {
            int actual = Calculate(14);
            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void Calculate_WhenMassIsHighNumber_ReturnsExpectedFuel()
        {
            int actual = Calculate(1969);
            Assert.That(actual, Is.EqualTo(654));
        }

        private int Calculate(int mass)
        {
            return systemUnderTest.Calculate(mass);
        }
    }
}