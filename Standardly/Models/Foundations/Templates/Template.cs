// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;

namespace Standardly.Models.Foundations.Templates
{
    public class Template
    {
        /// <summary>
        /// Contains a serialised version of the template.
        /// </summary>
        public string RawTemplate { get; set; }

        /// <summary>
        /// Suggested singular name for the model used with this template. 
        /// This optional value will be used for things that does not have a custom model i.e.
        /// DateTimeBroker and LoggingBroker. If present, it will be used instead of any user sggested value.
        /// </summary>
        public string ModelSingularName { get; set; }

        /// <summary>
        /// Suggested plural name for the model used with this template.
        /// This optional value will be used for things that does not have a custom model i.e.
        /// DateTimeBroker and LoggingBroker. If present, it will be used instead of any user sggested value.
        /// </summary>
        public string ModelPluralName { get; set; }

        /// <summary>
        /// The name for the template.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A description of the template.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A value indicating to which organisation the template belongs to i.e. The Standard 
        /// </summary>
        public string Organisation { get; set; }

        /// <summary>
        /// A value indicating to which stack the template belongs to i.e. backend OR frontend
        /// </summary>
        public string Stack { get; set; }

        /// <summary>
        /// The coding language or framework that the template uses i.e. CSHARP, Blazor, React, Angular, Vue etc.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// The type of template i.e. Model, Broker, Foundation Service, Processing Service, Exposer, Acceptance 
        /// </summary>
        public string TemplateType { get; set; }

        /// <summary>
        /// A sort order that can be used to sort template types i.e.
        /// Models = 1
        /// Brokers = 2
        /// Foundation Services = 3
        /// Processing Services = 4
        /// Exposer / Controllers = 5
        /// Acceptance = 6
        /// Management Services = 7
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// The projects that needs to be in place for the templates to be generated i.e.
        /// - Api
        /// - Api.Tests.Unit
        /// - Api.Tests.Acceptance
        /// - Api.Infrastructure.Build
        /// - Api.Infrastructure.Provision
        /// - Web
        /// - Web.Tests.Unit
        /// - Web.Tests.Acceptance
        /// - Web.Infrastructure.Build
        /// - Web.Infrastructure.Provision
        /// </summary>
        public string ProjectsRequired { get; set; }

        /// <summary>
        /// All the tasks that needs to be completed to generate the template as a whole.
        /// </summary>
        public List<Task> Tasks { get; set; } = new List<Task>();

        /// <summary>
        /// A list of any manual tasks not currently handled by the template generation process.
        /// </summary>
        public List<string> CleanupTasks { get; set; } = new List<string>();

        /// <summary>
        /// A dictionary containing replacement values for template variables
        /// </summary>
        public Dictionary<string, string> ReplacementDictionary { get; set; } = new Dictionary<string, string>();
    }
}
