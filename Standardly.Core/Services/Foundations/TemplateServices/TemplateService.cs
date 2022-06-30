using Newtonsoft.Json;
using Standardly.Core.Models.Templates;

namespace Standardly.Core.Services.Foundations.TemplateServices
{
    public partial class TemplateService : ITemplateService
    {
        public Template ConvertStringToTemplate(string stringTemplate) =>
            TryCatch(() =>
            {
                Template template = JsonConvert.DeserializeObject<Template>(stringTemplate);
                template.RawTemplate = stringTemplate;
                ValidateTemplate(template);

                return template;
            });
    }
}
