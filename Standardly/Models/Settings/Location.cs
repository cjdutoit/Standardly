// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Models.Settings
{
    public class Location
    {
        public string BrokersFolder { get; set; } = "Brokers";

        public string ModelsFolder { get; set; } = "Models";

        public string ServicesFolder { get; set; } = "Services";

        public string FoundationServicesFolder { get; set; } = "Foundations";

        public string ProcessingServicesFolder { get; set; } = "Processings";

        public string OrchestrationServicesFolder { get; set; } = "Orchestrations";

        public string CoordinationServicesFolder { get; set; } = "Coordinations";

        public string ControllersFolder { get; set; } = "Controllers";
    }
}
