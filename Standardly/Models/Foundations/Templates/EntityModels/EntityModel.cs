// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Models.Foundations.Templates.EntityModels
{
    public class EntityModel
    {
        public string PropertyType { get; set; }
        public string PropertyName { get; set; }
        public bool Required { get; set; }
        public bool KeyProperty { get; set; }
        public bool AuditProperty { get; set; }
    }
}
