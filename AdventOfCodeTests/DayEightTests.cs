using NUnit.Framework;
using System;
using AdventOfCode.DayEight;

namespace AdventOfCodeTests
{
    public class DayEightTests
    {
        [Test]
        public void PartOne_ExamplePasses()
        {
            var result = new DayEight("Example.txt").PartOne();
            Console.WriteLine(result);
            Assert.AreEqual(21, result);
        }

        [Test]
        public void PartOne()
        {
            Console.WriteLine(new DayEight().PartOne());
        }
        
        [Test]
        public void PartTwo_ExamplePasses()
        {
            var result = new DayEight("Example.txt").PartTwo();
            Console.WriteLine(result);
            Assert.AreEqual(8, result);
        }
        
        [Test]
        public void PartTwo()
        {
            Console.WriteLine(new DayEight().PartTwo());
        }
    }
}