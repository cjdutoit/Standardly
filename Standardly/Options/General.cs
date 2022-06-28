// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Standardly
{
    internal partial class OptionsProvider
    {
        // Register the options with this attribute on your package class:
        // [ProvideOptionPage(typeof(OptionsProvider.GeneralOptions), "Standardly", "General", 0, 0, true, SupportsProfiles = true)]
        [ComVisible(true)]
        public class GeneralOptions : BaseOptionPage<General> { }
    }

    public class General : BaseOptionModel<General>
    {
        [Category("General")]
        [DisplayName("Default Base Branch Name")]
        [Description("The name of the \"base\" branch of your repository e.g. \"main\" or \"master\".")]
        public string DefaultBranchName { get; set; } = "main";

        [Category("General")]
        [DisplayName("Your GitHub Username")]
        [Description("Your GitHub username to be used for creating branches.")]
        public string GitHubUsername { get; set; } = "";

        [Category("General")]
        [DisplayName("Display Name")]
        [Description("Name and Surname to be used in things like copyright text.")]
        public string DisplayName { get; set; } = "";

        [Category("General")]
        [DisplayName("Copyright")]
        [Description("The copyright text to be added to to the .editorconfig file.")]
        public string Copyright { get; set; }
            = "---------------------------------------------------------------" + Environment.NewLine +
            "Copyright (c) $displayName$. All rights reserved." + Environment.NewLine +
            "Licensed under the MIT License." + Environment.NewLine +
            "See License.txt in the project root for license information." + Environment.NewLine +
            "---------------------------------------------------------------";

        [Category("General")]
        [DisplayName("License")]
        [Description("The license text to be added to the Solution")]
        public string License { get; set; }
            = "Copyright (c) $year$ $displayName$. All rights reserved." + Environment.NewLine + Environment.NewLine +
            "Material in this repository is made available under the following terms:" + Environment.NewLine +
            "  1. Code is licensed under the MIT license, reproduced below." + Environment.NewLine +
            "  2. Documentation is licensed under the Creative Commons Attribution 3.0 " +
            "United States (Unported) License." + Environment.NewLine +
            "     The text of the license can be found here: http://creativecommons.org/licenses/by/3.0/legalcode" +
            Environment.NewLine + Environment.NewLine +

            "The MIT License (MIT)" + Environment.NewLine + Environment.NewLine +

            "Permission is hereby granted, free of charge, to any person obtaining a copy of this software and"
            + Environment.NewLine +
            "associated documentation files (the \"Software\"), to deal in the Software without restriction,"
            + Environment.NewLine +
            "including without limitation the rights to use, copy, modify, merge, publish, distribute,"
            + Environment.NewLine +
            "sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is "
            + Environment.NewLine +
            "furnished to do so, subject to the following conditions:"
            + Environment.NewLine + Environment.NewLine +

            "The above copyright notice and this permission notice shall be included in all copies or substantial"
            + Environment.NewLine +
            "portions of the Software." + Environment.NewLine + Environment.NewLine +

            "THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT"
            + Environment.NewLine +
            "NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND"
            + Environment.NewLine +
            "NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES"
            + Environment.NewLine +
            "OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN"
            + Environment.NewLine +
            "CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.";

        [Category("General")]
        [DisplayName("Add EditorConfig File")]
        [Description("Adds the .editorconfig file to the Solution if selected and the file is not already present")]
        [DefaultValue(true)]
        public bool AddEditorConfigFileIfNotPresent { get; set; } = true;

        [Category("General")]
        [DisplayName("Add GitIgnore File")]
        [Description("Adds the .gitignore file to the Solution if selected and the file is not already present")]
        [DefaultValue(true)]
        public bool AddGitIgnoreFileIfNotPresent { get; set; } = true;

        [Category("General")]
        [DisplayName("Add EditorConfig File")]
        [Description("Adds a license file to the Solution if selected and the file is not already present")]
        [DefaultValue(true)]
        public bool AddLicenseFileIfNotPresent { get; set; } = true;
    }
}
