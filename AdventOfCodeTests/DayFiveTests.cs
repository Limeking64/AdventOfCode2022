using NUnit.Framework;
using System;
using AdventOfCode.DayFive;

namespace AdventOfCodeTests
{
    public class DayFiveTests
    {
        [Test]
        public void PartOne_ExamplePasses()
        {
            var result = new DayFive("Example.txt").PartOne();
            Console.WriteLine(result);
            Assert.AreEqual("CMZ", result);
        }

        [Test]
        public void PartOne()
        {
            Console.WriteLine(new DayFive().PartOne());
        }
        
        [Test]
        public void PartTwo_ExamplePasses()
        {
            var result = new DayFive("Example.txt").PartTwo();
            Console.WriteLine(result);
            Assert.AreEqual("MCD", result);
        }
        
        [Test]
        public void PartTwo()
        {
            Console.WriteLine(new DayFive().PartTwo());
        }
    }
}