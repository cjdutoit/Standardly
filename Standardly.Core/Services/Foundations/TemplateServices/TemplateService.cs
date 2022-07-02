using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Standardly.Core.Models.Templates;

namespace Standardly.Core.Services.Foundations.TemplateServices
{
    public partial class TemplateService : ITemplateService
    {
        public string TransformString(string @string, Dictionary<string, string> replacementsDictionary) =>
            throw new NotImplementedException();

        public Template ConvertStringToTemplate(string @string) =>
            TryCatch(() =>
            {
                ValidateStringTemplateIsNotNull(@string);

                Template template = JsonConvert.DeserializeObject<Template>(@string);
                template.RawTemplate = @string;
                ValidateTemplate(template);

                return template;
            });
    }
}
