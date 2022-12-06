using NUnit.Framework;
using System;
using AdventOfCode.DayThree;

namespace AdventOfCodeTests
{
    public class DayThreeTests
    {
        [Test]
        public void PartOne_ExamplePasses()
        {
            var result = new DayThree("Example.txt").PartOne();
            Console.WriteLine(result);
            Assert.AreEqual(157, result);
        }

        [Test]
        public void PartOne()
        {
            Console.WriteLine(new DayThree().PartOne());
        }
        
        [Test]
        public void PartTwo_ExamplePasses()
        {
            var result = new DayThree("Example.txt").PartTwo();
            Console.WriteLine(result);
            Assert.AreEqual(70, result);
        }
        
        [Test]
        public void PartTwo()
        {
            Console.WriteLine(new DayThree().PartTwo());
        }
    }
}