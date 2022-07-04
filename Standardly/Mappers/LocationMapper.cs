// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Mappers
{
    public static class LocationMapper
    {
        public static Models.Settings.Location Map(Standardly.Locations data)
        {
            var model = new Models.Settings.Location()
            {
                BrokersFolder = data.BrokersFolder,
                ModelsFolder = data.ModelsFolder,
                ServicesFolder = data.ServicesFolder,
                FoundationServicesFolder = data.FoundationServicesFolder,
                ProcessingServicesFolder = data.ProcessingServicesFolder,
                OrchestrationServicesFolder = data.OrchestrationServicesFolder,
                CoordinationServicesFolder = data.CoordinationServicesFolder,
                ControllersFolder = data.ControllersFolder
            };

            return model;
        }
    }
}
