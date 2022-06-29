using System;
using Standardly.Core.Models.FileServices.Exceptions;

namespace Standardly.Core.Services.Foundations.FileServices
{
    public partial class FileService
    {
        private static void ValidatePath(string path)
        {
            if (IsInvalid(path))
            {
                throw new InvalidFilePathException();
            }
        }

        private static bool IsInvalid(string @string) =>
            String.IsNullOrWhiteSpace(@string);
    }
}
