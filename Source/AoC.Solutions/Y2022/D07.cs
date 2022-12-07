using System.Text.RegularExpressions;

namespace AoC.Solutions.Y2022
{
    public class D07 : AoCPuzzle
    {
        public D07() : base(2022, 07) { }

        private const int FilesystemSize = 70000000;
        private const int UpdateSize = 30000000;

        public override object SolvePuzzleA(string input)
        {
            Dictionary<string, Directory> data = InterpretInstructions(input);

            return FindTotalSizeofFolders(100000, data);
        }

        public override object SolvePuzzleB(string input)
        {
            Dictionary<string, Directory> data = InterpretInstructions(input);

            int sizeFree = FilesystemSize - data.Max(x => x.Value.Size);
            int sizeNeeded = sizeFree - UpdateSize;

            return FindFolderToGetEnoughSpace(data, -sizeNeeded);
        }


        private static int FindTotalSizeofFolders(int size, Dictionary<string, Directory> dictionary)
        {
            return dictionary.Where(row => row.Value.Size <= size).Sum(row => row.Value.Size);
        }

        private static int FindFolderToGetEnoughSpace(Dictionary<string, Directory> dictionary, int spaceNeeded)
        {
            List<Directory> candidates = new List<Directory>();
            foreach (KeyValuePair<string, Directory> data in dictionary)
            {
                if (data.Value.Size >= spaceNeeded)
                {
                    candidates.Add(data.Value);
                }
            }

            return candidates.Min(x => x.Size);
        }

        private static Dictionary<string, Directory> InterpretInstructions(string input)
        {
            string[] rows = input.Split("\r\n");

            Dictionary<string, Directory> treeDirectory = new();
            string currentPath = "";

            foreach (string r in rows)
            {
                string[] row = r.Split(" ");

                switch (row[0])
                {
                    case "$":
                        switch (row[1])
                        {
                            case "cd" when row[2] == "..":
                                currentPath = string.Join("/", currentPath.Split('/')[..^1]);
                                break;
                            case "cd":
                                {
                                    string newPath = currentPath + $"/{row[2]}";

                                    if (treeDirectory.ContainsKey(newPath))
                                    {
                                        continue;
                                    }

                                    Directory def = new(row[2]);

                                    if (treeDirectory.Count > 0)
                                        treeDirectory[currentPath].Contents.Add(def);

                                    treeDirectory.Add(newPath, def);


                                    currentPath = newPath;
                                    break;
                                }
                            case "ls":
                                break; //ignored
                        }

                        break;
                    case "dir":
                        break; //ignored
                    default:
                        treeDirectory[currentPath].Contents.Add(new File(row[1], int.Parse(row[0])));
                        break;
                }
            }

            return treeDirectory;
        }


        private interface IFileSystemEntry
        {
            string Name { get; set; }
        }

        private class File : IFileSystemEntry
        {
            public File(string name, int size)
            {
                Name = name;
                Size = size;
            }

            public string Name { get; set; }
            public int Size { get; set; }
        }

        private class Directory : IFileSystemEntry
        {
            public Directory(string name)
            {
                Name = name;
                Contents = new List<IFileSystemEntry>();
            }

            public string Name { get; set; }

            public List<IFileSystemEntry> Contents { get; init; }

            public int Size => GetSize(Contents);

        }


        private static int GetSize(List<IFileSystemEntry> input)
        {
            int size = 0;
            foreach (IFileSystemEntry row in input)
            {
                switch (row)
                {
                    case File file:
                        size += file.Size;
                        break;
                    case Directory directory:
                        size += GetSize(directory.Contents);
                        break;
                }
            }

            return size;
        }


    }
}

