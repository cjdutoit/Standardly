// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Core.Brokers.FileSystems
{
    public interface IFileSystemBroker
    {
        bool CheckIfFileExists(string path);
        void WriteToFile(string path, string content);
        string ReadFile(string path);
    }
}
