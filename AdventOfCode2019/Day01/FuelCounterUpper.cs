using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day01
{
    public class FuelCounterUpper
    {
        private readonly IFuelCalculator fuelCalculator;

        public FuelCounterUpper(IFuelCalculator fuelCalculator)
        {
            this.fuelCalculator = fuelCalculator;
        }

        public int CountFuel(IEnumerable<int> moduleMasses)
        {
            return moduleMasses.Sum(x => CalculateFuel(x));
        }

        private int CalculateFuel(in int moduleMass)
        {
            return fuelCalculator.Calculate(moduleMass);
        }

        public int CountTotalFuel(IEnumerable<int> moduleMasses)
        {
            int fuel = moduleMasses.Sum(x => CountTotalFuelForModule(x));
            return fuel;
        }

        private int CountTotalFuelForModule(in int moduleMass)
        {
            int fuel = CalculateFuel(moduleMass);
            int totalFuel = fuel;
            while (fuel > 0)
            {
                fuel = CalculateFuel(fuel);
                if (fuel > 0)
                    totalFuel += fuel;
            }

            return totalFuel;
        }
    }
}