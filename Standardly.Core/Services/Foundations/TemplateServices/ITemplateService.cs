using Standardly.Core.Models.Templates;

namespace Standardly.Core.Services.Foundations.TemplateServices
{
    public interface ITemplateService
    {
        Template ConvertStringToTemplate(string rawFile);
    }
}
