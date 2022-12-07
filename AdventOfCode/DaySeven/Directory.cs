using System.Collections.Generic;

namespace AdventOfCode.DaySeven
{
    public class Directory
    {
        public string DirectoryName { get; set; }

        public List<File> Files { get; set; }

        public List<Directory> Directories { get; set; }

        public Directory ParentDirectory{ get; set; }

        public long? DirectorySize { get; set; }

        public Directory()
        {
            Files = new List<File>();
            Directories = new List<Directory>();
            DirectorySize = null;
        }
    }
}