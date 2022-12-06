using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode.DayThree
{
    public class DayThree
    {
        private readonly IEnumerable<string> _input;
        
        public DayThree(string fileName = "Input.txt")
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("DayThree." + fileName));
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                _input = reader.ReadToEnd().Split(Environment.NewLine);
            }
        }

        public int PartOne()
        {
            var prioritySum = 0;

            foreach (var rucksack in _input)
            {
                var compartmentSize = rucksack.Length / 2;
                var compartmentOne = rucksack.Substring(0, compartmentSize);
                var compartmentTwo = rucksack.Substring(compartmentSize, compartmentSize);
                var duplicates = compartmentOne.Intersect(compartmentTwo);

                foreach (var duplicate in duplicates)
                {
                    prioritySum += GetAlphabetPosition(duplicate);
                    if (char.IsUpper(duplicate))
                    {
                        prioritySum += 26;
                    }
                }
            }
        
            return prioritySum;
        }

        public int PartTwo()
        {
            var prioritySum = 0;
            var backpacks = _input.ToList();
            for (int i = 0; i < backpacks.Count; i += 3)
            {
                var firstElf = backpacks[i];
                var secondElf = backpacks[i + 1];
                var thirdElf = backpacks[i + 2];

                var commonItem = firstElf.Intersect(secondElf.Intersect(thirdElf)).First();
                
                prioritySum += GetAlphabetPosition(commonItem);
                if (char.IsUpper(commonItem))
                {
                    prioritySum += 26;
                }
            }
            
            return prioritySum;
        }

        private int GetAlphabetPosition(char letter)
        {
            return (int)letter % 32;
        }
    }
}