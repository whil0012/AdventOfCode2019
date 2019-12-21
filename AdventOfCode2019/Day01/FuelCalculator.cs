namespace AdventOfCode2019.Day01
{
    public class FuelCalculator : IFuelCalculator
    {
        public int Calculate(int moduleMass)
        {
            return moduleMass / 3 - 2;
        }
    }
}