namespace Ghostscript.Studio.Workspaces.Processor
{
    partial class FProcessorWorkspace
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.spDocAndOther = new System.Windows.Forms.SplitContainer();
            this.spEditors = new System.Windows.Forms.SplitContainer();
            this.panProcessorEditor = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnApplySwitchesPreset = new System.Windows.Forms.Button();
            this.btnSwitchesPresetManager = new System.Windows.Forms.Button();
            this.btnCreateSwitchesPreset = new System.Windows.Forms.Button();
            this.cboSwitchesPresets = new System.Windows.Forms.ComboBox();
            this.lblSwitches = new System.Windows.Forms.Label();
            this.panPostScriptEditor = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApplyPostScriptPreset = new System.Windows.Forms.Button();
            this.btnPostScriptPresetManager = new System.Windows.Forms.Button();
            this.btnCreatePostScriptPreset = new System.Windows.Forms.Button();
            this.cboPostScriptPresets = new System.Windows.Forms.ComboBox();
            this.lblPostScriptToExecute = new System.Windows.Forms.Label();
            this.panEditorFiles = new System.Windows.Forms.Panel();
            this.btnBrowseOutputFolder = new System.Windows.Forms.Button();
            this.txtFilenameFormat = new System.Windows.Forms.TextBox();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.lblFilenameFormat = new System.Windows.Forms.Label();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.btnClearInputFiles = new System.Windows.Forms.Button();
            this.btnRemoveInputFile = new System.Windows.Forms.Button();
            this.btnAddInputFile = new System.Windows.Forms.Button();
            this.lbInputFiles = new System.Windows.Forms.ListBox();
            this.lblInputFiles = new System.Windows.Forms.Label();
            this.panFilesTitle = new System.Windows.Forms.Panel();
            this.lblInputAndOutputFiles = new System.Windows.Forms.Label();
            this.panOutputDebug = new System.Windows.Forms.Panel();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.panOutputTitle = new System.Windows.Forms.Panel();
            this.lblOutputDebug = new System.Windows.Forms.Label();
            this.lblFiles = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cms_Editor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spDocAndOther)).BeginInit();
            this.spDocAndOther.Panel1.SuspendLayout();
            this.spDocAndOther.Panel2.SuspendLayout();
            this.spDocAndOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spEditors)).BeginInit();
            this.spEditors.Panel1.SuspendLayout();
            this.spEditors.Panel2.SuspendLayout();
            this.spEditors.SuspendLayout();
            this.panProcessorEditor.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panPostScriptEditor.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panEditorFiles.SuspendLayout();
            this.panFilesTitle.SuspendLayout();
            this.panOutputDebug.SuspendLayout();
            this.panOutputTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsProgressBar,
            this.toolStripStatusLabel2});
            this.statusStrip.Location = new System.Drawing.Point(0, 463);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(851, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 7;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(418, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.AutoSize = false;
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(300, 16);
            this.tsProgressBar.Step = 1;
            this.tsProgressBar.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(418, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // spDocAndOther
            // 
            this.spDocAndOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spDocAndOther.Location = new System.Drawing.Point(0, 0);
            this.spDocAndOther.Name = "spDocAndOther";
            this.spDocAndOther.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spDocAndOther.Panel1
            // 
            this.spDocAndOther.Panel1.Controls.Add(this.spEditors);
            this.spDocAndOther.Panel1.Controls.Add(this.panEditorFiles);
            // 
            // spDocAndOther.Panel2
            // 
            this.spDocAndOther.Panel2.Controls.Add(this.panOutputDebug);
            this.spDocAndOther.Panel2.Controls.Add(this.panOutputTitle);
            this.spDocAndOther.Size = new System.Drawing.Size(851, 463);
            this.spDocAndOther.SplitterDistance = 349;
            this.spDocAndOther.TabIndex = 6;
            // 
            // spEditors
            // 
            this.spEditors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spEditors.Location = new System.Drawing.Point(0, 0);
            this.spEditors.Name = "spEditors";
            this.spEditors.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spEditors.Panel1
            // 
            this.spEditors.Panel1.Controls.Add(this.panProcessorEditor);
            // 
            // spEditors.Panel2
            // 
            this.spEditors.Panel2.Controls.Add(this.panPostScriptEditor);
            this.spEditors.Size = new System.Drawing.Size(491, 349);
            this.spEditors.SplitterDistance = 194;
            this.spEditors.TabIndex = 3;
            // 
            // panProcessorEditor
            // 
            this.panProcessorEditor.Controls.Add(this.panel2);
            this.panProcessorEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panProcessorEditor.Location = new System.Drawing.Point(0, 0);
            this.panProcessorEditor.Name = "panProcessorEditor";
            this.panProcessorEditor.Size = new System.Drawing.Size(491, 194);
            this.panProcessorEditor.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnApplySwitchesPreset);
            this.panel2.Controls.Add(this.btnSwitchesPresetManager);
            this.panel2.Controls.Add(this.btnCreateSwitchesPreset);
            this.panel2.Controls.Add(this.cboSwitchesPresets);
            this.panel2.Controls.Add(this.lblSwitches);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 27);
            this.panel2.TabIndex = 1;
            // 
            // btnApplySwitchesPreset
            // 
            this.btnApplySwitchesPreset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplySwitchesPreset.Image = global::Ghostscript.Studio.Properties.Resources._16x16_apply_preset;
            this.btnApplySwitchesPreset.Location = new System.Drawing.Point(460, 2);
            this.btnApplySwitchesPreset.Name = "btnApplySwitchesPreset";
            this.btnApplySwitchesPreset.Size = new System.Drawing.Size(24, 24);
            this.btnApplySwitchesPreset.TabIndex = 14;
            this.btnApplySwitchesPreset.UseVisualStyleBackColor = true;
            this.btnApplySwitchesPreset.Click += new System.EventHandler(this.btnApplySwitchesPreset_Click);
            // 
            // btnSwitchesPresetManager
            // 
            this.btnSwitchesPresetManager.Image = global::Ghostscript.Studio.Properties.Resources._16x16_preset_list;
            this.btnSwitchesPresetManager.Location = new System.Drawing.Point(207, 2);
            this.btnSwitchesPresetManager.Name = "btnSwitchesPresetManager";
            this.btnSwitchesPresetManager.Size = new System.Drawing.Size(24, 24);
            this.btnSwitchesPresetManager.TabIndex = 13;
            this.btnSwitchesPresetManager.UseVisualStyleBackColor = true;
            this.btnSwitchesPresetManager.Click += new System.EventHandler(this.btnSwitchesPresetManager_Click);
            // 
            // btnCreateSwitchesPreset
            // 
            this.btnCreateSwitchesPreset.Image = global::Ghostscript.Studio.Properties.Resources._16x16_preset_save;
            this.btnCreateSwitchesPreset.Location = new System.Drawing.Point(181, 2);
            this.btnCreateSwitchesPreset.Name = "btnCreateSwitchesPreset";
            this.btnCreateSwitchesPreset.Size = new System.Drawing.Size(24, 24);
            this.btnCreateSwitchesPreset.TabIndex = 12;
            this.btnCreateSwitchesPreset.UseVisualStyleBackColor = true;
            this.btnCreateSwitchesPreset.Click += new System.EventHandler(this.btnCreateSwitchesPreset_Click);
            // 
            // cboSwitchesPresets
            // 
            this.cboSwitchesPresets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSwitchesPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSwitchesPresets.FormattingEnabled = true;
            this.cboSwitchesPresets.Location = new System.Drawing.Point(235, 3);
            this.cboSwitchesPresets.Name = "cboSwitchesPresets";
            this.cboSwitchesPresets.Size = new System.Drawing.Size(221, 21);
            this.cboSwitchesPresets.TabIndex = 11;
            // 
            // lblSwitches
            // 
            this.lblSwitches.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblSwitches.Location = new System.Drawing.Point(3, 2);
            this.lblSwitches.Name = "lblSwitches";
            this.lblSwitches.Size = new System.Drawing.Size(190, 22);
            this.lblSwitches.TabIndex = 10;
            this.lblSwitches.Text = "Switches:";
            this.lblSwitches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panPostScriptEditor
            // 
            this.panPostScriptEditor.Controls.Add(this.panel1);
            this.panPostScriptEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPostScriptEditor.Location = new System.Drawing.Point(0, 0);
            this.panPostScriptEditor.Name = "panPostScriptEditor";
            this.panPostScriptEditor.Size = new System.Drawing.Size(491, 151);
            this.panPostScriptEditor.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApplyPostScriptPreset);
            this.panel1.Controls.Add(this.btnPostScriptPresetManager);
            this.panel1.Controls.Add(this.btnCreatePostScriptPreset);
            this.panel1.Controls.Add(this.cboPostScriptPresets);
            this.panel1.Controls.Add(this.lblPostScriptToExecute);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 27);
            this.panel1.TabIndex = 0;
            // 
            // btnApplyPostScriptPreset
            // 
            this.btnApplyPostScriptPreset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyPostScriptPreset.Image = global::Ghostscript.Studio.Properties.Resources._16x16_apply_preset;
            this.btnApplyPostScriptPreset.Location = new System.Drawing.Point(460, 2);
            this.btnApplyPostScriptPreset.Name = "btnApplyPostScriptPreset";
            this.btnApplyPostScriptPreset.Size = new System.Drawing.Size(24, 24);
            this.btnApplyPostScriptPreset.TabIndex = 17;
            this.btnApplyPostScriptPreset.UseVisualStyleBackColor = true;
            this.btnApplyPostScriptPreset.Click += new System.EventHandler(this.btnApplyPostScriptPreset_Click);
            // 
            // btnPostScriptPresetManager
            // 
            this.btnPostScriptPresetManager.Image = global::Ghostscript.Studio.Properties.Resources._16x16_preset_list;
            this.btnPostScriptPresetManager.Location = new System.Drawing.Point(207, 2);
            this.btnPostScriptPresetManager.Name = "btnPostScriptPresetManager";
            this.btnPostScriptPresetManager.Size = new System.Drawing.Size(24, 24);
            this.btnPostScriptPresetManager.TabIndex = 16;
            this.btnPostScriptPresetManager.UseVisualStyleBackColor = true;
            this.btnPostScriptPresetManager.Click += new System.EventHandler(this.btnPostScriptPresetManager_Click);
            // 
            // btnCreatePostScriptPreset
            // 
            this.btnCreatePostScriptPreset.Image = global::Ghostscript.Studio.Properties.Resources._16x16_preset_save;
            this.btnCreatePostScriptPreset.Location = new System.Drawing.Point(181, 2);
            this.btnCreatePostScriptPreset.Name = "btnCreatePostScriptPreset";
            this.btnCreatePostScriptPreset.Size = new System.Drawing.Size(24, 24);
            this.btnCreatePostScriptPreset.TabIndex = 15;
            this.btnCreatePostScriptPreset.UseVisualStyleBackColor = true;
            this.btnCreatePostScriptPreset.Click += new System.EventHandler(this.btnCreatePostScriptPreset_Click);
            // 
            // cboPostScriptPresets
            // 
            this.cboPostScriptPresets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPostScriptPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPostScriptPresets.FormattingEnabled = true;
            this.cboPostScriptPresets.Location = new System.Drawing.Point(235, 3);
            this.cboPostScriptPresets.Name = "cboPostScriptPresets";
            this.cboPostScriptPresets.Size = new System.Drawing.Size(221, 21);
            this.cboPostScriptPresets.TabIndex = 11;
            // 
            // lblPostScriptToExecute
            // 
            this.lblPostScriptToExecute.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblPostScriptToExecute.Location = new System.Drawing.Point(3, 2);
            this.lblPostScriptToExecute.Name = "lblPostScriptToExecute";
            this.lblPostScriptToExecute.Size = new System.Drawing.Size(190, 22);
            this.lblPostScriptToExecute.TabIndex = 10;
            this.lblPostScriptToExecute.Text = "(-c) PostScript to execute:";
            this.lblPostScriptToExecute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panEditorFiles
            // 
            this.panEditorFiles.Controls.Add(this.btnBrowseOutputFolder);
            this.panEditorFiles.Controls.Add(this.txtFilenameFormat);
            this.panEditorFiles.Controls.Add(this.txtOutputFolder);
            this.panEditorFiles.Controls.Add(this.lblFilenameFormat);
            this.panEditorFiles.Controls.Add(this.lblOutputFolder);
            this.panEditorFiles.Controls.Add(this.btnClearInputFiles);
            this.panEditorFiles.Controls.Add(this.btnRemoveInputFile);
            this.panEditorFiles.Controls.Add(this.btnAddInputFile);
            this.panEditorFiles.Controls.Add(this.lbInputFiles);
            this.panEditorFiles.Controls.Add(this.lblInputFiles);
            this.panEditorFiles.Controls.Add(this.panFilesTitle);
            this.panEditorFiles.Dock = System.Windows.Forms.DockStyle.Right;
            this.panEditorFiles.Location = new System.Drawing.Point(491, 0);
            this.panEditorFiles.Name = "panEditorFiles";
            this.panEditorFiles.Size = new System.Drawing.Size(360, 349);
            this.panEditorFiles.TabIndex = 0;
            // 
            // btnBrowseOutputFolder
            // 
            this.btnBrowseOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutputFolder.Image = global::Ghostscript.Studio.Properties.Resources._16x16_directory;
            this.btnBrowseOutputFolder.Location = new System.Drawing.Point(322, 169);
            this.btnBrowseOutputFolder.Name = "btnBrowseOutputFolder";
            this.btnBrowseOutputFolder.Size = new System.Drawing.Size(26, 26);
            this.btnBrowseOutputFolder.TabIndex = 12;
            this.btnBrowseOutputFolder.UseVisualStyleBackColor = true;
            this.btnBrowseOutputFolder.Click += new System.EventHandler(this.btnBrowseOutputFolder_Click);
            // 
            // txtFilenameFormat
            // 
            this.txtFilenameFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilenameFormat.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtFilenameFormat.Location = new System.Drawing.Point(11, 249);
            this.txtFilenameFormat.Name = "txtFilenameFormat";
            this.txtFilenameFormat.Size = new System.Drawing.Size(337, 22);
            this.txtFilenameFormat.TabIndex = 11;
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFolder.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtOutputFolder.Location = new System.Drawing.Point(11, 199);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(337, 22);
            this.txtOutputFolder.TabIndex = 8;
            // 
            // lblFilenameFormat
            // 
            this.lblFilenameFormat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblFilenameFormat.Location = new System.Drawing.Point(11, 224);
            this.lblFilenameFormat.Name = "lblFilenameFormat";
            this.lblFilenameFormat.Size = new System.Drawing.Size(310, 22);
            this.lblFilenameFormat.TabIndex = 10;
            this.lblFilenameFormat.Text = "Filename format:";
            this.lblFilenameFormat.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblOutputFolder.Location = new System.Drawing.Point(11, 174);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(310, 22);
            this.lblOutputFolder.TabIndex = 9;
            this.lblOutputFolder.Text = "Output folder:";
            this.lblOutputFolder.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnClearInputFiles
            // 
            this.btnClearInputFiles.Image = global::Ghostscript.Studio.Properties.Resources._16x16_clear;
            this.btnClearInputFiles.Location = new System.Drawing.Point(322, 28);
            this.btnClearInputFiles.Name = "btnClearInputFiles";
            this.btnClearInputFiles.Size = new System.Drawing.Size(26, 26);
            this.btnClearInputFiles.TabIndex = 7;
            this.btnClearInputFiles.UseVisualStyleBackColor = true;
            this.btnClearInputFiles.Click += new System.EventHandler(this.btnClearInputFiles_Click);
            // 
            // btnRemoveInputFile
            // 
            this.btnRemoveInputFile.Image = global::Ghostscript.Studio.Properties.Resources._16x16_delete;
            this.btnRemoveInputFile.Location = new System.Drawing.Point(290, 28);
            this.btnRemoveInputFile.Name = "btnRemoveInputFile";
            this.btnRemoveInputFile.Size = new System.Drawing.Size(26, 26);
            this.btnRemoveInputFile.TabIndex = 6;
            this.btnRemoveInputFile.UseVisualStyleBackColor = true;
            this.btnRemoveInputFile.Click += new System.EventHandler(this.btnRemoveInputFile_Click);
            // 
            // btnAddInputFile
            // 
            this.btnAddInputFile.Image = global::Ghostscript.Studio.Properties.Resources._16x16_add;
            this.btnAddInputFile.Location = new System.Drawing.Point(258, 28);
            this.btnAddInputFile.Name = "btnAddInputFile";
            this.btnAddInputFile.Size = new System.Drawing.Size(26, 26);
            this.btnAddInputFile.TabIndex = 0;
            this.btnAddInputFile.UseVisualStyleBackColor = true;
            this.btnAddInputFile.Click += new System.EventHandler(this.btnAddInputFile_Click);
            // 
            // lbInputFiles
            // 
            this.lbInputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInputFiles.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbInputFiles.FormattingEnabled = true;
            this.lbInputFiles.HorizontalScrollbar = true;
            this.lbInputFiles.IntegralHeight = false;
            this.lbInputFiles.ItemHeight = 14;
            this.lbInputFiles.Location = new System.Drawing.Point(11, 58);
            this.lbInputFiles.Name = "lbInputFiles";
            this.lbInputFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbInputFiles.Size = new System.Drawing.Size(337, 92);
            this.lbInputFiles.TabIndex = 3;
            // 
            // lblInputFiles
            // 
            this.lblInputFiles.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblInputFiles.Location = new System.Drawing.Point(11, 33);
            this.lblInputFiles.Name = "lblInputFiles";
            this.lblInputFiles.Size = new System.Drawing.Size(241, 22);
            this.lblInputFiles.TabIndex = 5;
            this.lblInputFiles.Text = "Input files:";
            this.lblInputFiles.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panFilesTitle
            // 
            this.panFilesTitle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panFilesTitle.Controls.Add(this.lblInputAndOutputFiles);
            this.panFilesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panFilesTitle.Location = new System.Drawing.Point(0, 0);
            this.panFilesTitle.Name = "panFilesTitle";
            this.panFilesTitle.Size = new System.Drawing.Size(360, 18);
            this.panFilesTitle.TabIndex = 2;
            // 
            // lblInputAndOutputFiles
            // 
            this.lblInputAndOutputFiles.BackColor = System.Drawing.Color.SteelBlue;
            this.lblInputAndOutputFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInputAndOutputFiles.ForeColor = System.Drawing.Color.White;
            this.lblInputAndOutputFiles.Location = new System.Drawing.Point(0, 0);
            this.lblInputAndOutputFiles.Name = "lblInputAndOutputFiles";
            this.lblInputAndOutputFiles.Size = new System.Drawing.Size(360, 18);
            this.lblInputAndOutputFiles.TabIndex = 2;
            this.lblInputAndOutputFiles.Text = "Files";
            this.lblInputAndOutputFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panOutputDebug
            // 
            this.panOutputDebug.Controls.Add(this.rtbOutput);
            this.panOutputDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panOutputDebug.Location = new System.Drawing.Point(0, 18);
            this.panOutputDebug.Name = "panOutputDebug";
            this.panOutputDebug.Size = new System.Drawing.Size(851, 92);
            this.panOutputDebug.TabIndex = 1;
            // 
            // rtbOutput
            // 
            this.rtbOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOutput.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbOutput.Location = new System.Drawing.Point(0, 0);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbOutput.ShowSelectionMargin = true;
            this.rtbOutput.Size = new System.Drawing.Size(851, 92);
            this.rtbOutput.TabIndex = 0;
            this.rtbOutput.Text = "";
            // 
            // panOutputTitle
            // 
            this.panOutputTitle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panOutputTitle.Controls.Add(this.lblOutputDebug);
            this.panOutputTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panOutputTitle.Location = new System.Drawing.Point(0, 0);
            this.panOutputTitle.Name = "panOutputTitle";
            this.panOutputTitle.Size = new System.Drawing.Size(851, 18);
            this.panOutputTitle.TabIndex = 0;
            // 
            // lblOutputDebug
            // 
            this.lblOutputDebug.BackColor = System.Drawing.Color.SteelBlue;
            this.lblOutputDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutputDebug.ForeColor = System.Drawing.Color.White;
            this.lblOutputDebug.Location = new System.Drawing.Point(0, 0);
            this.lblOutputDebug.Name = "lblOutputDebug";
            this.lblOutputDebug.Size = new System.Drawing.Size(851, 18);
            this.lblOutputDebug.TabIndex = 0;
            this.lblOutputDebug.Text = "Output - Debug";
            this.lblOutputDebug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFiles
            // 
            this.lblFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFiles.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblFiles.ForeColor = System.Drawing.Color.White;
            this.lblFiles.Location = new System.Drawing.Point(0, 0);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(784, 18);
            this.lblFiles.TabIndex = 2;
            this.lblFiles.Text = "Files";
            this.lblFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cms_Editor
            // 
            this.cms_Editor.Name = "cms_Editor";
            this.cms_Editor.Size = new System.Drawing.Size(61, 4);
            // 
            // FProcessorWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 485);
            this.Controls.Add(this.spDocAndOther);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "FProcessorWorkspace";
            this.Text = "FProcessorWorkspace";
            this.Load += new System.EventHandler(this.FProcessorWorkspace_Load);
            this.Shown += new System.EventHandler(this.FProcessorWorkspace_Shown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.spDocAndOther.Panel1.ResumeLayout(false);
            this.spDocAndOther.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spDocAndOther)).EndInit();
            this.spDocAndOther.ResumeLayout(false);
            this.spEditors.Panel1.ResumeLayout(false);
            this.spEditors.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spEditors)).EndInit();
            this.spEditors.ResumeLayout(false);
            this.panProcessorEditor.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panPostScriptEditor.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panEditorFiles.ResumeLayout(false);
            this.panEditorFiles.PerformLayout();
            this.panFilesTitle.ResumeLayout(false);
            this.panOutputDebug.ResumeLayout(false);
            this.panOutputTitle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer spDocAndOther;
        private System.Windows.Forms.Panel panOutputDebug;
        private System.Windows.Forms.Panel panOutputTitle;
        private System.Windows.Forms.Label lblOutputDebug;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip cms_Editor;
        private System.Windows.Forms.Panel panEditorFiles;
        private System.Windows.Forms.Button btnBrowseOutputFolder;
        private System.Windows.Forms.TextBox txtFilenameFormat;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label lblFilenameFormat;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.Button btnClearInputFiles;
        private System.Windows.Forms.Button btnRemoveInputFile;
        private System.Windows.Forms.Button btnAddInputFile;
        private System.Windows.Forms.ListBox lbInputFiles;
        private System.Windows.Forms.Label lblInputFiles;
        private System.Windows.Forms.Panel panFilesTitle;
        private System.Windows.Forms.Label lblInputAndOutputFiles;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel panProcessorEditor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboSwitchesPresets;
        private System.Windows.Forms.Label lblSwitches;
        private System.Windows.Forms.Button btnCreateSwitchesPreset;
        private System.Windows.Forms.Button btnApplySwitchesPreset;
        private System.Windows.Forms.Button btnSwitchesPresetManager;
        private System.Windows.Forms.SplitContainer spEditors;
        private System.Windows.Forms.Panel panPostScriptEditor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApplyPostScriptPreset;
        private System.Windows.Forms.Button btnPostScriptPresetManager;
        private System.Windows.Forms.Button btnCreatePostScriptPreset;
        private System.Windows.Forms.ComboBox cboPostScriptPresets;
        private System.Windows.Forms.Label lblPostScriptToExecute;
    }
}