﻿using FileManager.Enums;

namespace FileManager.Processors
{
    public static class DirectoryProcessor
    {

        public static string ResolvePath(string currentDir, string input)
        {
            string newPath;

            if (input == ConsoleOptions.UpOneLevel.ToString())
            {
                newPath = GetPreviousDirectory(currentDir);

                return CheckValidDirectory(currentDir, newPath);
            }

            if (input == ConsoleOptions.CurrentPath.ToString())
            {
                newPath = Directory.GetCurrentDirectory();

                return newPath;
            }

            if (input == ConsoleOptions.GoToRoot.ToString())
            {
                newPath = Path.GetPathRoot(Directory.GetCurrentDirectory());

                return newPath;
            }

            newPath = Path.Combine(currentDir, input);

            return CheckValidDirectory(currentDir, newPath);

        }

        private static string GetPreviousDirectory(string currentDir)
        {
            string newPath;
            string[] splitPath = currentDir.Split(Path.DirectorySeparatorChar).SkipLast(1).ToArray();
            newPath = string.Join(Path.DirectorySeparatorChar, splitPath);

            if (newPath == currentDir.Split(Path.DirectorySeparatorChar)[0])
            {
                newPath = string.Concat(newPath, Path.DirectorySeparatorChar);
            }

            return newPath;
        }

        private static string CheckValidDirectory(string currentDir, string newPath)
        {

            string errorMessage = "Invalid directory specified: " + newPath;

            if (Directory.Exists(newPath))
            {
                try
                {
                    Directory.GetDirectories(newPath);
                    return newPath;
                }
                catch
                {
                    errorMessage = "Cannot access path, check read permissions: " + newPath;
                }
            }

            Console.WriteLine(errorMessage);
            return currentDir;
        }
    }
}
