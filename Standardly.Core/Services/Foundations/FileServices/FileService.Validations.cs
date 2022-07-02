// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

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
                throw new InvalidFilePathException(path);
            }
        }

        private static void ValidateInputs(string path, string content)
        {
            if (IsInvalid(path))
            {
                throw new InvalidFilePathException(path);
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
                throw new InvalidFilePathException(path);
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
