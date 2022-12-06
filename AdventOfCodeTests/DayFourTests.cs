using NUnit.Framework;
using System;
using AdventOfCode.DayFour;

namespace AdventOfCodeTests
{
    public class DayFourTests
    {
        [Test]
        public void PartOne_ExamplePasses()
        {
            var result = new DayFour("Example.txt").PartOne();
            Console.WriteLine(result);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void PartOne()
        {
            Console.WriteLine(new DayFour().PartOne());
        }
        
        [Test]
        public void PartTwo_ExamplePasses()
        {
            var result = new DayFour("Example.txt").PartTwo();
            Console.WriteLine(result);
            Assert.AreEqual(4, result);
        }
        
        [Test]
        public void PartTwo()
        {
            Console.WriteLine(new DayFour().PartTwo());
        }
    }
}