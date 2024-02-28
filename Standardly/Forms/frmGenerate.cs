﻿// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Standardly.Models.Foundations.Templates;
using Standardly.Models.Settings;
using Standardly.Services.Foundations.Templates;

namespace Standardly.Forms
{
    internal partial class frmGenerate : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        OutputWindowPane standardlyPane;
        OutputWindowPane standardlyDebugPane;

        public string OutputMessage { get; private set; }
        public GenerateCriteria GenerateCriteria { get; private set; }
        public bool Cancelled = false;
        private readonly ITemplateService templateService;
        private readonly Setting settings;
        private List<Template> templates;
        private BindingSource templateBindingSource;

        ValueTask ProcessedEventHandler(TemplateGenerationInfo data)
        {
            txtMessage.Text =
                txtMessage.Text + Environment.NewLine +
                $"{data.Processed.TimeStamp.ToString("HH:mm:ss")} - " +
                $"{data.Processed.ProcessedItems}/{data.Processed.TotalItems} - {data.Processed.Message}";

            return new ValueTask();
        }

        public frmGenerate(
            Setting settings,
            ITemplateService templateService)
        {
            this.settings = settings;
            this.GenerateCriteria = new GenerateCriteria();
            this.templateService = templateService;
            InitializeComponent();
            InitializeControls().GetAwaiter().GetResult();
        }

