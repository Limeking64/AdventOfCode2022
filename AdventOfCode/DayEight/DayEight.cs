using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode.DayEight
{
    public class DayEight
    {
        private readonly List<List<int>> _input;

        public DayEight(string fileName = "Input.txt")
        {
            _input = new List<List<int>>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("DayEight." + fileName));
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                var lines = reader.ReadToEnd().Split(Environment.NewLine);
                foreach (var line in lines)
                {
                    var treeLine = line.Select(treeHeight => int.Parse(treeHeight.ToString())).ToList();
                    _input.Add(treeLine);
                }
            }
        }

        public int PartOne()
        {
            var totalVisibleTrees = 0;
            var numberOfTreeHorizontally = _input[0].Count();
            var numberOfTreesVertically = _input!.Count();

            for (var y = 0; y < numberOfTreesVertically; y++)
            for (var x = 0; x < numberOfTreeHorizontally; x++)
                if (x == 0 || y == 0 || x + 1 == numberOfTreeHorizontally || y + 1 == numberOfTreesVertically)
                {
                    totalVisibleTrees += 1;
                }
                else
                {
                    var currentTreeHeight = _input[y][x];
                    var treeHeightsLeft = _input[y].GetRange(0, x);
                    var treeHeightsRight =
                        _input[y].GetRange(x + 1, numberOfTreeHorizontally - treeHeightsLeft.Count() - 1);
                    var treeHeightsTop = _input.Where((a, inx) => inx < y).Select(b => b[x]).ToList();
                    var treeHeightsBottom = _input.Where((a, inx) => inx > y).Select(b => b[x]).ToList();

                    if (treeHeightsLeft.All(a => a < currentTreeHeight) ||
                        treeHeightsRight.All(a => a < currentTreeHeight) ||
                        treeHeightsTop.All(a => a < currentTreeHeight) ||
                        treeHeightsBottom.All(a => a < currentTreeHeight)
                       )
                    {
                        totalVisibleTrees += 1;
                    }
                }

            return totalVisibleTrees;
        }

        public int PartTwo()
        {
            var bestScenicScore = 0;
            var numberOfTreeHorizontally = _input[0].Count();
            var numberOfTreesVertically = _input!.Count();

            for (var y = 0; y < numberOfTreesVertically; y++)
            for (var x = 0; x < numberOfTreeHorizontally; x++)
            {
                var currentTreeHeight = _input[y][x];
                var treeHeightsLeft = _input[y].GetRange(0, x);
                treeHeightsLeft.Reverse();
                var treeHeightsRight =
                    _input[y].GetRange(x + 1, numberOfTreeHorizontally - treeHeightsLeft.Count() - 1);
                var treeHeightsTop = _input.Where((a, inx) => inx < y).Select(b => b[x]).ToList();
                treeHeightsTop.Reverse();
                var treeHeightsBottom = _input.Where((a, inx) => inx > y).Select(b => b[x]).ToList();

                var leftCount = 0;
                var rightCount = 0;
                var topCount = 0;
                var bottomCount = 0;

                foreach (var t in treeHeightsLeft)
                {
                    leftCount++;
                    if (t >= currentTreeHeight)
                    {
                        break;
                    }
                }

                foreach (var t in treeHeightsRight)
                {
                    rightCount++;
                    if (t >= currentTreeHeight)
                    {
                        break;
                    }
                }

                foreach (var t in treeHeightsTop)
                {
                    topCount++;
                    if (t >= currentTreeHeight)
                    {
                        break;
                    }
                }

                foreach (var t in treeHeightsBottom)
                {
                    bottomCount++;
                    if (t >= currentTreeHeight)
                    {
                        break;
                    }
                }

                var currentTreeScenicScore = leftCount * rightCount * topCount * bottomCount;

                if (currentTreeScenicScore > bestScenicScore)
                {
                    bestScenicScore = currentTreeScenicScore;
                }
            }

            return bestScenicScore;
        }
    }
}