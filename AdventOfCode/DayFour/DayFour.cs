using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode.DayFour
{
    public class DayFour
    {
        private readonly IEnumerable<(List<int>, List<int>)> _input;

        public DayFour(string fileName = "Input.txt")
        {
            _input = new List<(List<int>, List<int>)>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("DayFour." + fileName));
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var lines = reader.ReadToEnd().Split(Environment.NewLine);
                foreach (var line in lines)
                {
                    var pairs = line.Split(',');
                    var firstRange = Enumerable.Range(int.Parse(pairs[0].Split('-')[0]), int.Parse(pairs[0].Split('-')[1]) - int.Parse(pairs[0].Split('-')[0]) + 1).ToList();
                    var secondRange = Enumerable.Range(int.Parse(pairs[1].Split('-')[0]), int.Parse(pairs[1].Split('-')[1]) - int.Parse(pairs[1].Split('-')[0]) + 1).ToList();
                    _input = _input.Append(new ValueTuple<List<int>, List<int>>(firstRange, secondRange));
                }
                
            }
        }

        public int PartOne()
        {
            return _input.Count(section => (section.Item1.Min() <= section.Item2.Min() && section.Item1.Max() >= section.Item2.Max()) || (section.Item2.Min() <= section.Item1.Min() && section.Item2.Max() >= section.Item1.Max()));
        }

        public int PartTwo()
        {
            return _input.Count(section => section.Item1.Intersect(section.Item2).Any());
        }
    }
}