using NUnit.Framework;
using System;
using AdventOfCode.DaySix;

namespace AdventOfCodeTests
{
    public class DaySixTests
    {
        [Test]
        public void PartOne_ExamplePasses()
        {
            var result = new DaySix("Example.txt").PartOne();
            Console.WriteLine(result);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void PartOne()
        {
            Console.WriteLine(new DaySix().PartOne());
        }
        
        [Test]
        public void PartTwo_ExamplePasses()
        {
            var result = new DaySix("Example.txt").PartTwo();
            Console.WriteLine(result);
            Assert.AreEqual(19, result);
        }
        
        [Test]
        public void PartTwo()
        {
            Console.WriteLine(new DaySix().PartTwo());
        }
    }
}