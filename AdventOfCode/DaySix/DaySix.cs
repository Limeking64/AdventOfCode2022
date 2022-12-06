using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode.DaySix
{
    public class DaySix
    {
        private readonly string _input;

        public DaySix(string fileName = "Input.txt")
        {
            _input = string.Empty;
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("DaySix." + fileName));
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var lines = reader.ReadToEnd().Split(Environment.NewLine);
                _input = lines[0];
            }
        }

        public int PartOne()
        {
            for (int i = 0; i < _input.Length - 4; i++)
            {
                var bufferSection = _input.Substring(i, 4);

                if (!bufferSection.GroupBy(x => x).Any(y => y.Count() > 1))
                {
                    return i + 4;
                }
            }

            return -1;
        }

        public int PartTwo()
        {
            for (int i = 0; i < _input.Length - 14; i++)
            {
                var bufferSection = _input.Substring(i, 14);

                if (!bufferSection.GroupBy(x => x).Any(y => y.Count() > 1))
                {
                    return i + 14;
                }
            }

            return -1;
        }
    }
}