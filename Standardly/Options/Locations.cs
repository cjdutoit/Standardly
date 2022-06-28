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
        // [ProvideOptionPage(typeof(OptionsProvider.LocationsOptions), "Standardly", "Locations", 0, 0, true, SupportsProfiles = true)]
        [ComVisible(true)]
        public class LocationsOptions : BaseOptionPage<Locations> { }
    }

    public class Locations : BaseOptionModel<Locations>
    {
        [Category("Locations")]
        [DisplayName("Brokers Folder")]
        [Description("The folder name where the generated brokers will be added to e.g. \\%brokers%")]
        [DefaultValue("Brokers")]
        public string BrokersFolder { get; set; } = "Brokers";

        [Category("Locations")]
        [DisplayName("Models Folder")]
        [Description("The folder name where the generated models will be added to e.g. \\%models%")]
        [DefaultValue("Models")]
        public string ModelsFolder { get; set; } = "Models";

        [Category("Locations")]
        [DisplayName("Services Folder")]
        [Description("The folder name where services will be grouped to e.g. \\%services%")]
        [DefaultValue("Services")]
        public string ServicesFolder { get; set; } = "Services";

        [Category("Locations")]
        [DisplayName("Foundation Services Folder")]
        [Description("The folder path where the generated foundation services will be added to e.g. \\%services%\\%foundations%")]
        [DefaultValue("Foundations")]
        public string FoundationServicesFolder { get; set; } = "Foundations";

        [Category("Locations")]
        [DisplayName("Processing Services Folder")]
        [Description("The folder path where the generated processing services will be added to e.g. \\%services%\\%processings%")]
        [DefaultValue("Processings")]
        public string ProcessingServicesFolder { get; set; } = "Processings";

        [Category("Locations")]
        [DisplayName("Orchestration Services Folder")]
        [Description("The folder path where the generated orchestration services will be added to e.g. \\%services%\\%orchestrations%")]
        [DefaultValue("Orchestrations")]
        public string OrchestrationServicesFolder { get; set; } = "Orchestrations";

        [Category("Locations")]
        [DisplayName("Coordination Services Folder")]
        [Description("The folder path where the generated coordination services will be added to e.g. \\%services%\\%coordinations%")]
        [DefaultValue("Coordinations")]
        public string CoordinationServicesFolder { get; set; } = "Coordinations";

        [Category("Locations")]
        [DisplayName("Controllers Folder")]
        [Description("The folder path where the generated controllers will be added to e.g. \\%controllers%")]
        [DefaultValue("Controllers")]
        public string ControllersFolder { get; set; } = "Controllers";
    }
}
