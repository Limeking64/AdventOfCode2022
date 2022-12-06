using AdventOfCode.DayOne;
using NUnit.Framework;
using System;

namespace AdventOfCodeTests
{
    public class DayOneTests
    {
        [Test]
        public void PartOne_ExamplePasses()
        {
            var result = new DayOne("Example.txt").PartOne();
            Console.WriteLine(result);
            Assert.AreEqual(result, 24000);
        }

        [Test]
        public void PartOne()
        {
            Console.WriteLine(new DayOne().PartOne());
        }

        [Test]
        public void PartTwo_ExamplePasses()
        {
            var result = new DayOne("Example.txt").PartTwo();
            Console.WriteLine(result);
            Assert.AreEqual(result, 45000);
        }

        [Test]
        public void PartTwo()
        {
            Console.WriteLine(new DayOne().PartTwo());
        }
    }
}