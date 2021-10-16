using System;
using System.Collections.Generic;
using AdventOfCode2019.Day01;

namespace AdventOfCode2019.Console.Day01
{
    public static class Day01
    {
        public static int ExecutePart01(string fileName)
        {
            return ExecutePart(fileName, CountFuel);
        }

        public static int ExecutePart02(string fileName)
        {
            return ExecutePart(fileName, CountTotalFuel);
        }

        private static int ExecutePart(string fileName, Func<IEnumerable<int>, FuelCounterUpper, int> countFuelFunc)
        {
            IEnumerable<int> moduleMasses = GetModuleMasses(fileName);
            var fuelCalculator = new FuelCalculator();
            var fuelCounterUpper = new FuelCounterUpper(fuelCalculator);
            return countFuelFunc(moduleMasses, fuelCounterUpper);
        }

        private static int CountFuel(IEnumerable<int> moduleMasses, FuelCounterUpper fuelCounterUpper)
        {
            return fuelCounterUpper.CountFuel(moduleMasses);
        }

        private static IEnumerable<int> GetModuleMasses(string fileName)
        {
            return FileOperations.FileOperations.ReadFileAsCollection(fileName);
        }

        private static int CountTotalFuel(IEnumerable<int> moduleMasses, FuelCounterUpper fuelCounterUpper)
        {
            return fuelCounterUpper.CountTotalFuel(moduleMasses);
        }
    }
}