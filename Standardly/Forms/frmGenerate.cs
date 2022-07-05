// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Standardly.Core.Services.Foundations.TemplateServices;
using Standardly.Core.Services.Orchestrations.TemplateOrchestrations;
using Standardly.Models.Settings;
using Template = Standardly.Core.Models.Templates.Template;

namespace Standardly.Forms
{
    public partial class frmGenerate : Form
    {
        public bool Cancelled = false;
        private readonly ITemplateService templateService;
        private readonly ITemplateOrchestrationService templateOrchestrationService;
        private readonly Setting settings;
        private List<Template> templates;
        private BindingSource templateBindingSource;

        public GenerateCriteria GenerateCriteria { get; private set; }

        public frmGenerate(
            Setting settings,
            ITemplateService templateService,
            ITemplateOrchestrationService templateOrchestrationService)
        {
            this.settings = settings;
            this.GenerateCriteria = new GenerateCriteria();
            this.templateService = templateService;
            this.templateOrchestrationService = templateOrchestrationService;
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            txtGitHubBaseBranchName.Text = this.settings.General.DefaultBranchName;
            txtGitHubUsername.Text = this.settings.General.GitHubUsername;
            txtDisplayName.Text = this.settings.General.DisplayName;
            txtCopyright.Text = this.settings.General.Copyright;
            txtLicense.Text = this.settings.General.License;
            txtProject.Text = this.settings.ProjectInfo.ProjectName;
            txtUnitTestProject.Text = this.settings.ProjectInfo.UnitTestProjectName;
            txtAcceptanceTestProject.Text = this.settings.ProjectInfo.AcceptanceTestProjectName;
            txtInfrastructureBuildProject.Text = this.settings.ProjectInfo.InfrastructureBuildProjectName;
            txtInfrastructureProvisionProject.Text = this.settings.ProjectInfo.InfrastructureProvisionProjectName;
            chkEditorConfig.Checked = this.settings.General.AddEditorConfigFileIfNotPresent;
            chkGitIgnore.Checked = this.settings.General.AddGitIgnoreFileIfNotPresent;
            chkLicense.Checked = this.settings.General.AddLicenseFileIfNotPresent;

            BindTemplates();
        }

