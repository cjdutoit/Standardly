// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.models.configurations
{
    internal class General
    {
        public bool addEditorConfigFile { get; set; }
        public bool addGitIgnoreFile { get; set; }
        public bool addGitAttributesFile { get; set; }
        public bool addReadmeFile { get; set; }
        public bool addLicenseFile { get; set; }
        public string LicenseType { get; set; }
    }
}
