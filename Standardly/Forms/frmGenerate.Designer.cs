// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Forms
{
    partial class frmGenerate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerate));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkExperienceUsersOnly = new System.Windows.Forms.CheckBox();
            this.chkDisclaimer = new System.Windows.Forms.CheckBox();
            this.lnkDisclaimer = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.gbProjects = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAcceptanceTestProject = new System.Windows.Forms.Label();
            this.lblUnitTestProject = new System.Windows.Forms.Label();
            this.txtInfrastructureProvisionProject = new System.Windows.Forms.TextBox();
            this.txtInfrastructureBuildProject = new System.Windows.Forms.TextBox();
            this.txtAcceptanceTestProject = new System.Windows.Forms.TextBox();
            this.txtUnitTestProject = new System.Windows.Forms.TextBox();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbTemplates = new System.Windows.Forms.GroupBox();
            this.txtGitHubBaseBranchName = new System.Windows.Forms.TextBox();
            this.lblGitHubBaseBranchName = new System.Windows.Forms.Label();
            this.chkSubmitAsDraftPullRequest = new System.Windows.Forms.CheckBox();
            this.chkPublicRepository = new System.Windows.Forms.CheckBox();
            this.lblTemplates = new System.Windows.Forms.Label();
            this.lblModelPlural = new System.Windows.Forms.Label();
            this.lblModelSingular = new System.Windows.Forms.Label();
            this.lblTemplateType = new System.Windows.Forms.Label();
            this.cbTemplates = new System.Windows.Forms.ComboBox();
            this.cbTemplateType = new System.Windows.Forms.ComboBox();
            this.txtModelPluralName = new System.Windows.Forms.TextBox();
            this.txtModelSingularName = new System.Windows.Forms.TextBox();
            this.txtTemplateSearch = new System.Windows.Forms.TextBox();
            this.lblSerachTemplates = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGitHubUsername = new System.Windows.Forms.TextBox();
            this.lblGitHubUsername = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.txtCopyright = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkGitIgnore = new System.Windows.Forms.CheckBox();
            this.chkLicense = new System.Windows.Forms.CheckBox();
            this.chkEditorConfig = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGenerateFromTemplate = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gbProjects.SuspendLayout();
            this.gbTemplates.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(972, 464);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.gbProjects);
            this.tabPage1.Controls.Add(this.gbTemplates);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(964, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Template";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.chkExperienceUsersOnly);
            this.groupBox6.Controls.Add(this.chkDisclaimer);
            this.groupBox6.Controls.Add(this.lnkDisclaimer);
            this.groupBox6.Controls.Add(this.linkLabel1);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(7, 344);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(948, 88);
            this.groupBox6.TabIndex = 22;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Legal Stuff";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(31, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "I have read and accept the";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(374, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Scripts can be reviewed in the";
            // 
            // chkExperienceUsersOnly
            // 
            this.chkExperienceUsersOnly.AutoSize = true;
            this.chkExperienceUsersOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExperienceUsersOnly.ForeColor = System.Drawing.Color.Red;
            this.chkExperienceUsersOnly.Location = new System.Drawing.Point(15, 19);
            this.chkExperienceUsersOnly.Name = "chkExperienceUsersOnly";
            this.chkExperienceUsersOnly.Size = new System.Drawing.Size(916, 17);
            this.chkExperienceUsersOnly.TabIndex = 11;
            this.chkExperienceUsersOnly.Text = "I confirm that I am an experienced developer and able to write this code myself. " +
    " The use of this productivity tool will NOT limit my skills or learning potentia" +
    "l.";
            this.chkExperienceUsersOnly.UseVisualStyleBackColor = true;
            this.chkExperienceUsersOnly.CheckedChanged += new System.EventHandler(this.chkExperienceUsersOnly_CheckedChanged);
            // 
            // chkDisclaimer
            // 
            this.chkDisclaimer.AutoSize = true;
            this.chkDisclaimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisclaimer.ForeColor = System.Drawing.Color.Red;
            this.chkDisclaimer.Location = new System.Drawing.Point(15, 42);
            this.chkDisclaimer.Name = "chkDisclaimer";
            this.chkDisclaimer.Size = new System.Drawing.Size(752, 17);
            this.chkDisclaimer.TabIndex = 12;
            this.chkDisclaimer.Text = "I acknowledge that this productivity tool use powershell scripts as defined in th" +
    "e templates which could be harmfull if modified.  ";
            this.chkDisclaimer.UseVisualStyleBackColor = true;
            this.chkDisclaimer.CheckedChanged += new System.EventHandler(this.chkDisclaimer_CheckedChanged);
            // 
            // lnkDisclaimer
            // 
            this.lnkDisclaimer.AutoSize = true;
            this.lnkDisclaimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkDisclaimer.Location = new System.Drawing.Point(193, 67);
            this.lnkDisclaimer.Name = "lnkDisclaimer";
            this.lnkDisclaimer.Size = new System.Drawing.Size(145, 13);
            this.lnkDisclaimer.TabIndex = 13;
            this.lnkDisclaimer.TabStop = true;
            this.lnkDisclaimer.Text = "Disclaimer of Warranties";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(560, 67);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(97, 13);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "templates folder";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // gbProjects
            // 
            this.gbProjects.Controls.Add(this.label11);
            this.gbProjects.Controls.Add(this.label7);
            this.gbProjects.Controls.Add(this.label8);
            this.gbProjects.Controls.Add(this.lblAcceptanceTestProject);
            this.gbProjects.Controls.Add(this.lblUnitTestProject);
            this.gbProjects.Controls.Add(this.txtInfrastructureProvisionProject);
            this.gbProjects.Controls.Add(this.txtInfrastructureBuildProject);
            this.gbProjects.Controls.Add(this.txtAcceptanceTestProject);
            this.gbProjects.Controls.Add(this.txtUnitTestProject);
            this.gbProjects.Controls.Add(this.txtProject);
            this.gbProjects.Controls.Add(this.label6);
            this.gbProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProjects.Location = new System.Drawing.Point(7, 167);
            this.gbProjects.Name = "gbProjects";
            this.gbProjects.Size = new System.Drawing.Size(948, 171);
            this.gbProjects.TabIndex = 1;
            this.gbProjects.TabStop = false;
            this.gbProjects.Text = "Projects";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(12, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(245, 15);
            this.label11.TabIndex = 59;
            this.label11.Text = "** Names assumed by convention.  **";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "Infrastructure Provision Project: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Infrastructure Build Project: ";
            // 
            // lblAcceptanceTestProject
            // 
            this.lblAcceptanceTestProject.AutoSize = true;
            this.lblAcceptanceTestProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcceptanceTestProject.Location = new System.Drawing.Point(12, 89);
            this.lblAcceptanceTestProject.Name = "lblAcceptanceTestProject";
            this.lblAcceptanceTestProject.Size = new System.Drawing.Size(131, 13);
            this.lblAcceptanceTestProject.TabIndex = 57;
            this.lblAcceptanceTestProject.Text = "Acceptance Test Project: ";
            // 
            // lblUnitTestProject
            // 
            this.lblUnitTestProject.AutoSize = true;
            this.lblUnitTestProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitTestProject.Location = new System.Drawing.Point(12, 63);
            this.lblUnitTestProject.Name = "lblUnitTestProject";
            this.lblUnitTestProject.Size = new System.Drawing.Size(92, 13);
            this.lblUnitTestProject.TabIndex = 58;
            this.lblUnitTestProject.Text = "Unit Test Project: ";
            // 
            // txtInfrastructureProvisionProject
            // 
            this.txtInfrastructureProvisionProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfrastructureProvisionProject.Location = new System.Drawing.Point(173, 138);
            this.txtInfrastructureProvisionProject.Name = "txtInfrastructureProvisionProject";
            this.txtInfrastructureProvisionProject.ReadOnly = true;
            this.txtInfrastructureProvisionProject.Size = new System.Drawing.Size(769, 20);
            this.txtInfrastructureProvisionProject.TabIndex = 10;
            // 
            // txtInfrastructureBuildProject
            // 
            this.txtInfrastructureBuildProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfrastructureBuildProject.Location = new System.Drawing.Point(173, 112);
            this.txtInfrastructureBuildProject.Name = "txtInfrastructureBuildProject";
            this.txtInfrastructureBuildProject.ReadOnly = true;
            this.txtInfrastructureBuildProject.Size = new System.Drawing.Size(769, 20);
            this.txtInfrastructureBuildProject.TabIndex = 9;
            // 
            // txtAcceptanceTestProject
            // 
            this.txtAcceptanceTestProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcceptanceTestProject.Location = new System.Drawing.Point(173, 86);
            this.txtAcceptanceTestProject.Name = "txtAcceptanceTestProject";
            this.txtAcceptanceTestProject.ReadOnly = true;
            this.txtAcceptanceTestProject.Size = new System.Drawing.Size(769, 20);
            this.txtAcceptanceTestProject.TabIndex = 8;
            // 
            // txtUnitTestProject
            // 
            this.txtUnitTestProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitTestProject.Location = new System.Drawing.Point(173, 60);
            this.txtUnitTestProject.Name = "txtUnitTestProject";
            this.txtUnitTestProject.ReadOnly = true;
            this.txtUnitTestProject.Size = new System.Drawing.Size(769, 20);
            this.txtUnitTestProject.TabIndex = 7;
            // 
            // txtProject
            // 
            this.txtProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProject.Location = new System.Drawing.Point(173, 34);
            this.txtProject.Name = "txtProject";
            this.txtProject.ReadOnly = true;
            this.txtProject.Size = new System.Drawing.Size(769, 20);
            this.txtProject.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Project: ";
            // 
            // gbTemplates
            // 
            this.gbTemplates.Controls.Add(this.txtGitHubBaseBranchName);
            this.gbTemplates.Controls.Add(this.lblGitHubBaseBranchName);
            this.gbTemplates.Controls.Add(this.chkSubmitAsDraftPullRequest);
            this.gbTemplates.Controls.Add(this.chkPublicRepository);
            this.gbTemplates.Controls.Add(this.lblTemplates);
            this.gbTemplates.Controls.Add(this.lblModelPlural);
            this.gbTemplates.Controls.Add(this.lblModelSingular);
            this.gbTemplates.Controls.Add(this.lblTemplateType);
            this.gbTemplates.Controls.Add(this.cbTemplates);
            this.gbTemplates.Controls.Add(this.cbTemplateType);
            this.gbTemplates.Controls.Add(this.txtModelPluralName);
            this.gbTemplates.Controls.Add(this.txtModelSingularName);
            this.gbTemplates.Controls.Add(this.txtTemplateSearch);
            this.gbTemplates.Controls.Add(this.lblSerachTemplates);
            this.gbTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTemplates.Location = new System.Drawing.Point(7, 7);
            this.gbTemplates.Name = "gbTemplates";
            this.gbTemplates.Size = new System.Drawing.Size(948, 154);
            this.gbTemplates.TabIndex = 0;
            this.gbTemplates.TabStop = false;
            this.gbTemplates.Text = "Template Info";
            // 
            // txtGitHubBaseBranchName
            // 
            this.txtGitHubBaseBranchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGitHubBaseBranchName.Location = new System.Drawing.Point(209, 104);
            this.txtGitHubBaseBranchName.Name = "txtGitHubBaseBranchName";
            this.txtGitHubBaseBranchName.Size = new System.Drawing.Size(579, 20);
            this.txtGitHubBaseBranchName.TabIndex = 57;
            // 
            // lblGitHubBaseBranchName
            // 
            this.lblGitHubBaseBranchName.AutoSize = true;
            this.lblGitHubBaseBranchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGitHubBaseBranchName.Location = new System.Drawing.Point(12, 107);
            this.lblGitHubBaseBranchName.Name = "lblGitHubBaseBranchName";
            this.lblGitHubBaseBranchName.Size = new System.Drawing.Size(181, 13);
            this.lblGitHubBaseBranchName.TabIndex = 58;
            this.lblGitHubBaseBranchName.Text = "GitHub Base Branch / Branch From: ";
            // 
            // chkSubmitAsDraftPullRequest
            // 
            this.chkSubmitAsDraftPullRequest.AutoSize = true;
            this.chkSubmitAsDraftPullRequest.Enabled = false;
            this.chkSubmitAsDraftPullRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSubmitAsDraftPullRequest.Location = new System.Drawing.Point(132, 131);
            this.chkSubmitAsDraftPullRequest.Name = "chkSubmitAsDraftPullRequest";
            this.chkSubmitAsDraftPullRequest.Size = new System.Drawing.Size(167, 17);
            this.chkSubmitAsDraftPullRequest.TabIndex = 56;
            this.chkSubmitAsDraftPullRequest.Text = "Submit Pull Requests As Draft";
            this.chkSubmitAsDraftPullRequest.UseVisualStyleBackColor = true;
            // 
            // chkPublicRepository
            // 
            this.chkPublicRepository.AutoSize = true;
            this.chkPublicRepository.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPublicRepository.Location = new System.Drawing.Point(15, 131);
            this.chkPublicRepository.Name = "chkPublicRepository";
            this.chkPublicRepository.Size = new System.Drawing.Size(108, 17);
            this.chkPublicRepository.TabIndex = 55;
            this.chkPublicRepository.Text = "Public Repository";
            this.chkPublicRepository.UseVisualStyleBackColor = true;
            this.chkPublicRepository.CheckedChanged += new System.EventHandler(this.chkPublicRepository_CheckedChanged);
            // 
            // lblTemplates
            // 
            this.lblTemplates.AutoSize = true;
            this.lblTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplates.Location = new System.Drawing.Point(12, 54);
            this.lblTemplates.Name = "lblTemplates";
            this.lblTemplates.Size = new System.Drawing.Size(57, 13);
            this.lblTemplates.TabIndex = 52;
            this.lblTemplates.Text = "Template: ";
            // 
            // lblModelPlural
            // 
            this.lblModelPlural.AutoSize = true;
            this.lblModelPlural.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelPlural.Location = new System.Drawing.Point(430, 82);
            this.lblModelPlural.Name = "lblModelPlural";
            this.lblModelPlural.Size = new System.Drawing.Size(102, 13);
            this.lblModelPlural.TabIndex = 53;
            this.lblModelPlural.Text = "Model Name Plural: ";
            // 
            // lblModelSingular
            // 
            this.lblModelSingular.AutoSize = true;
            this.lblModelSingular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelSingular.Location = new System.Drawing.Point(12, 78);
            this.lblModelSingular.Name = "lblModelSingular";
            this.lblModelSingular.Size = new System.Drawing.Size(114, 13);
            this.lblModelSingular.TabIndex = 54;
            this.lblModelSingular.Text = "Model Name Singular: ";
            // 
            // lblTemplateType
            // 
            this.lblTemplateType.AutoSize = true;
            this.lblTemplateType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplateType.Location = new System.Drawing.Point(430, 27);
            this.lblTemplateType.Name = "lblTemplateType";
            this.lblTemplateType.Size = new System.Drawing.Size(84, 13);
            this.lblTemplateType.TabIndex = 51;
            this.lblTemplateType.Text = "Template Type: ";
            // 
            // cbTemplates
            // 
            this.cbTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTemplates.FormattingEnabled = true;
            this.cbTemplates.Location = new System.Drawing.Point(132, 51);
            this.cbTemplates.Name = "cbTemplates";
            this.cbTemplates.Size = new System.Drawing.Size(656, 21);
            this.cbTemplates.TabIndex = 3;
            this.cbTemplates.SelectedIndexChanged += new System.EventHandler(this.cbTemplates_SelectedIndexChanged);
            // 
            // cbTemplateType
            // 
            this.cbTemplateType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTemplateType.FormattingEnabled = true;
            this.cbTemplateType.Location = new System.Drawing.Point(538, 24);
            this.cbTemplateType.Name = "cbTemplateType";
            this.cbTemplateType.Size = new System.Drawing.Size(250, 21);
            this.cbTemplateType.TabIndex = 2;
            this.cbTemplateType.SelectedIndexChanged += new System.EventHandler(this.cbTemplateType_SelectedIndexChanged);
            // 
            // txtModelPluralName
            // 
            this.txtModelPluralName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelPluralName.Location = new System.Drawing.Point(538, 78);
            this.txtModelPluralName.Name = "txtModelPluralName";
            this.txtModelPluralName.Size = new System.Drawing.Size(250, 20);
            this.txtModelPluralName.TabIndex = 5;
            this.txtModelPluralName.TextChanged += new System.EventHandler(this.txtModelPluralName_TextChanged);
            // 
            // txtModelSingularName
            // 
            this.txtModelSingularName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelSingularName.Location = new System.Drawing.Point(132, 75);
            this.txtModelSingularName.Name = "txtModelSingularName";
            this.txtModelSingularName.Size = new System.Drawing.Size(250, 20);
            this.txtModelSingularName.TabIndex = 4;
            this.txtModelSingularName.TextChanged += new System.EventHandler(this.txtModelSingularName_TextChanged);
            // 
            // txtTemplateSearch
            // 
            this.txtTemplateSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemplateSearch.Location = new System.Drawing.Point(132, 25);
            this.txtTemplateSearch.Name = "txtTemplateSearch";
            this.txtTemplateSearch.Size = new System.Drawing.Size(240, 20);
            this.txtTemplateSearch.TabIndex = 1;
            this.txtTemplateSearch.TextChanged += new System.EventHandler(this.txtTemplateSearch_TextChanged);
            // 
            // lblSerachTemplates
            // 
            this.lblSerachTemplates.AutoSize = true;
            this.lblSerachTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerachTemplates.Location = new System.Drawing.Point(12, 27);
            this.lblSerachTemplates.Name = "lblSerachTemplates";
            this.lblSerachTemplates.Size = new System.Drawing.Size(110, 13);
            this.lblSerachTemplates.TabIndex = 0;
            this.lblSerachTemplates.Text = "Search for templates: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(964, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGitHubUsername);
            this.groupBox1.Controls.Add(this.lblGitHubUsername);
            this.groupBox1.Controls.Add(this.txtDisplayName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 108);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GitHub";
            // 
            // txtGitHubUsername
            // 
            this.txtGitHubUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGitHubUsername.Location = new System.Drawing.Point(159, 50);
            this.txtGitHubUsername.Name = "txtGitHubUsername";
            this.txtGitHubUsername.Size = new System.Drawing.Size(300, 20);
            this.txtGitHubUsername.TabIndex = 17;
            this.txtGitHubUsername.TextChanged += new System.EventHandler(this.txtGitHubUsername_TextChanged);
            // 
            // lblGitHubUsername
            // 
            this.lblGitHubUsername.AutoSize = true;
            this.lblGitHubUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGitHubUsername.Location = new System.Drawing.Point(12, 53);
            this.lblGitHubUsername.Name = "lblGitHubUsername";
            this.lblGitHubUsername.Size = new System.Drawing.Size(97, 13);
            this.lblGitHubUsername.TabIndex = 50;
            this.lblGitHubUsername.Text = "GitHub Username: ";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplayName.Location = new System.Drawing.Point(159, 24);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(300, 20);
            this.txtDisplayName.TabIndex = 16;
            this.txtDisplayName.TextChanged += new System.EventHandler(this.txtDisplayName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Display Name: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtLicense);
            this.groupBox4.Controls.Add(this.txtCopyright);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 135);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(952, 297);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Copyright";
            // 
            // txtLicense
            // 
            this.txtLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicense.Location = new System.Drawing.Point(75, 158);
            this.txtLicense.Multiline = true;
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLicense.Size = new System.Drawing.Size(871, 125);
            this.txtLicense.TabIndex = 23;
            this.txtLicense.TextChanged += new System.EventHandler(this.txtLicense_TextChanged);
            // 
            // txtCopyright
            // 
            this.txtCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopyright.Location = new System.Drawing.Point(75, 26);
            this.txtCopyright.Multiline = true;
            this.txtCopyright.Name = "txtCopyright";
            this.txtCopyright.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCopyright.Size = new System.Drawing.Size(871, 125);
            this.txtCopyright.TabIndex = 22;
            this.txtCopyright.TextChanged += new System.EventHandler(this.txtCopyright_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "License: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Copyright: ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkGitIgnore);
            this.groupBox5.Controls.Add(this.chkLicense);
            this.groupBox5.Controls.Add(this.chkEditorConfig);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(533, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(425, 108);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Solution, Project and Other Configurations";
            // 
            // chkGitIgnore
            // 
            this.chkGitIgnore.AutoSize = true;
            this.chkGitIgnore.Checked = true;
            this.chkGitIgnore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGitIgnore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGitIgnore.Location = new System.Drawing.Point(7, 43);
            this.chkGitIgnore.Name = "chkGitIgnore";
            this.chkGitIgnore.Size = new System.Drawing.Size(221, 17);
            this.chkGitIgnore.TabIndex = 20;
            this.chkGitIgnore.Text = "Add .gitignore to Solution if it doesn\'t exist";
            this.chkGitIgnore.UseVisualStyleBackColor = true;
            // 
            // chkLicense
            // 
            this.chkLicense.AutoSize = true;
            this.chkLicense.Checked = true;
            this.chkLicense.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLicense.Location = new System.Drawing.Point(7, 64);
            this.chkLicense.Name = "chkLicense";
            this.chkLicense.Size = new System.Drawing.Size(246, 17);
            this.chkLicense.TabIndex = 21;
            this.chkLicense.Text = "Add Licence.txt file to Solution if it doesn\'t exist";
            this.chkLicense.UseVisualStyleBackColor = true;
            // 
            // chkEditorConfig
            // 
            this.chkEditorConfig.AutoSize = true;
            this.chkEditorConfig.Checked = true;
            this.chkEditorConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEditorConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEditorConfig.Location = new System.Drawing.Point(7, 20);
            this.chkEditorConfig.Name = "chkEditorConfig";
            this.chkEditorConfig.Size = new System.Drawing.Size(236, 17);
            this.chkEditorConfig.TabIndex = 19;
            this.chkEditorConfig.Text = "Add .editorconfig to Solution if it doesn\'t exist";
            this.chkEditorConfig.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(121, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(700, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "** The sections below can be configured under Tools > Options > The Standard Code" +
    " Generator > General **";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(7, 483);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(967, 167);
            this.txtMessage.TabIndex = 15;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(504, 656);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(470, 48);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel / Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGenerateFromTemplate
            // 
            this.btnGenerateFromTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateFromTemplate.Location = new System.Drawing.Point(6, 656);
            this.btnGenerateFromTemplate.Name = "btnGenerateFromTemplate";
            this.btnGenerateFromTemplate.Size = new System.Drawing.Size(470, 48);
            this.btnGenerateFromTemplate.TabIndex = 16;
            this.btnGenerateFromTemplate.Text = "Generate Code From Template";
            this.btnGenerateFromTemplate.UseVisualStyleBackColor = true;
            this.btnGenerateFromTemplate.Click += new System.EventHandler(this.btnGenerateFromTemplate_Click);
            // 
            // frmGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 709);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGenerateFromTemplate);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 748);
            this.Name = "frmGenerate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Standardly - Code Generator";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gbProjects.ResumeLayout(false);
            this.gbProjects.PerformLayout();
            this.gbTemplates.ResumeLayout(false);
            this.gbTemplates.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkExperienceUsersOnly;
        private System.Windows.Forms.CheckBox chkDisclaimer;
        private System.Windows.Forms.LinkLabel lnkDisclaimer;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox gbProjects;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAcceptanceTestProject;
        private System.Windows.Forms.Label lblUnitTestProject;
        private System.Windows.Forms.TextBox txtInfrastructureProvisionProject;
        private System.Windows.Forms.TextBox txtInfrastructureBuildProject;
        private System.Windows.Forms.TextBox txtAcceptanceTestProject;
        private System.Windows.Forms.TextBox txtUnitTestProject;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbTemplates;
        private System.Windows.Forms.Label lblTemplates;
        private System.Windows.Forms.Label lblModelPlural;
        private System.Windows.Forms.Label lblModelSingular;
        private System.Windows.Forms.Label lblTemplateType;
        private System.Windows.Forms.ComboBox cbTemplates;
        private System.Windows.Forms.ComboBox cbTemplateType;
        private System.Windows.Forms.TextBox txtModelPluralName;
        private System.Windows.Forms.TextBox txtModelSingularName;
        private System.Windows.Forms.TextBox txtTemplateSearch;
        private System.Windows.Forms.Label lblSerachTemplates;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGitHubUsername;
        private System.Windows.Forms.Label lblGitHubUsername;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.TextBox txtCopyright;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkGitIgnore;
        private System.Windows.Forms.CheckBox chkLicense;
        private System.Windows.Forms.CheckBox chkEditorConfig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenerateFromTemplate;
        private System.Windows.Forms.CheckBox chkSubmitAsDraftPullRequest;
        private System.Windows.Forms.CheckBox chkPublicRepository;
        private System.Windows.Forms.TextBox txtGitHubBaseBranchName;
        private System.Windows.Forms.Label lblGitHubBaseBranchName;
    }
}