        private void BindTemplates()
        {
            try
            {
                this.templates = this.templateOrchestrationService.FindAllTemplates();

                List<Template> templateOptions = templates.ToList();

                if (!string.IsNullOrEmpty(txtTemplateSearch.Text))
                {
                    templateOptions = templateOptions
                        .Where(template => template.Name
                            .IndexOf(txtTemplateSearch.Text, StringComparison.InvariantCultureIgnoreCase) != -1)
                        .ToList();
                }

                if (cbTemplateType.SelectedItem != null && cbTemplateType.SelectedItem.ToString().ToLower() != "all")
                {
                    templateOptions = templateOptions
                        .Where(template =>
                            template.TemplateType
                                .Equals(
                                    cbTemplateType.SelectedItem.ToString(),
                                    StringComparison.InvariantCultureIgnoreCase)).ToList();
                }

                templateOptions = templateOptions
                    .OrderBy(template => template.SortOrder)
                    .ThenBy(template => template.Name)
                    .ToList();

                this.templateBindingSource = new BindingSource();
                templateBindingSource.DataSource = templateOptions;

                cbTemplates.DisplayMember = "Name";
                cbTemplates.ValueMember = "Name";
                cbTemplates.DataSource = templateBindingSource.DataSource;
                cbTemplates.Text = String.Empty;

                if (templateOptions.Count > 0)
                {
                    cbTemplates.SelectedValue = cbTemplates.Items[0];
                    cbTemplates.SelectedItem = cbTemplates.Items[0];
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        private void ValidateInput(Control control, bool condition, string error, StringBuilder errors)
        {
            control.BackColor = condition
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.White;

            if (condition == true)
            {
                errors.AppendLine(error);
            }
        }

        private void HasFormValidationErrors()
        {
            List<string> requiredProjects = new List<string>();

            if (cbTemplates.SelectedItem != null)
            {
                requiredProjects.AddRange(((Template)cbTemplates.SelectedItem)
                .ProjectsRequired.ToLower()
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList());
            }

            StringBuilder errors = new StringBuilder();

            ValidateInput(
                txtGitHubBaseBranchName,
                string.IsNullOrEmpty(txtGitHubBaseBranchName.Text),
                "* GitHub Base Branch Name Required",
                errors);

            ValidateInput(
               txtDisplayName,
               string.IsNullOrEmpty(txtDisplayName.Text),
               "* Display Name Required",
               errors);

            ValidateInput(
               txtGitHubUsername,
               string.IsNullOrEmpty(txtGitHubUsername.Text),
               "* GitHub Username Required",
               errors);

            ValidateInput(
                txtCopyright,
                chkEditorConfig.Checked == true && string.IsNullOrEmpty(txtCopyright.Text),
                "* GitHub Username Required",
                errors);

            ValidateInput(
                txtLicense,
                chkLicense.Checked == true && string.IsNullOrEmpty(txtLicense.Text),
                "* GitHub Username Required",
                errors);

            ValidateInput(
               txtModelSingularName,
               string.IsNullOrEmpty(txtModelSingularName.Text),
               "* Model Singular Name Required",
               errors);

            ValidateInput(
               txtModelPluralName,
               string.IsNullOrEmpty(txtModelPluralName.Text) || txtModelSingularName.Text == txtModelPluralName.Text,
               "* Model Plural Name Required And Should Not Be The Same As The Singular Name",
               errors);

            ValidateInput(
               cbTemplates,
               cbTemplates.SelectedItem == null,
               "* Template Selection Required",
               errors);

            ValidateInput(
               txtProject,
               string.IsNullOrEmpty(txtProject.Text) &&
               (requiredProjects.Contains("main")
                || requiredProjects.Contains("api")
                    || requiredProjects.Contains("portal")),
               "* Project Required",
               errors);

            ValidateInput(
                txtUnitTestProject,
                string.IsNullOrEmpty(txtUnitTestProject.Text) && requiredProjects.Contains("unit"),
                $"* Unit Test Project Required -> " +
                    $"Add a xUnit project with name '{txtProject.Text}.Tests.Unit' to the solution.",
               errors);

            ValidateInput(
                txtAcceptanceTestProject,
                string.IsNullOrEmpty(txtAcceptanceTestProject.Text) && requiredProjects.Contains("acceptance"),
                $"* Acceptance Test Project Required -> " +
                    $"Add a xUnit project with name '{txtProject.Text}.Tests.Acceptance' to the solution.",
               errors);

            ValidateInput(
                txtInfrastructureBuildProject,
                string.IsNullOrEmpty(txtInfrastructureBuildProject.Text) && requiredProjects.Contains("build"),
                $"* Infrastructure Build Project Required -> " +
                    $"Add a console project with name '{txtProject.Text}.Infrastructure.Build' to the solution.",
               errors);

            ValidateInput(
                txtInfrastructureProvisionProject,
                string.IsNullOrEmpty(txtInfrastructureProvisionProject.Text) && requiredProjects.Contains("provision"),
                $"* Infrastructure Provision Project Required -> " +
                    $"Add a console project with name '{txtProject.Text}.Infrastructure.Provision' to the solution.",
               errors);

            ValidateInput(
               chkExperienceUsersOnly,
               chkExperienceUsersOnly.Checked == false,
               "* Acknowledge that you are an experienced developer and that this will NOT limit your learning potential",
               errors);

            ValidateInput(
               chkDisclaimer,
               chkDisclaimer.Checked == false,
               "* Accept the disclaimer",
               errors);

            txtMessage.Text = errors.ToString();
            btnGenerateFromTemplate.Enabled = errors.Length == 0;
        }



        private void txtTemplateSearch_TextChanged(object sender, EventArgs e)
        {
            BindTemplates();
        }

        private void cbTemplateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTemplates();
        }

        private void cbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            HasFormValidationErrors();

            bool modelNamePresent = !string.IsNullOrEmpty(((Template)cbTemplates.SelectedItem)?.ModelSingularName);
            txtModelSingularName.ReadOnly = modelNamePresent;
            txtModelPluralName.ReadOnly = modelNamePresent;

            if (modelNamePresent)
            {
                txtModelSingularName.Text = ((Template)cbTemplates.SelectedItem).ModelSingularName;
                txtModelPluralName.Text = ((Template)cbTemplates.SelectedItem).ModelPluralName;
            }
            else
            {
                txtModelSingularName.Text = string.Empty;
                txtModelPluralName.Text = string.Empty;
            }
        }

        private void txtModelSingularName_TextChanged(object sender, EventArgs e)
        {
            HasFormValidationErrors();
        }

        private void txtModelPluralName_TextChanged(object sender, EventArgs e)
        {
            HasFormValidationErrors();
        }

        private void chkExperienceUsersOnly_CheckedChanged(object sender, EventArgs e)
        {
            HasFormValidationErrors();
        }

        private void chkDisclaimer_CheckedChanged(object sender, EventArgs e)
        {
            HasFormValidationErrors();
        }

        private void txtDisplayName_TextChanged(object sender, EventArgs e)
        {
            HasFormValidationErrors();
        }

        private void txtGitHubUsername_TextChanged(object sender, EventArgs e)
        {
            HasFormValidationErrors();
        }

        private void txtGitHubBaseBranchName_TextChanged(object sender, EventArgs e)
        {
            HasFormValidationErrors();
        }

        private void txtCopyright_TextChanged(object sender, EventArgs e)
        {
            HasFormValidationErrors();
        }

        private void txtLicense_TextChanged(object sender, EventArgs e)
        {
            HasFormValidationErrors();
        }

        private void btnGenerateFromTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                btnGenerateFromTemplate.Enabled = false;
                btnCancel.Enabled = false;

                this.GenerateCriteria.GitHubBaseBranchName = txtGitHubBaseBranchName.Text;
                this.GenerateCriteria.GitHubUsername = txtGitHubUsername.Text;
                this.GenerateCriteria.DisplayName = txtDisplayName.Text;

                this.GenerateCriteria.Copyright = txtCopyright.Text
                    .Replace("\r", "")
                    .Replace("\n", "\\n");

                this.GenerateCriteria.License = txtLicense.Text;

                this.GenerateCriteria.Template = this.templates
                    .FirstOrDefault(template => template.Name == ((Template)cbTemplates.SelectedItem).Name);

                this.GenerateCriteria.ConfigTemplate = this.templates
                    .FirstOrDefault(template => template.Name == "CONFIG: Solution Configuration Settings");

                this.GenerateCriteria.NameSingular = txtModelSingularName.Text;
                this.GenerateCriteria.NamePlural = txtModelPluralName.Text;
                this.GenerateCriteria.RootNameSpace = txtProject.Text;
                this.GenerateCriteria.AddEditorConfigFile = chkEditorConfig.Checked;
                this.GenerateCriteria.AddGitIgnoreFile = chkGitIgnore.Checked;
                this.GenerateCriteria.AddLicenseFile = chkLicense.Checked;

                GenerateCode();
            }
            catch (Exception ex)
            {
                btnGenerateFromTemplate.Enabled = true;
                btnCancel.Enabled = true;
                throw ex.InnerException ?? ex;
            }

