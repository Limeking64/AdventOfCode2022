using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode.DayFive
{
    public class DayFive
    {
        private readonly List<List<string>> _stacks;
        private readonly List<Instruction> _instructions;
        
        public DayFive(string fileName = "Input.txt")
        {
            _stacks = new List<List<string>>();
            _instructions = new List<Instruction>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("DayFive." + fileName));
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var lines = reader.ReadToEnd().Split(Environment.NewLine).ToList();
                // Find the line that shows how many stacks there
                var indexOfStackNumberLine = lines.FindIndex(x => !x.Contains('['));
                var numberOfStacks = int.Parse(lines[indexOfStackNumberLine].Trim().Last().ToString());

                for (int i = 0; i < numberOfStacks; i++)
                {
                    _stacks.Add(new List<string>());
                }

                for (int i = indexOfStackNumberLine - 1; i >= 0; i--)
                {
                    var crates = lines[i];

                    for (int j = 0; j < numberOfStacks; j++)
                    {
                        var posOfValue = lines[indexOfStackNumberLine]
                            .IndexOf((j + 1).ToString(), StringComparison.OrdinalIgnoreCase);
                        var value = crates[posOfValue].ToString();
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            _stacks[j].Add(value);
                        }
                    }
                }

                for (int i = indexOfStackNumberLine + 2; i < lines.Count; i++)
                {
                    var instruction = new Instruction();
                    var matches = Regex.Match(lines[i], @"\d+");
                    instruction.MoveAmount = int.Parse(matches.Value);
                    matches = matches.NextMatch();
                    instruction.Source = int.Parse(matches.Value) - 1;
                    matches = matches.NextMatch();
                    instruction.Destination = int.Parse(matches.Value) - 1;
                    
                    _instructions.Add(instruction);
                }
            }
        }

        public string PartOne()
        {
            foreach (var instruction in _instructions)
            {
                for (int i = 0; i < instruction.MoveAmount; i++)
                {
                    _stacks[instruction.Destination].Add(_stacks[instruction.Source].Last());
                    _stacks[instruction.Source].RemoveAt(_stacks[instruction.Source].Count() - 1);
                }
            }

            var message = "";

            foreach (var stack in _stacks)
            {
                message += stack.Last();
            }

            return message;
        }
        
        public string PartTwo()
        {
            foreach (var instruction in _instructions)
            {
                for (int i = 0; i < instruction.MoveAmount; i++)
                {
                    _stacks[instruction.Destination].Add(_stacks[instruction.Source][_stacks[instruction.Source].Count() - instruction.MoveAmount + i]);
                    _stacks[instruction.Source].RemoveAt(_stacks[instruction.Source].Count() - instruction.MoveAmount + i);
                }
            }

            var message = "";

            foreach (var stack in _stacks)
            {
                message += stack.Last();
            }

            return message;
        }
    }
}