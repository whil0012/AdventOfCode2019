using System;
using AdventOfCode2019.Day01;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AdventOfCode2019.Tests.Day01
{
    [TestFixture]
    public class TestFuelCounterUpper
    {
        private const int Module1Mass = 23;

        private const int Module1Fuel = 42;

        private FuelCounterUpper systemUnderTest;

        private IFuelCalculator fuelCalculatorMock;

        [SetUp]
        public void SetUp()
        {
            fuelCalculatorMock = Substitute.For<IFuelCalculator>();
            systemUnderTest = new FuelCounterUpper(fuelCalculatorMock);
        }

        [Test]
        public void CountFuel_WhenOneModule_ReturnsFuelForModule()
        {
            SetUpFuelCalculator(Module1Mass, Module1Fuel);
            int actual = CountFuel(Module1Mass);
            Assert.That(actual, Is.EqualTo(Module1Fuel));
        }

        private const int Module2Mass = 55;
        private const int Module2Fuel = 123;

        [Test]
        public void CountFuel_WhenTwoModules_ReturnsSumOfModuleFuels()
        {
            SetUpFuelCalculator(Module1Mass, Module1Fuel);
            SetUpFuelCalculator(Module2Mass, Module2Fuel);
            int actual = CountFuel(Module1Mass, Module2Mass);
            Assert.That(actual, Is.EqualTo(Module1Fuel + Module2Fuel));
        }

        private void SetUpFuelCalculator(in int module1Mass, in int module1Fuel)
        {
            fuelCalculatorMock.Calculate(module1Mass).Returns(module1Fuel);
        }

        private int CountFuel(params int[] moduleMass)
        {
            return systemUnderTest.CountFuel(moduleMass);
        }
    }
}