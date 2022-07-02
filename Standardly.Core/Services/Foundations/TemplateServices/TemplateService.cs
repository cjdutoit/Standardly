using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Standardly.Core.Models.Templates;

namespace Standardly.Core.Services.Foundations.TemplateServices
{
    public partial class TemplateService : ITemplateService
    {
        public string TransformString(string @string, Dictionary<string, string> replacementDictionary)
        {
            string template = @string;

            if (replacementDictionary.Any())
            {
                foreach (var replacement in replacementDictionary)
                {
                    template = template.Replace(replacement.Key, replacement.Value);
                }
            }

            return template;
        }

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