            btnGenerateFromTemplate.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancelled = true;
            this.Close();
        }

        private void GenerateCode()
        {
            Dictionary<string, string> replacementsDictionary = new Dictionary<string, string>();
            GetReplacementDictionary(replacementsDictionary);

            if (GenerateCriteria.ConfigTemplate != null &&
                GenerateCriteria.Template.Name != GenerateCriteria.ConfigTemplate.Name)
            {
                string rawTransformedConfigTemplate = this.templateService
                    .TransformString(GenerateCriteria.ConfigTemplate.RawTemplate, replacementsDictionary);

                this.templateService.ValidateTransformation(rawTransformedConfigTemplate);

                Template transformedConfigTemplate = this.templateService
                    .ConvertStringToTemplate(rawTransformedConfigTemplate);

                this.templateService.ValidateSourceFiles(transformedConfigTemplate);

                if (!GenerateCriteria.AddEditorConfigFile)
                {
                    Core.Models.Tasks.Task editorConfig = transformedConfigTemplate.Tasks
                        .FirstOrDefault(task => task.Name == "CONFIG: Add .editorconfig to solution");

                    if (editorConfig != null)
                    {
                        GenerateCriteria.ConfigTemplate.Tasks.Remove(editorConfig);
                    }
                }

                if (!GenerateCriteria.AddGitIgnoreFile)
                {
                    Core.Models.Tasks.Task gitIgnore = transformedConfigTemplate.Tasks
                        .FirstOrDefault(task => task.Name == "CONFIG: Add .gitignore to solution");

                    if (gitIgnore != null)
                    {
                        GenerateCriteria.ConfigTemplate.Tasks.Remove(gitIgnore);
                    }
                }
                if (!GenerateCriteria.AddLicenseFile)
                {
                    Core.Models.Tasks.Task license = transformedConfigTemplate.Tasks
                        .FirstOrDefault(task => task.Name == "CONFIG: Add license file to solution");

                    if (license != null)
                    {
                        GenerateCriteria.ConfigTemplate.Tasks.Remove(license);
                    }
                }

                this.templateOrchestrationService
                    .GenerateCodeFromTemplate(transformedConfigTemplate, replacementsDictionary);
            }

            string rawTransformedTemplate = this.templateService
                .TransformString(GenerateCriteria.Template.RawTemplate, replacementsDictionary);

            this.templateService.ValidateTransformation(rawTransformedTemplate);

            Template transformedTemplate = this.templateService
                .ConvertStringToTemplate(rawTransformedTemplate);

            this.templateService.ValidateSourceFiles(transformedTemplate);

            this.templateOrchestrationService
                .GenerateCodeFromTemplate(transformedTemplate, replacementsDictionary);

            StringBuilder cleanupTaskMessage = new StringBuilder();
            cleanupTaskMessage.AppendLine("The code generation has been completed.  " +
                "Please complete / review the following cleanup tasks:");

            foreach (string task in transformedTemplate.CleanupTasks)
            {
                cleanupTaskMessage.AppendLine(task);
            }

            txtMessage.Text = cleanupTaskMessage.ToString();
        }

