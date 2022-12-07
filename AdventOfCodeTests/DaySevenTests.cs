using NUnit.Framework;
using System;
using AdventOfCode.DaySeven;

namespace AdventOfCodeTests
{
    public class DaySevenTests
    {
        [Test]
        public void PartOne_ExamplePasses()
        {
            var result = new DaySeven("Example.txt").PartOne();
            Console.WriteLine(result);
            Assert.AreEqual(95437, result);
        }

        [Test]
        public void PartOne()
        {
            Console.WriteLine(new DaySeven().PartOne());
        }
        
        [Test]
        public void PartTwo_ExamplePasses()
        {
            var result = new DaySeven("Example.txt").PartTwo();
            Console.WriteLine(result);
            Assert.AreEqual(24933642, result);
        }
        
        [Test]
        public void PartTwo()
        {
            Console.WriteLine(new DaySeven().PartTwo());
        }
    }
}