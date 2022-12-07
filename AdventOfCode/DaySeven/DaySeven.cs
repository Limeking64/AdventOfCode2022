using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode.DaySeven
{
    public class DaySeven
    {
        private readonly Directory _input;

        public DaySeven(string fileName = "Input.txt")
        {
            _input = new Directory()
            {
                DirectoryName = "/"
            };
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("DaySeven." + fileName));
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var lines = reader.ReadToEnd().Split(Environment.NewLine);
                lines = lines.Skip(2).ToArray();

                var currentDirectory = _input;
                foreach (var line in lines)
                {
                    if (line[0] != '$')
                    {
                        if (line.Contains("dir"))
                        {
                            currentDirectory.Directories.Add(new Directory()
                            {
                                DirectoryName = line.Replace("dir ", ""),
                                ParentDirectory = currentDirectory
                            });
                            continue;
                        }

                        if (int.TryParse(line[0].ToString(), out var result))
                        {
                            var info = line.Split(" ");
                            currentDirectory.Files.Add(new File()
                            {
                                Size = long.Parse(info[0]),
                                Name = info[1]
                            });
                        }
                    }
                    else
                    {
                        if (line.Contains("cd"))
                        {
                            var targetDirectory = line.Replace("$ cd ", "");
                            currentDirectory = targetDirectory == ".."
                                ? currentDirectory.ParentDirectory
                                : currentDirectory.Directories.First(x =>
                                    x.DirectoryName == targetDirectory);
                            continue;
                        }

                        if (line.Contains("cd /"))
                        {
                            currentDirectory = _input;
                        }
                    }
                }
                SetDirectorySize(_input);
            }
        }

        public long PartOne()
        {
            const long maxFileSize = 100000;
            long totalSum = 0;
            GetSumOfDirectorySizeBelowLimit(_input, maxFileSize, ref totalSum);
            return totalSum;
        }

        public long PartTwo()
        {
            const long totalSpaceInSystem = 70000000;
            const long spaceNeededToUpdate = 30000000;
            var requiredSpace = spaceNeededToUpdate - (totalSpaceInSystem - _input.DirectorySize!.Value);
            var sizes = new List<long>();
            GetDirectorySizes(_input, ref sizes);

            return sizes.Where(x => x > requiredSpace).OrderBy(x => x).First();
        }

        private void GetDirectorySizes(Directory directory, ref List<long> sizes)
        {
            foreach (var subDirectory in directory.Directories)
            {
                GetDirectorySizes(subDirectory, ref sizes);
            }
            
            sizes.Add(directory.DirectorySize!.Value);
        }

        private void GetSumOfDirectorySizeBelowLimit(Directory directory, long sizeLimit, ref long totalSizeSum)
        {
            foreach (var subDirectory in directory.Directories)
            {
                GetSumOfDirectorySizeBelowLimit(subDirectory, sizeLimit, ref totalSizeSum);
            }

            if (directory.DirectorySize.HasValue && directory.DirectorySize.Value < sizeLimit)
            {
                totalSizeSum += directory.DirectorySize.Value;
            }
        }

        private void SetDirectorySize(Directory directory)
        {
            foreach (var subDirectory in directory.Directories.Where(x => x.DirectorySize == null))
            {
                SetDirectorySize(subDirectory);
            }
            
            directory.DirectorySize = directory.Files.Sum(x => x.Size) +
                                      directory.Directories.Sum(x => x.DirectorySize);
        }
    }
}