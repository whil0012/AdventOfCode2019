using System;
using System.Collections.Generic;
using AdventOfCode2019.Day01;

namespace AdventOfCode2019.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ExecuteDay02(args);
            //ExecuteDay01(args);
        }

        private static void ExecuteDay02(string[] args)
        {
            int programPosition = Day02.Day02.ExecutePart01(args[0]);
            Print($"Position 0 Value: {programPosition}");
        }

        private static void ExecuteDay01(string[] args)
        {
            var fuelTotal = Day01.Day01.ExecutePart01(args[0]);
            Print($"Fuel Total: {fuelTotal}");
            Print(Environment.NewLine);
            var fuelTotalWithAdditionalFuel = Day01.Day01.ExecutePart02(args[0]);
            Print($"Fuel Total (w/ Additional fuel): {fuelTotalWithAdditionalFuel}");
        }

        private static void Print(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}