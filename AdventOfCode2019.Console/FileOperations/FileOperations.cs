using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Console.FileOperations
{
    public static class FileOperations
    {
        public static string ReadFileAsString(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public static IEnumerable<int> ReadFileAsCollection(string fileName)
        {
            string inputFileContents = ReadFileAsString(fileName);
            IEnumerable<int> moduleMasses = inputFileContents
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            return moduleMasses;
        }
    }
}