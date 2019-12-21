using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2019.Day01;

namespace AdventOfCode2019.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteDay01(args);
        }

        private static void ExecuteDay01(string[] args)
        {
            IEnumerable<int> moduleMasses = GetModuleMasses(args);
            int fuelTotal = GetFuelTotal(moduleMasses);
            Print($"Fuel Total: {fuelTotal}");
        }

        private static void Print(string message)
        {
            System.Console.WriteLine(message);
        }

        private static int GetFuelTotal(IEnumerable<int> moduleMasses)
        {
            FuelCalculator fuelCalculator = new FuelCalculator();
            FuelCounterUpper fuelCounterUpper = new FuelCounterUpper(fuelCalculator);
            return fuelCounterUpper.CountFuel(moduleMasses);
        }

        private static IEnumerable<int> GetModuleMasses(string[] args)
        {
            string inputFileContents = ReadFileFromCommandLine(args);
            IEnumerable<int> moduleMasses = inputFileContents
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            return moduleMasses;
        }

        private static string ReadFileFromCommandLine(string[] args)
        {
            string fileName = args[0];
            return File.ReadAllText(fileName);
        }
    }
}