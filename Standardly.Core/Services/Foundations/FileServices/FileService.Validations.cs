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

        private static void ValidateInputs(string path, string content)
        {
            if (IsInvalid(path))
            {
                throw new InvalidFilePathException();
            }

            if (IsInvalid(content))
            {
                throw new InvalidFileContentException();
            }
        }

        private static void ValidateSearchInputs(string path, string searchPattern)
        {
            if (IsInvalid(path))
            {
                throw new InvalidFilePathException();
            }

            if (IsInvalid(searchPattern))
            {
                throw new InvalidFileSearchPatternException();
            }
        }

        private static bool IsInvalid(string @string) =>
            String.IsNullOrWhiteSpace(@string);
    }
}
