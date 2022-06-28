// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.IO;

namespace Standardly.Core.Brokers.FileSystems
{
    public class FileSystemBroker : IFileSystemBroker
    {
        public bool CheckIfFileExists(string path) =>
            File.Exists(path);

        public void WriteToFile(string path, string content) =>
            File.WriteAllText(path, content);

        public string ReadFile(string path) =>
            File.ReadAllText(path);

        public string[] GetListOfFiles(string path, string searchPattern = "*") =>
            Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);

        public bool CheckIfDirectoryExists(string path) =>
            Directory.Exists(path);

        public void CreateDirectory(string path) =>
            Directory.CreateDirectory(path);

        public void DeleteDirectory(string path, bool recursive = false) =>
            Directory.Delete(path, recursive);
    }
}
