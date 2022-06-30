using System.Collections.Generic;
using Newtonsoft.Json;
using Standardly.Core.Models.FileItems;
using Standardly.Core.Models.PowerShellScripts;
using Standardly.Core.Models.Templates;
using Standardly.Core.Services.Foundations.TemplateServices;
using Tynamix.ObjectFiller;

namespace Standardly.Core.Tests.Unit.Services.Foundations.TemplateServices
{
    public partial class TemplateServiceTests
    {
        private readonly ITemplateService templateService;

        public TemplateServiceTests()
        {
            this.templateService = new TemplateService();
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 5).GetValue();

        private static string GetRandomString(int wordCount) =>
            new MnemonicString(wordCount: wordCount).GetValue();

        private static string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private static string SerializeTemplate(Template template)
        {
            return JsonConvert.SerializeObject(template);
        }

        private static List<PowerShellScript> CreateListOfPowerShellScripts()
        {
            List<PowerShellScript> list = new List<PowerShellScript>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new PowerShellScript()
                {
                    Name = GetRandomString(1),
                    Script = GetRandomString(1)
                });
            }

            return list;
        }

        private static List<FileItem> CreateListOfFileItems()
        {
            List<FileItem> list = new List<FileItem>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new FileItem()
                {
                    Template = GetRandomString(1),
                    Target = GetRandomString(1),
                    Replace = true
                });
            }

            return list;
        }

        private static List<Models.Actions.Action> CreateListOfActions()
        {
            List<Models.Actions.Action> list = new List<Models.Actions.Action>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new Models.Actions.Action()
                {
                    Name = GetRandomString(1),
                    ExecutionFolder = GetRandomString(1),
                    FileItems = CreateListOfFileItems(),
                    Scripts = CreateListOfPowerShellScripts()
                });
            }

            return list;
        }

        private static List<Models.Tasks.Task> CreateListOfTasks()
        {
            List<Models.Tasks.Task> list = new List<Models.Tasks.Task>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new Models.Tasks.Task()
                {
                    Name = GetRandomString(1),
                    Actions = CreateListOfActions()
                });
            }

            return list;
        }

        private static List<string> CreateListOfStrings()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(GetRandomString(1));
            }

            return list;
        }

        private static Template CreateRandomTemplate()
        {
            Template template = CreateTemplateFiller().Create();
            template.RawTemplate = SerializeTemplate(template);

            return template;
        }

        private static Filler<Template> CreateTemplateFiller()
        {
            var filler = new Filler<Template>();
            filler.Setup()
                .OnType<List<string>>().Use(CreateListOfStrings)
                .OnType<List<Models.Tasks.Task>>().Use(CreateListOfTasks);

            return filler;
        }
    }
}