        private void GetReplacementDictionary(Dictionary<string, string> replacementsDictionary)
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            string templateFolder = Path.Combine(Path.GetDirectoryName(assembly), "Templates");
            var parameterSafeItemNameSingular = PrivatePropertyName(GenerateCriteria.NameSingular);
            var parameterSafeItemNamePlural = PrivatePropertyName(GenerateCriteria.NamePlural);
            var lowerDescriptionName = DescriptionPropertyName(GenerateCriteria.NameSingular);
            var upperDescriptionName = UpperDescriptionPropertyName(GenerateCriteria.NameSingular);
            var lowerPluralDescriptionName = DescriptionPropertyName(GenerateCriteria.NamePlural);
            var upperPluralDescriptionName = UpperDescriptionPropertyName(GenerateCriteria.NamePlural);
            replacementsDictionary.Add("$basebranch$", GenerateCriteria.GitHubBaseBranchName);
            replacementsDictionary.Add("$rootnamespace$", GenerateCriteria.RootNameSpace);
            replacementsDictionary.Add("$safeitemname$", GenerateCriteria.NameSingular);
            replacementsDictionary.Add("$safeItemNameSingular$", GenerateCriteria.NameSingular);
            replacementsDictionary.Add("$safeItemNamePlural$", GenerateCriteria.NamePlural);
            replacementsDictionary.Add("$parameterSafeItemNameSingular$", parameterSafeItemNameSingular);
            replacementsDictionary.Add("$parameterSafeItemNamePlural$", parameterSafeItemNamePlural);
            replacementsDictionary.Add("$lowerDescriptionName$", lowerDescriptionName);
            replacementsDictionary.Add("$upperDescriptionName$", upperDescriptionName);
            replacementsDictionary.Add("$lowerPluralDescriptionName$", lowerPluralDescriptionName);
            replacementsDictionary.Add("$upperPluralDescriptionName$", upperPluralDescriptionName);
            replacementsDictionary.Add("$solutionFolder$", settings.ProjectInfo.SolutionFolder.Replace("\\", "\\\\"));
            replacementsDictionary.Add("$templateFolder$", templateFolder.Replace("\\", "\\\\"));
            replacementsDictionary.Add("$projectName$", settings.ProjectInfo.ProjectName);
            replacementsDictionary.Add("$projectFolder$", settings.ProjectInfo.ProjectFolder.Replace("\\", "\\\\"));
            replacementsDictionary.Add("$unitTestProjectName$", settings.ProjectInfo.UnitTestProjectName);