        private async ValueTask InitializeControls()
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
            chkExperienceUsersOnly.Checked = this.settings.General.AcceptWarningMessage;
            chkDisclaimer.Checked = this.settings.General.AcceptDisclaimer;
            await BindTemplates();
            this.templateService.SubscribeToProcessedEvent(ProcessedEventHandler);
        }

        private async ValueTask BindTemplates()
        {
            try
            {
                this.templates = (await this.templateService.FindAllTemplatesAsync()).Templates;
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

        private async Task UseOutputWindowAsync(string message, string windowTitle, OutputWindowPane pane)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            if (pane is null)
            {
                pane = await VS.Windows.CreateOutputWindowPaneAsync(windowTitle);
            }

            await pane.ActivateAsync();

            await pane.WriteLineAsync($"{message}\n\n");
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
               "* Acknowledge the use of CLI commands / powershell scripts and acceptance of the license/disclaimer",
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
                btnGenerateFromTemplate.Refresh();
                btnCancel.Enabled = false;

                this.GenerateCriteria.GitHubBaseBranchName = txtGitHubBaseBranchName.Text;
                this.GenerateCriteria.GitHubUsername = txtGitHubUsername.Text;
                this.GenerateCriteria.DisplayName = txtDisplayName.Text;
                this.GenerateCriteria.License = txtLicense.Text;

                this.GenerateCriteria.Copyright = txtCopyright.Text
                    .Replace("\r", "")
                    .Replace("\n", "##n##");

                this.GenerateCriteria.Template = this.templates
                    .FirstOrDefault(template => template.Name == ((Template)cbTemplates.SelectedItem).Name);

                this.GenerateCriteria.NameSingular = txtModelSingularName.Text;
                this.GenerateCriteria.NamePlural = txtModelPluralName.Text;
                this.GenerateCriteria.RootNameSpace = txtProject.Text;
                this.GenerateCriteria.SubmitAsDraftPullRequest = chkSubmitAsDraftPullRequest.Checked;

                GenerateCodeAsync().GetAwaiter().GetResult();
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
            this.OutputMessage = txtMessage.Text;
            this.Cancelled = true;
            this.Close();
        }

        private async ValueTask GenerateCodeAsync()
        {
            StringBuilder debugOutput = new StringBuilder();
            Dictionary<string, string> replacementsDictionary = GetReplacementDictionary();

            TemplateGenerationInfo templateGenerationInfo = new TemplateGenerationInfo
            {
                Templates = new List<Template> { GenerateCriteria.Template },
                ReplacementDictionary = replacementsDictionary,
                ScriptExecutionIsEnabled = true,
            };

            await this.templateService.GenerateCodeAsync(templateGenerationInfo);

            // The below should be replaced by a subscription to the event

            //debugOutput.AppendLine(this.templateOrchestrationService
            //    .GenerateCodeFromTemplate(transformedTemplate, replacementsDictionary));

            //_ = Task.Run(() => UseOutputWindowAsync(debugOutput.ToString(), "Standardly - Debug", standardlyDebugPane));
            //StringBuilder cleanupTaskMessage = new StringBuilder();

            //cleanupTaskMessage.AppendLine("The code generation has been completed.  " +
            //    "Please complete / review the following cleanup tasks:");

            //foreach (string task in transformedTemplate.CleanupTasks)
            //{
            //    cleanupTaskMessage.AppendLine(task);
            //}

            //txtDebug.Text = debugOutput.ToString();
            //txtMessage.Text = cleanupTaskMessage.ToString();
            //_ = Task.Run(() => UseOutputWindowAsync(cleanupTaskMessage.ToString(), "Standardly", standardlyPane));
        }

        private Dictionary<string, string> GetReplacementDictionary()
        {
            Dictionary<string, string> replacementsDictionary = new Dictionary<string, string>();
            string assembly = Assembly.GetExecutingAssembly().Location;
            string templateFolder = Path.Combine(Path.GetDirectoryName(assembly), "Templates");
            var parameterSafeItemNameSingular = PrivatePropertyName(GenerateCriteria.NameSingular);
            var parameterSafeItemNamePlural = PrivatePropertyName(GenerateCriteria.NamePlural);
            var parameterSafeItemNameSingularLower = parameterSafeItemNameSingular.ToLower();
            var parameterSafeItemNamePluralLower = parameterSafeItemNamePlural.ToLower();
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
            replacementsDictionary.Add("$parameterSafeItemNameSingularLower$", parameterSafeItemNameSingularLower);
            replacementsDictionary.Add("$parameterSafeItemNamePluralLower$", parameterSafeItemNamePluralLower);
            replacementsDictionary.Add("$lowerDescriptionName$", lowerDescriptionName);
            replacementsDictionary.Add("$upperDescriptionName$", upperDescriptionName);
            replacementsDictionary.Add("$lowerPluralDescriptionName$", lowerPluralDescriptionName);
            replacementsDictionary.Add("$upperPluralDescriptionName$", upperPluralDescriptionName);
            replacementsDictionary.Add("$solutionFolder$", settings.ProjectInfo.SolutionFolder.Replace("\\", "\\\\"));
            replacementsDictionary.Add("$templateFolder$", templateFolder.Replace("\\", "\\\\"));
            replacementsDictionary.Add("$projectName$", settings.ProjectInfo.ProjectName);
            replacementsDictionary.Add("$projectFolder$", settings.ProjectInfo.ProjectFolder.Replace("\\", "\\\\"));
            replacementsDictionary.Add("$projectFile$", settings.ProjectInfo.ProjectFile);
            replacementsDictionary.Add("$unitTestProjectName$", settings.ProjectInfo.UnitTestProjectName);

            replacementsDictionary.Add("$draftPullRequest$",
                GenerateCriteria.SubmitAsDraftPullRequest == true ? "-d " : "");

            replacementsDictionary.Add(
                "$unitTestProjectFolder$",
                settings.ProjectInfo.UnitTestProjectFolder.Replace("\\", "\\\\"));

            replacementsDictionary.Add("$unitTestProjectFile$", settings.ProjectInfo.UnitTestProjectFile);

            replacementsDictionary.Add(
                "$acceptanceTestProjectName$",
                settings.ProjectInfo.AcceptanceTestProjectName);

            replacementsDictionary.Add(
                "$acceptanceTestProjectFolder$",
                settings.ProjectInfo.AcceptanceTestProjectFolder.Replace("\\", "\\\\"));

            replacementsDictionary.Add(
                "$acceptanceTestProjectFile$",
                settings.ProjectInfo.AcceptanceTestProjectFile);

            replacementsDictionary.Add(
                "$infrastructureBuildProjectName$",
                settings.ProjectInfo.InfrastructureBuildProjectName);

            replacementsDictionary.Add(
                "$infrastructureBuildProjectFolder$",
                settings.ProjectInfo.InfrastructureBuildProjectFolder.Replace("\\", "\\\\"));

            replacementsDictionary.Add(
                "$infrastructureBuildProjectFile$",
                settings.ProjectInfo.InfrastructureBuildProjectFile);

            replacementsDictionary.Add(
                "$infrastructureProvisionProjectName$",
                settings.ProjectInfo.InfrastructureProvisionProjectName);

            replacementsDictionary.Add(
                "$infrastructureProvisionProjectFolder$",
                settings.ProjectInfo.InfrastructureProvisionProjectFolder.Replace("\\", "\\\\"));

            replacementsDictionary.Add(
                "$infrastructureProvisionProjectFile$",
                settings.ProjectInfo.InfrastructureProvisionProjectFile);

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
            replacementsDictionary.Add("$copyright$", GenerateCriteria.Copyright);
            replacementsDictionary.Add("$license$", GenerateCriteria.License);

            return replacementsDictionary;
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

        private void chkPublicRepository_CheckedChanged(object sender, EventArgs e)
        {
            chkSubmitAsDraftPullRequest.Enabled = chkPublicRepository.Checked;
            chkSubmitAsDraftPullRequest.Checked = chkPublicRepository.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            string templateFolder = Path.Combine(Path.GetDirectoryName(assembly), "Templates");

            if (!Directory.Exists(templateFolder))
            {
                Directory.CreateDirectory(templateFolder);
            }

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = templateFolder,
                FileName = "explorer.exe"
            };

            Process.Start(startInfo);
        }

        private void lnkDisclaimer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            string licensePath = Path.Combine(Path.GetDirectoryName(assembly), "LICENSE.txt");

            Process.Start("notepad.exe", licensePath);
        }
    }
}
