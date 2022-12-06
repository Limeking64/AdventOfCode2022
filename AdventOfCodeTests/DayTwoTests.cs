using AdventOfCode.DayOne;
using AdventOfCode.DayTwo;
using NUnit.Framework;
using System;

namespace AdventOfCodeTests
{
    public class DayTwoTests
    {
        [Test]
        public void PartOne_ExamplePasses()
        {
            var result = new DayTwo("Example.txt").PartOne();
            Console.WriteLine(result);
            Assert.AreEqual(result, 15);
        }

        [Test]
        public void PartOne()
        {
            Console.WriteLine(new DayTwo().PartOne());
        }

        [Test]
        public void PartTwo_ExamplePasses()
        {
            var result = new DayTwo("Example.txt").PartTwo();
            Console.WriteLine(result);
            Assert.AreEqual(result, 12);
        }

        [Test]
        public void PartTwo()
        {
            Console.WriteLine(new DayTwo().PartTwo());
        }
    }
}