            replacementsDictionary.Add(
                "$unitTestProjectFolder$",
                settings.ProjectInfo.UnitTestProjectFolder.Replace("\\", "\\\\"));

            replacementsDictionary.Add(
                "$acceptanceTestProjectName$",
                settings.ProjectInfo.AcceptanceTestProjectName);

            replacementsDictionary.Add(
                "$acceptanceTestProjectFolder$",
                settings.ProjectInfo.AcceptanceTestProjectFolder.Replace("\\", "\\\\"));

            replacementsDictionary.Add(
                "$infrastructureBuildProjectName$",
                settings.ProjectInfo.InfrastructureBuildProjectName);

            replacementsDictionary.Add(
                "$infrastructureBuildProjectFolder$",
                settings.ProjectInfo.InfrastructureBuildProjectFolder.Replace("\\", "\\\\"));

            replacementsDictionary.Add(
                "$infrastructureProvisionProjectName$",
                settings.ProjectInfo.InfrastructureProvisionProjectName);

            replacementsDictionary.Add(
                "$infrastructureProvisionProjectFolder$",
                settings.ProjectInfo.InfrastructureProvisionProjectFolder.Replace("\\", "\\\\"));

            replacementsDictionary.Add("$displayName$", GenerateCriteria.DisplayName);
            replacementsDictionary.Add("$username$", GenerateCriteria.GitHubUsername);
            replacementsDictionary.Add("$brokers$", settings.Location.BrokersFolder);
            replacementsDictionary.Add("$models$", settings.Location.ModelsFolder);
            replacementsDictionary.Add("$services$", settings.Location.ServicesFolder);
            replacementsDictionary.Add("$foundations$", settings.Location.FoundationServicesFolder);
            replacementsDictionary.Add("$processings$", settings.Location.ProcessingServicesFolder);
            replacementsDictionary.Add("$orchestrations$", settings.Location.OrchestrationServicesFolder);
            replacementsDictionary.Add("$coordinations$", settings.Location.CoordinationServicesFolder);
            replacementsDictionary.Add("$controllers$", settings.Location.ControllersFolder);
            replacementsDictionary.Add("$year$", DateTime.Now.Year.ToString());


            string copyrightText = this.templateService
                .TransformString(GenerateCriteria.Copyright, replacementsDictionary);

            string licenseText = this.templateService
                .TransformString(GenerateCriteria.License, replacementsDictionary);

            replacementsDictionary.Add("$copyright$", copyrightText);
            replacementsDictionary.Add("$license$", licenseText);
        }

        private static string PrivatePropertyName(string input)
        {
            var words = SplitCamelCase(input);
            string result = string.Join("", words);

            if (string.IsNullOrEmpty(result) || char.IsLower(result[0]))
                return result;

            return char.ToLower(result[0]) + result.Substring(1);
        }

        private static string DescriptionPropertyName(string input)
        {
            var words = SplitCamelCase(input);
            string result = string.Join(" ", words);

            if (string.IsNullOrEmpty(result))
                return result;

            return result.ToLower();
        }

        private static string UpperDescriptionPropertyName(string input)
        {
            var words = SplitCamelCase(input);
            string result = string.Join(" ", words);

            if (string.IsNullOrEmpty(result))
                return result;

            return char.ToUpper(result[0]) + result.Substring(1).ToLower();
        }

        private static IEnumerable<string> SplitCamelCase(string input)
        {
            string[] words = Regex.Matches(input, "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)")
                                    .OfType<Match>()
                                    .Select(m => m.Value)
                                    .ToArray();

            return words;
        }
    }
}
