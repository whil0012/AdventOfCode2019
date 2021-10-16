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

        public const int AdditionalFuelModule1Mass = 14;

        public const int AdditionalFuelModule1Fuel = 2;

        [Test]
        public void CountAdditionalFuel_WhenOneModuleAndAdditionalFuelCalculationReturns0_ReturnsOnlyModule1FuelRequirement()
        {
            SetUpFuelCalculator(AdditionalFuelModule1Mass, AdditionalFuelModule1Fuel);
            SetUpFuelCalculator(AdditionalFuelModule1Fuel, 0);
            int actual = CountTotalFuel(AdditionalFuelModule1Mass);
            Assert.That(actual, Is.EqualTo(AdditionalFuelModule1Fuel));
        }

        public const int AdditionalFuelModule1FuelMoreFuel = 1;

        [Test]
        public void CountTotalFuel_WhenOneModuleAndAdditionalFuelCalculationReturnsNonZero_ReturnsModule1AndFuelTotalRequirement()
        {
            SetUpFuelCalculator(AdditionalFuelModule1Mass, AdditionalFuelModule1Fuel);
            SetUpFuelCalculator(AdditionalFuelModule1Fuel, AdditionalFuelModule1FuelMoreFuel);
            SetUpFuelCalculator(AdditionalFuelModule1FuelMoreFuel, 0);
            int actual = CountTotalFuel(AdditionalFuelModule1Mass);
            int expectedTotalFuel = AdditionalFuelModule1Fuel + AdditionalFuelModule1FuelMoreFuel;
            Assert.That(actual, Is.EqualTo(expectedTotalFuel));
        }

        public const int AdditionalFuelModule1FuelMoreFuel2 = 3;

        public const int AdditionalFuelModule1FuelMoreFuel3 = 5;

        public const int AdditionalFuelModule1FuelMoreFuel4 = 7;

        [Test]
        public void CountTotalFuel_WhenOneModuleAndAdditionalFuelRequiresFourCalculations_ReturnsModule1AndFuelTotalRequirement()
        {
            SetUpFuelCalculator(AdditionalFuelModule1Mass, AdditionalFuelModule1Fuel);
            SetUpFuelCalculator(AdditionalFuelModule1Fuel, AdditionalFuelModule1FuelMoreFuel);
            SetUpFuelCalculator(AdditionalFuelModule1FuelMoreFuel, AdditionalFuelModule1FuelMoreFuel2);
            SetUpFuelCalculator(AdditionalFuelModule1FuelMoreFuel2, AdditionalFuelModule1FuelMoreFuel3);
            SetUpFuelCalculator(AdditionalFuelModule1FuelMoreFuel3, AdditionalFuelModule1FuelMoreFuel4);
            SetUpFuelCalculator(AdditionalFuelModule1FuelMoreFuel4, 0);
            int expectedTotalFuel = AdditionalFuelModule1Fuel + AdditionalFuelModule1FuelMoreFuel +
                                    AdditionalFuelModule1FuelMoreFuel2 + AdditionalFuelModule1FuelMoreFuel3 + 
                                    AdditionalFuelModule1FuelMoreFuel4;
            int actual = CountTotalFuel(AdditionalFuelModule1Mass);
            Assert.That(actual, Is.EqualTo(expectedTotalFuel));
        }

        [Test]
        public void CountTotalFuel_WhenOneModuleAndAdditionalFuelFinalFuelIsNegative_ReturnsModule1AndFuelTotalRequirement()
        {
            SetUpFuelCalculator(AdditionalFuelModule1Mass, AdditionalFuelModule1Fuel);
            SetUpFuelCalculator(AdditionalFuelModule1Fuel, AdditionalFuelModule1FuelMoreFuel);
            SetUpFuelCalculator(AdditionalFuelModule1FuelMoreFuel, AdditionalFuelModule1FuelMoreFuel2);
            SetUpFuelCalculator(AdditionalFuelModule1FuelMoreFuel2, AdditionalFuelModule1FuelMoreFuel3);
            SetUpFuelCalculator(AdditionalFuelModule1FuelMoreFuel3, AdditionalFuelModule1FuelMoreFuel4);
            SetUpFuelCalculator(AdditionalFuelModule1FuelMoreFuel4, -2);
            int expectedTotalFuel = AdditionalFuelModule1Fuel + AdditionalFuelModule1FuelMoreFuel +
                                    AdditionalFuelModule1FuelMoreFuel2 + AdditionalFuelModule1FuelMoreFuel3 +
                                    AdditionalFuelModule1FuelMoreFuel4;
            int actual = CountTotalFuel(AdditionalFuelModule1Mass);
            Assert.That(actual, Is.EqualTo(expectedTotalFuel));
        }

        public const int AdditionalFuelModule2Mass = 24;

        public const int AdditionalFuelModule2MoreFuel = 4;

        public const int AdditionalFuelModule2MoreFuel2 = 6;

        [Test]
        public void CountTotalFuel_WhenTwoModulesBothRequiringMultipleAdditionalFuelCalculations_ReturnsSumOfModulesAndAdditionalFuelRequirement()
        {
            SetUpFuelCalculator(AdditionalFuelModule1Mass, AdditionalFuelModule1Fuel);
            SetUpFuelCalculator(AdditionalFuelModule1Fuel, AdditionalFuelModule1FuelMoreFuel);
            SetUpFuelCalculator(AdditionalFuelModule1FuelMoreFuel, -1);
            SetUpFuelCalculator(AdditionalFuelModule2Mass, AdditionalFuelModule2MoreFuel);
            SetUpFuelCalculator(AdditionalFuelModule2MoreFuel, AdditionalFuelModule2MoreFuel2);
            SetUpFuelCalculator(AdditionalFuelModule2MoreFuel2, -2);
            int expectedFuelTotal = AdditionalFuelModule1Fuel + AdditionalFuelModule1FuelMoreFuel +
                                    AdditionalFuelModule2MoreFuel + AdditionalFuelModule2MoreFuel2;
            int actual = CountTotalFuel(AdditionalFuelModule1Mass, AdditionalFuelModule2Mass);
            Assert.That(actual, Is.EqualTo(expectedFuelTotal));
        }

        private void SetUpFuelCalculator(in int module1Mass, in int module1Fuel)
        {
            fuelCalculatorMock.Calculate(module1Mass).Returns(module1Fuel);
        }

        private int CountFuel(params int[] moduleMass)
        {
            return systemUnderTest.CountFuel(moduleMass);
        }

        private int CountTotalFuel(params int[] moduleMass)
        {
            return systemUnderTest.CountTotalFuel(moduleMass);
        }
    }
}