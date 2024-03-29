﻿namespace FileManager.Processors
{
    public static class FileProcessor
    {

        public static string ResolveFile(string directory, string file)
        {
            string filePath = Path.Combine(directory, file);

            if (File.Exists(filePath))
            {
                return filePath;
            }

            return null;
        }

        public static string ResolveFilePath(string filePath)
        {
            if (File.Exists(filePath))
            {
                return filePath;
            }

            return null;
        }

        public static List<string> GetFilesByExtensions(string currentDir, List<string> extensions)
        {
            string[] files = Directory.GetFiles(currentDir);

            List<string> matchingFiles = new List<string>();

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file);

                if (extensions.Contains(extension))
                {
                    matchingFiles.Add(file);
                }
            }

            return matchingFiles;
        }
    }
}
