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
            this.templateGeneration = new System.Windows.Forms.TabPage();
            this.gbModel = new System.Windows.Forms.GroupBox();
            this.lblModelText = new System.Windows.Forms.Label();
            this.txtModelPluralName = new System.Windows.Forms.TextBox();
            this.lblModelPlural = new System.Windows.Forms.Label();
            this.txtModelSingularName = new System.Windows.Forms.TextBox();
            this.lblModelSingular = new System.Windows.Forms.Label();
            this.gbRepo = new System.Windows.Forms.GroupBox();
            this.txtGitHubBaseBranchName = new System.Windows.Forms.TextBox();
            this.chkSubmitAsDraftPullRequest = new System.Windows.Forms.CheckBox();
            this.lblGitHubBaseBranchName = new System.Windows.Forms.Label();
            this.chkPublicRepository = new System.Windows.Forms.CheckBox();
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
            this.panelMultipleTemplates = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.cbFoundationService = new System.Windows.Forms.CheckBox();
            this.cbStorageBroker = new System.Windows.Forms.CheckBox();
            this.cbData = new System.Windows.Forms.CheckBox();
            this.panelSingleTemplate = new System.Windows.Forms.Panel();
            this.txtTemplateSearch = new System.Windows.Forms.TextBox();
            this.lblSerachTemplates = new System.Windows.Forms.Label();
            this.cbTemplateType = new System.Windows.Forms.ComboBox();
            this.lblTemplates = new System.Windows.Forms.Label();
            this.cbTemplates = new System.Windows.Forms.ComboBox();
            this.lblTemplateType = new System.Windows.Forms.Label();
            this.rbMultipleTemplates = new System.Windows.Forms.RadioButton();
            this.rbSingleTemplate = new System.Windows.Forms.RadioButton();
            this.entityModel = new System.Windows.Forms.TabPage();
            this.lblClassName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.globalConfiguration = new System.Windows.Forms.TabPage();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGenerateFromTemplate = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlStorageBroker = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.templateGeneration.SuspendLayout();
            this.gbModel.SuspendLayout();
            this.gbRepo.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gbProjects.SuspendLayout();
            this.gbTemplates.SuspendLayout();
            this.panelMultipleTemplates.SuspendLayout();
            this.panelSingleTemplate.SuspendLayout();
            this.entityModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.globalConfiguration.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlStorageBroker.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.templateGeneration);
            this.tabControl1.Controls.Add(this.entityModel);
            this.tabControl1.Controls.Add(this.globalConfiguration);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(6, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(972, 637);
            this.tabControl1.TabIndex = 0;
            // 
            // templateGeneration
            // 
            this.templateGeneration.Controls.Add(this.gbModel);
            this.templateGeneration.Controls.Add(this.gbRepo);
            this.templateGeneration.Controls.Add(this.groupBox6);
            this.templateGeneration.Controls.Add(this.gbProjects);
            this.templateGeneration.Controls.Add(this.gbTemplates);
            this.templateGeneration.Location = new System.Drawing.Point(4, 22);
            this.templateGeneration.Name = "templateGeneration";
            this.templateGeneration.Padding = new System.Windows.Forms.Padding(3);
            this.templateGeneration.Size = new System.Drawing.Size(964, 611);
            this.templateGeneration.TabIndex = 0;
            this.templateGeneration.Text = "Template";
            this.templateGeneration.UseVisualStyleBackColor = true;
            // 
            // gbModel
            // 
            this.gbModel.Controls.Add(this.lblModelText);
            this.gbModel.Controls.Add(this.txtModelPluralName);
            this.gbModel.Controls.Add(this.lblModelPlural);
            this.gbModel.Controls.Add(this.txtModelSingularName);
            this.gbModel.Controls.Add(this.lblModelSingular);
            this.gbModel.Location = new System.Drawing.Point(7, 167);
            this.gbModel.Name = "gbModel";
            this.gbModel.Size = new System.Drawing.Size(947, 110);
            this.gbModel.TabIndex = 24;
            this.gbModel.TabStop = false;
            this.gbModel.Text = "Model";
            // 
            // lblModelText
            // 
            this.lblModelText.AutoSize = true;
            this.lblModelText.ForeColor = System.Drawing.Color.Red;
            this.lblModelText.Location = new System.Drawing.Point(293, 57);
            this.lblModelText.Name = "lblModelText";
            this.lblModelText.Size = new System.Drawing.Size(374, 13);
            this.lblModelText.TabIndex = 55;
            this.lblModelText.Text = "Open the Entity Model tab to extend / alter the default model that will be used.";
            // 
            // txtModelPluralName
            // 
            this.txtModelPluralName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelPluralName.Location = new System.Drawing.Point(538, 19);
            this.txtModelPluralName.Name = "txtModelPluralName";
            this.txtModelPluralName.Size = new System.Drawing.Size(250, 20);
            this.txtModelPluralName.TabIndex = 5;
            this.txtModelPluralName.TextChanged += new System.EventHandler(this.txtModelPluralName_TextChanged);
            // 
            // lblModelPlural
            // 
            this.lblModelPlural.AutoSize = true;
            this.lblModelPlural.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelPlural.Location = new System.Drawing.Point(430, 23);
            this.lblModelPlural.Name = "lblModelPlural";
            this.lblModelPlural.Size = new System.Drawing.Size(102, 13);
            this.lblModelPlural.TabIndex = 53;
            this.lblModelPlural.Text = "Model Name Plural: ";
            // 
            // txtModelSingularName
            // 
            this.txtModelSingularName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelSingularName.Location = new System.Drawing.Point(132, 16);
            this.txtModelSingularName.Name = "txtModelSingularName";
            this.txtModelSingularName.Size = new System.Drawing.Size(250, 20);
            this.txtModelSingularName.TabIndex = 4;
            this.txtModelSingularName.TextChanged += new System.EventHandler(this.txtModelSingularName_TextChanged);
            // 
            // lblModelSingular
            // 
            this.lblModelSingular.AutoSize = true;
            this.lblModelSingular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelSingular.Location = new System.Drawing.Point(12, 19);
            this.lblModelSingular.Name = "lblModelSingular";
            this.lblModelSingular.Size = new System.Drawing.Size(114, 13);
            this.lblModelSingular.TabIndex = 54;
            this.lblModelSingular.Text = "Model Name Singular: ";
            // 
            // gbRepo
            // 
            this.gbRepo.Controls.Add(this.txtGitHubBaseBranchName);
            this.gbRepo.Controls.Add(this.chkSubmitAsDraftPullRequest);
            this.gbRepo.Controls.Add(this.lblGitHubBaseBranchName);
            this.gbRepo.Controls.Add(this.chkPublicRepository);
            this.gbRepo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRepo.Location = new System.Drawing.Point(6, 283);
            this.gbRepo.Name = "gbRepo";
            this.gbRepo.Size = new System.Drawing.Size(948, 51);
            this.gbRepo.TabIndex = 23;
            this.gbRepo.TabStop = false;
            this.gbRepo.Text = "Repository Info";
            // 
            // txtGitHubBaseBranchName
            // 
            this.txtGitHubBaseBranchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGitHubBaseBranchName.Location = new System.Drawing.Point(209, 19);
            this.txtGitHubBaseBranchName.Name = "txtGitHubBaseBranchName";
            this.txtGitHubBaseBranchName.Size = new System.Drawing.Size(433, 20);
            this.txtGitHubBaseBranchName.TabIndex = 57;
            // 
            // chkSubmitAsDraftPullRequest
            // 
            this.chkSubmitAsDraftPullRequest.AutoSize = true;
            this.chkSubmitAsDraftPullRequest.Enabled = false;
            this.chkSubmitAsDraftPullRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSubmitAsDraftPullRequest.Location = new System.Drawing.Point(775, 21);
            this.chkSubmitAsDraftPullRequest.Name = "chkSubmitAsDraftPullRequest";
            this.chkSubmitAsDraftPullRequest.Size = new System.Drawing.Size(167, 17);
            this.chkSubmitAsDraftPullRequest.TabIndex = 56;
            this.chkSubmitAsDraftPullRequest.Text = "Submit Pull Requests As Draft";
            this.chkSubmitAsDraftPullRequest.UseVisualStyleBackColor = true;
            // 
            // lblGitHubBaseBranchName
            // 
            this.lblGitHubBaseBranchName.AutoSize = true;
            this.lblGitHubBaseBranchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGitHubBaseBranchName.Location = new System.Drawing.Point(12, 22);
            this.lblGitHubBaseBranchName.Name = "lblGitHubBaseBranchName";
            this.lblGitHubBaseBranchName.Size = new System.Drawing.Size(181, 13);
            this.lblGitHubBaseBranchName.TabIndex = 58;
            this.lblGitHubBaseBranchName.Text = "GitHub Base Branch / Branch From: ";
            // 
            // chkPublicRepository
            // 
            this.chkPublicRepository.AutoSize = true;
            this.chkPublicRepository.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPublicRepository.Location = new System.Drawing.Point(658, 21);
            this.chkPublicRepository.Name = "chkPublicRepository";
            this.chkPublicRepository.Size = new System.Drawing.Size(108, 17);
            this.chkPublicRepository.TabIndex = 55;
            this.chkPublicRepository.Text = "Public Repository";
            this.chkPublicRepository.UseVisualStyleBackColor = true;
            this.chkPublicRepository.CheckedChanged += new System.EventHandler(this.chkPublicRepository_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.chkExperienceUsersOnly);
            this.groupBox6.Controls.Add(this.chkDisclaimer);
            this.groupBox6.Controls.Add(this.lnkDisclaimer);
            this.groupBox6.Controls.Add(this.linkLabel1);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(7, 517);
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
            this.chkDisclaimer.Size = new System.Drawing.Size(880, 17);
            this.chkDisclaimer.TabIndex = 12;
            this.chkDisclaimer.Text = "I acknowledge that this productivity tool use CLI commands and/or powershell scri" +
    "pts as defined in the templates which could be harmfull if modified.  ";
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
            this.lnkDisclaimer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDisclaimer_LinkClicked);
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
            this.gbProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.gbProjects.Location = new System.Drawing.Point(7, 340);
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
            this.gbTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTemplates.Controls.Add(this.label12);
            this.gbTemplates.Controls.Add(this.panelMultipleTemplates);
            this.gbTemplates.Controls.Add(this.panelSingleTemplate);
            this.gbTemplates.Controls.Add(this.rbMultipleTemplates);
            this.gbTemplates.Controls.Add(this.rbSingleTemplate);
            this.gbTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTemplates.Location = new System.Drawing.Point(7, 7);
            this.gbTemplates.Name = "gbTemplates";
            this.gbTemplates.Size = new System.Drawing.Size(948, 154);
            this.gbTemplates.TabIndex = 0;
            this.gbTemplates.TabStop = false;
            this.gbTemplates.Text = "Template Info";
            // 
            // panelMultipleTemplates
            // 
            this.panelMultipleTemplates.Controls.Add(this.pnlStorageBroker);
            this.panelMultipleTemplates.Controls.Add(this.checkBox1);
            this.panelMultipleTemplates.Controls.Add(this.checkBox3);
            this.panelMultipleTemplates.Controls.Add(this.cbFoundationService);
            this.panelMultipleTemplates.Controls.Add(this.cbStorageBroker);
            this.panelMultipleTemplates.Controls.Add(this.cbData);
            this.panelMultipleTemplates.Enabled = false;
            this.panelMultipleTemplates.Location = new System.Drawing.Point(192, 86);
            this.panelMultipleTemplates.Name = "panelMultipleTemplates";
            this.panelMultipleTemplates.Size = new System.Drawing.Size(750, 62);
            this.panelMultipleTemplates.TabIndex = 56;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(613, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(129, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Acceptance Tests";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(487, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(80, 17);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Controller";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // cbFoundationService
            // 
            this.cbFoundationService.AutoSize = true;
            this.cbFoundationService.Checked = true;
            this.cbFoundationService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFoundationService.Location = new System.Drawing.Point(305, 3);
            this.cbFoundationService.Name = "cbFoundationService";
            this.cbFoundationService.Size = new System.Drawing.Size(136, 17);
            this.cbFoundationService.TabIndex = 1;
            this.cbFoundationService.Text = "Foundation Service";
            this.cbFoundationService.UseVisualStyleBackColor = true;
            // 
            // cbStorageBroker
            // 
            this.cbStorageBroker.AutoSize = true;
            this.cbStorageBroker.Checked = true;
            this.cbStorageBroker.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStorageBroker.Location = new System.Drawing.Point(148, 3);
            this.cbStorageBroker.Name = "cbStorageBroker";
            this.cbStorageBroker.Size = new System.Drawing.Size(111, 17);
            this.cbStorageBroker.TabIndex = 1;
            this.cbStorageBroker.Text = "Storage Broker";
            this.cbStorageBroker.UseVisualStyleBackColor = true;
            this.cbStorageBroker.CheckedChanged += new System.EventHandler(this.cbStorageBroker_CheckedChanged);
            // 
            // cbData
            // 
            this.cbData.AutoSize = true;
            this.cbData.Checked = true;
            this.cbData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbData.Location = new System.Drawing.Point(3, 3);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(99, 17);
            this.cbData.TabIndex = 0;
            this.cbData.Text = "Data / Entity";
            this.cbData.UseVisualStyleBackColor = true;
            // 
            // panelSingleTemplate
            // 
            this.panelSingleTemplate.Controls.Add(this.txtTemplateSearch);
            this.panelSingleTemplate.Controls.Add(this.lblSerachTemplates);
            this.panelSingleTemplate.Controls.Add(this.cbTemplateType);
            this.panelSingleTemplate.Controls.Add(this.lblTemplates);
            this.panelSingleTemplate.Controls.Add(this.cbTemplates);
            this.panelSingleTemplate.Controls.Add(this.lblTemplateType);
            this.panelSingleTemplate.Location = new System.Drawing.Point(192, 10);
            this.panelSingleTemplate.Name = "panelSingleTemplate";
            this.panelSingleTemplate.Size = new System.Drawing.Size(750, 60);
            this.panelSingleTemplate.TabIndex = 55;
            // 
            // txtTemplateSearch
            // 
            this.txtTemplateSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemplateSearch.Location = new System.Drawing.Point(124, 4);
            this.txtTemplateSearch.Name = "txtTemplateSearch";
            this.txtTemplateSearch.Size = new System.Drawing.Size(240, 20);
            this.txtTemplateSearch.TabIndex = 1;
            this.txtTemplateSearch.TextChanged += new System.EventHandler(this.txtTemplateSearch_TextChanged);
            // 
            // lblSerachTemplates
            // 
            this.lblSerachTemplates.AutoSize = true;
            this.lblSerachTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerachTemplates.Location = new System.Drawing.Point(8, 6);
            this.lblSerachTemplates.Name = "lblSerachTemplates";
            this.lblSerachTemplates.Size = new System.Drawing.Size(110, 13);
            this.lblSerachTemplates.TabIndex = 0;
            this.lblSerachTemplates.Text = "Search for templates: ";
            // 
            // cbTemplateType
            // 
            this.cbTemplateType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTemplateType.FormattingEnabled = true;
            this.cbTemplateType.Items.AddRange(new object[] {
            "All",
            "API",
            "Blazor ",
            "React",
            "Config"});
            this.cbTemplateType.Location = new System.Drawing.Point(472, 4);
            this.cbTemplateType.Name = "cbTemplateType";
            this.cbTemplateType.Size = new System.Drawing.Size(250, 21);
            this.cbTemplateType.TabIndex = 2;
            this.cbTemplateType.SelectedIndexChanged += new System.EventHandler(this.cbTemplateType_SelectedIndexChanged);
            // 
            // lblTemplates
            // 
            this.lblTemplates.AutoSize = true;
            this.lblTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplates.Location = new System.Drawing.Point(61, 33);
            this.lblTemplates.Name = "lblTemplates";
            this.lblTemplates.Size = new System.Drawing.Size(57, 13);
            this.lblTemplates.TabIndex = 52;
            this.lblTemplates.Text = "Template: ";
            // 
            // cbTemplates
            // 
            this.cbTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTemplates.FormattingEnabled = true;
            this.cbTemplates.Location = new System.Drawing.Point(124, 30);
            this.cbTemplates.Name = "cbTemplates";
            this.cbTemplates.Size = new System.Drawing.Size(598, 21);
            this.cbTemplates.TabIndex = 3;
            this.cbTemplates.SelectedIndexChanged += new System.EventHandler(this.cbTemplates_SelectedIndexChanged);
            // 
            // lblTemplateType
            // 
            this.lblTemplateType.AutoSize = true;
            this.lblTemplateType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplateType.Location = new System.Drawing.Point(382, 7);
            this.lblTemplateType.Name = "lblTemplateType";
            this.lblTemplateType.Size = new System.Drawing.Size(84, 13);
            this.lblTemplateType.TabIndex = 51;
            this.lblTemplateType.Text = "Template Type: ";
            // 
            // rbMultipleTemplates
            // 
            this.rbMultipleTemplates.AutoSize = true;
            this.rbMultipleTemplates.Location = new System.Drawing.Point(15, 89);
            this.rbMultipleTemplates.Name = "rbMultipleTemplates";
            this.rbMultipleTemplates.Size = new System.Drawing.Size(163, 17);
            this.rbMultipleTemplates.TabIndex = 54;
            this.rbMultipleTemplates.Text = "Multiple Templates (API)";
            this.rbMultipleTemplates.UseVisualStyleBackColor = true;
            this.rbMultipleTemplates.CheckedChanged += new System.EventHandler(this.rbMultipleTemplates_CheckedChanged);
            // 
            // rbSingleTemplate
            // 
            this.rbSingleTemplate.AutoSize = true;
            this.rbSingleTemplate.Checked = true;
            this.rbSingleTemplate.Location = new System.Drawing.Point(15, 22);
            this.rbSingleTemplate.Name = "rbSingleTemplate";
            this.rbSingleTemplate.Size = new System.Drawing.Size(116, 17);
            this.rbSingleTemplate.TabIndex = 53;
            this.rbSingleTemplate.TabStop = true;
            this.rbSingleTemplate.Text = "Single Template";
            this.rbSingleTemplate.UseVisualStyleBackColor = true;
            this.rbSingleTemplate.CheckedChanged += new System.EventHandler(this.rbSingleTemplate_CheckedChanged);
            // 
            // entityModel
            // 
            this.entityModel.Controls.Add(this.lblClassName);
            this.entityModel.Controls.Add(this.dataGridView1);
            this.entityModel.Location = new System.Drawing.Point(4, 22);
            this.entityModel.Name = "entityModel";
            this.entityModel.Padding = new System.Windows.Forms.Padding(3);
            this.entityModel.Size = new System.Drawing.Size(964, 611);
            this.entityModel.TabIndex = 2;
            this.entityModel.Text = "Entity Model";
            this.entityModel.UseVisualStyleBackColor = true;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.Location = new System.Drawing.Point(7, 7);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(79, 24);
            this.lblClassName.TabIndex = 1;
            this.lblClassName.Text = "Class.cs";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(943, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // globalConfiguration
            // 
            this.globalConfiguration.Controls.Add(this.groupBox1);
            this.globalConfiguration.Controls.Add(this.groupBox4);
            this.globalConfiguration.Controls.Add(this.groupBox5);
            this.globalConfiguration.Controls.Add(this.label2);
            this.globalConfiguration.Location = new System.Drawing.Point(4, 22);
            this.globalConfiguration.Name = "globalConfiguration";
            this.globalConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.globalConfiguration.Size = new System.Drawing.Size(964, 611);
            this.globalConfiguration.TabIndex = 1;
            this.globalConfiguration.Text = "Configuration";
            this.globalConfiguration.UseVisualStyleBackColor = true;
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
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txtLicense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txtCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMessage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(964, 611);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Output";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(3, 3);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(958, 605);
            this.txtMessage.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnGenerateFromTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerateFromTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateFromTemplate.Location = new System.Drawing.Point(6, 656);
            this.btnGenerateFromTemplate.Name = "btnGenerateFromTemplate";
            this.btnGenerateFromTemplate.Size = new System.Drawing.Size(470, 48);
            this.btnGenerateFromTemplate.TabIndex = 16;
            this.btnGenerateFromTemplate.Text = "Generate Code From Template";
            this.btnGenerateFromTemplate.UseVisualStyleBackColor = true;
            this.btnGenerateFromTemplate.Click += new System.EventHandler(this.btnGenerateFromTemplate_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(121, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(598, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Storage Broker: ";
            // 
            // pnlStorageBroker
            // 
            this.pnlStorageBroker.Controls.Add(this.label9);
            this.pnlStorageBroker.Controls.Add(this.comboBox1);
            this.pnlStorageBroker.Location = new System.Drawing.Point(3, 26);
            this.pnlStorageBroker.Name = "pnlStorageBroker";
            this.pnlStorageBroker.Size = new System.Drawing.Size(739, 33);
            this.pnlStorageBroker.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 57;
            // 
            // frmGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 709);
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
            this.templateGeneration.ResumeLayout(false);
            this.gbModel.ResumeLayout(false);
            this.gbModel.PerformLayout();
            this.gbRepo.ResumeLayout(false);
            this.gbRepo.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gbProjects.ResumeLayout(false);
            this.gbProjects.PerformLayout();
            this.gbTemplates.ResumeLayout(false);
            this.gbTemplates.PerformLayout();
            this.panelMultipleTemplates.ResumeLayout(false);
            this.panelMultipleTemplates.PerformLayout();
            this.panelSingleTemplate.ResumeLayout(false);
            this.panelSingleTemplate.PerformLayout();
            this.entityModel.ResumeLayout(false);
            this.entityModel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.globalConfiguration.ResumeLayout(false);
            this.globalConfiguration.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnlStorageBroker.ResumeLayout(false);
            this.pnlStorageBroker.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage templateGeneration;
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
        private System.Windows.Forms.TabPage globalConfiguration;
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
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenerateFromTemplate;
        private System.Windows.Forms.CheckBox chkSubmitAsDraftPullRequest;
        private System.Windows.Forms.CheckBox chkPublicRepository;
        private System.Windows.Forms.TextBox txtGitHubBaseBranchName;
        private System.Windows.Forms.Label lblGitHubBaseBranchName;
        private System.Windows.Forms.TabPage entityModel;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox gbModel;
        private System.Windows.Forms.Label lblModelText;
        private System.Windows.Forms.GroupBox gbRepo;
        private System.Windows.Forms.RadioButton rbMultipleTemplates;
        private System.Windows.Forms.RadioButton rbSingleTemplate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Panel panelMultipleTemplates;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox cbFoundationService;
        private System.Windows.Forms.CheckBox cbStorageBroker;
        private System.Windows.Forms.CheckBox cbData;
        private System.Windows.Forms.Panel panelSingleTemplate;
        private System.Windows.Forms.Panel pnlStorageBroker;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
    }
}