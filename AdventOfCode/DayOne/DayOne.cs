using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode.DayOne
{
    public class DayOne
    {
        private List<List<int>> input;

        public DayOne(string fileName = "Input.txt")
        {
            input = new List<List<int>>();
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("DayOne." + fileName));
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var results = reader.ReadToEnd().Split(Environment.NewLine);
                var elf = new List<int>();
                foreach (var result in results)
                {
                    if (!string.IsNullOrEmpty(result))
                    {
                        elf.Add(int.Parse(result));
                    }
                    else
                    {
                        input.Add(elf);
                        elf = new List<int>();
                    }
                }
                input.Add(elf);
            }
        }

        public int PartOne()
        {
            return input.Max(x => x.Sum());
        }

        public int PartTwo()
        {
            return input.Select(x => x.Sum()).OrderByDescending(y => y).Take(3).Sum();
        }
    }
}
