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
using Standardly.Core.Models.FileItems;
using Standardly.Core.Services.Foundations.TemplateServices;
using Standardly.Core.Services.Orchestrations.TemplateOrchestrations;
using Standardly.Models.Settings;
using Action = Standardly.Core.Models.Actions.Action;
using MessageBox = System.Windows.Forms.MessageBox;
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
            txtCopyright.Text = this.settings.General.Copyright.Replace("\n", Environment.NewLine);
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

        private (bool hasErrors, string message) HasFormValidationErrors()
        {
            bool hasErrors = false;
            StringBuilder message = new StringBuilder();

            txtGitHubBaseBranchName.BackColor = string.IsNullOrEmpty(txtGitHubBaseBranchName.Text)
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.White;

            txtGitHubUsername.BackColor = string.IsNullOrEmpty(txtGitHubUsername.Text)
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.White;

            txtModelSingularName.BackColor = string.IsNullOrEmpty(txtModelSingularName.Text)
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.White;

            txtModelPluralName.BackColor = string.IsNullOrEmpty(txtModelPluralName.Text) ||
                (!string.IsNullOrEmpty(txtModelPluralName.Text)
                        && txtModelSingularName.Text == txtModelPluralName.Text)
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.White;

            cbTemplates.BackColor = cbTemplates.SelectedItem == null
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.White;

            txtProject.BackColor = string.IsNullOrEmpty(txtProject.Text)
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.White;

            txtUnitTestProject.BackColor = string.IsNullOrEmpty(txtUnitTestProject.Text)
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.White;

            txtAcceptanceTestProject.BackColor = string.IsNullOrEmpty(txtAcceptanceTestProject.Text)
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.White;

            txtInfrastructureBuildProject.BackColor = string.IsNullOrEmpty(txtInfrastructureBuildProject.Text)
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.White;

            txtInfrastructureProvisionProject.BackColor = string.IsNullOrEmpty(txtInfrastructureProvisionProject.Text)
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.White;

            chkExperienceUsersOnly.BackColor = chkExperienceUsersOnly.Checked == false
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.Transparent;

            chkDisclaimer.BackColor = chkDisclaimer.Checked == false
                ? System.Drawing.Color.MistyRose
                : System.Drawing.Color.Transparent;

            if (string.IsNullOrEmpty(txtGitHubBaseBranchName.Text))
            {
                hasErrors = true;
                message.AppendLine($"GitHub Base Branch Name Required");
            }

            if (string.IsNullOrEmpty(txtGitHubUsername.Text))
            {
                hasErrors = true;
                message.AppendLine($"GitHub Username Required");
            }

            if (string.IsNullOrEmpty(txtModelSingularName.Text))
            {
                hasErrors = true;
                message.AppendLine($"Model Singular Name Required");
            }

            if (string.IsNullOrEmpty(txtModelPluralName.Text))
            {
                hasErrors = true;
                message.AppendLine($"Model Plural Name Required");
            }

            if (!string.IsNullOrEmpty(txtModelPluralName.Text)
                && txtModelSingularName.Text == txtModelPluralName.Text)
            {
                hasErrors = true;
                message.AppendLine($"Model Plural Name Should Not Match Singular Name");
            }

            if (cbTemplates.SelectedItem == null)
            {
                hasErrors = true;
                message.AppendLine($"Template Selection Required");
            }

            if (string.IsNullOrEmpty(txtProject.Text))
            {
                hasErrors = true;
                message.AppendLine($"Project Required");
            }

            if (string.IsNullOrEmpty(txtUnitTestProject.Text))
            {
                hasErrors = true;
                message.AppendLine($"Unit Test Project Required -> Exit and add an empty xUnit project with name " +
                    $"{txtProject.Text}.Tests.Unit to the solution.");
            }

            if (string.IsNullOrEmpty(txtAcceptanceTestProject.Text))
            {
                hasErrors = true;
                message.AppendLine($"Acceptance Test Project Required -> Exit and add an empty xUnit project with " +
                    $"name {txtProject.Text}.Tests.Acceptance to the solution.");
            }

            //if (string.IsNullOrEmpty(txtInfrastructureBuildProject.Text))
            //{
            //    hasErrors = true;
            //    message.AppendLine($"Infrastructure Build Project Required -> " +
            //        $"Exit and add an empty Console App project with name " +
            //        $"{txtProject.Text}.Infrastructure.Build to the solution.");
            //}

            //if (string.IsNullOrEmpty(txtInfrastructureProvisionProject.Text))
            //{
            //    hasErrors = true;
            //    message.AppendLine($"Infrastructure Provision Project Required -> " +
            //        $"Exit and add an empty Console App project with name " +
            //        $"{txtProject.Text}.Infrastructure.Provision to the solution.");
            //}

            if (chkExperienceUsersOnly.Checked == false || chkDisclaimer.Checked == false)
            {
                hasErrors = true;
                message.AppendLine($"Accept the disclaimer and acknowledge that you are an experienced developer");
            }

            txtMessage.Text = message.ToString();
            btnGenerateFromTemplate.Enabled = !hasErrors;

            return (hasErrors, message.ToString());
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

        }

        private void txtGitHubUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGitHubBaseBranchName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCopyright_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLicense_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerateFromTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                btnGenerateFromTemplate.Enabled = false;
                btnGenerateFromTemplate.Refresh();
                btnCancel.Enabled = false;

                (var hasErrors, var message) = HasFormValidationErrors();

                if (hasErrors == true)
                {
                    MessageBox.Show(
                        "Code Generation completed",
                        "The code generation has been completed.  " +
                            "Please complete the TODO actions and submit a Pull Request " +
                                "for each branch linked to the respective issues.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                this.GenerateCriteria.GitHubBaseBranchName = txtGitHubBaseBranchName.Text;
                this.GenerateCriteria.GitHubUsername = txtGitHubUsername.Text;
                this.GenerateCriteria.DisplayName = txtDisplayName.Text;
                this.GenerateCriteria.Copyright = txtCopyright.Text.Replace(Environment.NewLine, "##n##");
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

                Core.Models.Tasks.Task editorConfigTask = transformedConfigTemplate.Tasks
                    .FirstOrDefault(task => task.Name == "CONFIG: Add .editorconfig to solution");

                Core.Models.Tasks.Task gitIgnoreTask = transformedConfigTemplate.Tasks
                    .FirstOrDefault(task => task.Name == "CONFIG: Add .gitignore to solution");

                Core.Models.Tasks.Task licenseTask = transformedConfigTemplate.Tasks
                    .FirstOrDefault(task => task.Name == "CONFIG: Add license file to solution");

                if (!GenerateCriteria.AddEditorConfigFile)
                {
                    if (editorConfigTask != null)
                    {
                        GenerateCriteria.ConfigTemplate.Tasks.Remove(editorConfigTask);
                    }
                }
                else
                {
                    if (IsTaskRequired(editorConfigTask))
                    {
                        GenerateCriteria.ConfigTemplate.Tasks.Remove(editorConfigTask);
                    }
                }

                if (!GenerateCriteria.AddGitIgnoreFile)
                {

                    if (gitIgnoreTask != null)
                    {
                        GenerateCriteria.ConfigTemplate.Tasks.Remove(gitIgnoreTask);
                    }
                }
                else
                {
                    if (IsTaskRequired(gitIgnoreTask))
                    {
                        GenerateCriteria.ConfigTemplate.Tasks.Remove(gitIgnoreTask);
                    }
                }


                if (!GenerateCriteria.AddLicenseFile)
                {

                    if (licenseTask != null)
                    {
                        GenerateCriteria.ConfigTemplate.Tasks.Remove(licenseTask);
                    }
                }
                else
                {
                    if (IsTaskRequired(licenseTask))
                    {
                        GenerateCriteria.ConfigTemplate.Tasks.Remove(licenseTask);
                    }
                }

                if (transformedConfigTemplate.Tasks.Any())
                {
                    this.templateOrchestrationService
                        .GenerateCodeFromTemplate(transformedConfigTemplate, replacementsDictionary);
                }
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

        private static bool IsTaskRequired(Core.Models.Tasks.Task editorConfig)
        {
            List<FileItem> fileItems = new List<FileItem>();
            foreach (Action action in editorConfig.Actions)
            {
                fileItems.AddRange(fileItems);
            }

            foreach (FileItem fileItem in fileItems)
            {
                if (File.Exists(fileItem.Template) && fileItem.Replace == false)
                {
                    fileItems.Remove(fileItem);
                }
            }

            return !fileItems.Any();
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
