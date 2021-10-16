using System.Collections.Generic;
using AdventOfCode2019.Day01;

namespace AdventOfCode2019.Console.Day01
{
    public static class Day01
    {
        public static int ExecutePart01(string fileName)
        {
            IEnumerable<int> moduleMasses = GetModuleMasses(fileName);
            int fuelTotal = GetFuelTotal(moduleMasses);
            return fuelTotal;
        }

        private static int GetFuelTotal(IEnumerable<int> moduleMasses)
        {
            var fuelCalculator = new FuelCalculator();
            var fuelCounterUpper = new FuelCounterUpper(fuelCalculator);
            return fuelCounterUpper.CountFuel(moduleMasses);
        }

        private static IEnumerable<int> GetModuleMasses(string fileName)
        {
            return FileOperations.FileOperations.ReadFileAsCollection(fileName);
        }
    }
}