namespace Ghostscript.Studio.Windows
{
    partial class FMultiPageSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMultiPageSettings));
            this.nudDpi = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkOpenWindowsExplorerWhenDone = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbAllPages = new System.Windows.Forms.RadioButton();
            this.rbCustomPages = new System.Windows.Forms.RadioButton();
            this.rbPageRange = new System.Windows.Forms.RadioButton();
            this.gbPages = new System.Windows.Forms.GroupBox();
            this.lblCustomPages = new System.Windows.Forms.Label();
            this.txtCustomPages = new System.Windows.Forms.TextBox();
            this.nudPageTo = new System.Windows.Forms.NumericUpDown();
            this.lblPageTo = new System.Windows.Forms.Label();
            this.nudPageFrom = new System.Windows.Forms.NumericUpDown();
            this.lblPageFrom = new System.Windows.Forms.Label();
            this.gbResolution = new System.Windows.Forms.GroupBox();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.lblFileType = new System.Windows.Forms.Label();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.txtFilenameFormat = new System.Windows.Forms.TextBox();
            this.lblFilenameFormat = new System.Windows.Forms.Label();
            this.btnBrowseOutputFolder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.lblFolder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudDpi)).BeginInit();
            this.gbPages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPageTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPageFrom)).BeginInit();
            this.gbResolution.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudDpi
            // 
            this.nudDpi.Location = new System.Drawing.Point(51, 30);
            this.nudDpi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudDpi.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudDpi.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDpi.Name = "nudDpi";
            this.nudDpi.Size = new System.Drawing.Size(93, 22);
            this.nudDpi.TabIndex = 1;
            this.nudDpi.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(365, 502);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(473, 502);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(-8, 489);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(607, 2);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // chkOpenWindowsExplorerWhenDone
            // 
            this.chkOpenWindowsExplorerWhenDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkOpenWindowsExplorerWhenDone.AutoSize = true;
            this.chkOpenWindowsExplorerWhenDone.Checked = true;
            this.chkOpenWindowsExplorerWhenDone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenWindowsExplorerWhenDone.Location = new System.Drawing.Point(20, 455);
            this.chkOpenWindowsExplorerWhenDone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkOpenWindowsExplorerWhenDone.Name = "chkOpenWindowsExplorerWhenDone";
            this.chkOpenWindowsExplorerWhenDone.Size = new System.Drawing.Size(324, 20);
            this.chkOpenWindowsExplorerWhenDone.TabIndex = 4;
            this.chkOpenWindowsExplorerWhenDone.Text = "Open file location in Windows Explorer when done";
            this.chkOpenWindowsExplorerWhenDone.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(-11, 437);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(607, 2);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // rbAllPages
            // 
            this.rbAllPages.AutoSize = true;
            this.rbAllPages.Checked = true;
            this.rbAllPages.Location = new System.Drawing.Point(23, 25);
            this.rbAllPages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbAllPages.Name = "rbAllPages";
            this.rbAllPages.Size = new System.Drawing.Size(86, 20);
            this.rbAllPages.TabIndex = 0;
            this.rbAllPages.TabStop = true;
            this.rbAllPages.Text = "All Pages";
            this.rbAllPages.UseVisualStyleBackColor = true;
            this.rbAllPages.CheckedChanged += new System.EventHandler(this.rbAllPages_CheckedChanged);
            // 
            // rbCustomPages
            // 
            this.rbCustomPages.AutoSize = true;
            this.rbCustomPages.Location = new System.Drawing.Point(23, 86);
            this.rbCustomPages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbCustomPages.Name = "rbCustomPages";
            this.rbCustomPages.Size = new System.Drawing.Size(116, 20);
            this.rbCustomPages.TabIndex = 6;
            this.rbCustomPages.Text = "Custom Pages";
            this.rbCustomPages.UseVisualStyleBackColor = true;
            this.rbCustomPages.CheckedChanged += new System.EventHandler(this.rbCustomPages_CheckedChanged);
            // 
            // rbPageRange
            // 
            this.rbPageRange.AutoSize = true;
            this.rbPageRange.Location = new System.Drawing.Point(23, 55);
            this.rbPageRange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbPageRange.Name = "rbPageRange";
            this.rbPageRange.Size = new System.Drawing.Size(105, 20);
            this.rbPageRange.TabIndex = 1;
            this.rbPageRange.Text = "Page Range";
            this.rbPageRange.UseVisualStyleBackColor = true;
            this.rbPageRange.CheckedChanged += new System.EventHandler(this.rbPageRange_CheckedChanged);
            // 
            // gbPages
            // 
            this.gbPages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPages.Controls.Add(this.lblCustomPages);
            this.gbPages.Controls.Add(this.txtCustomPages);
            this.gbPages.Controls.Add(this.nudPageTo);
            this.gbPages.Controls.Add(this.lblPageTo);
            this.gbPages.Controls.Add(this.nudPageFrom);
            this.gbPages.Controls.Add(this.lblPageFrom);
            this.gbPages.Controls.Add(this.rbAllPages);
            this.gbPages.Controls.Add(this.rbPageRange);
            this.gbPages.Controls.Add(this.rbCustomPages);
            this.gbPages.Location = new System.Drawing.Point(13, 10);
            this.gbPages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPages.Name = "gbPages";
            this.gbPages.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPages.Size = new System.Drawing.Size(559, 123);
            this.gbPages.TabIndex = 0;
            this.gbPages.TabStop = false;
            this.gbPages.Text = "Pagess";
            // 
            // lblCustomPages
            // 
            this.lblCustomPages.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCustomPages.Location = new System.Drawing.Point(399, 84);
            this.lblCustomPages.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomPages.Name = "lblCustomPages";
            this.lblCustomPages.Size = new System.Drawing.Size(132, 25);
            this.lblCustomPages.TabIndex = 8;
            this.lblCustomPages.Text = "e.g.: 1,2,5,7,8";
            this.lblCustomPages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomPages
            // 
            this.txtCustomPages.Location = new System.Drawing.Point(228, 85);
            this.txtCustomPages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCustomPages.Name = "txtCustomPages";
            this.txtCustomPages.Size = new System.Drawing.Size(147, 22);
            this.txtCustomPages.TabIndex = 7;
            // 
            // nudPageTo
            // 
            this.nudPageTo.Location = new System.Drawing.Point(441, 53);
            this.nudPageTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudPageTo.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudPageTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPageTo.Name = "nudPageTo";
            this.nudPageTo.Size = new System.Drawing.Size(93, 22);
            this.nudPageTo.TabIndex = 5;
            this.nudPageTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPageTo
            // 
            this.lblPageTo.Location = new System.Drawing.Point(395, 53);
            this.lblPageTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPageTo.Name = "lblPageTo";
            this.lblPageTo.Size = new System.Drawing.Size(68, 25);
            this.lblPageTo.TabIndex = 4;
            this.lblPageTo.Text = "To:";
            this.lblPageTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudPageFrom
            // 
            this.nudPageFrom.Location = new System.Drawing.Point(284, 53);
            this.nudPageFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudPageFrom.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudPageFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPageFrom.Name = "nudPageFrom";
            this.nudPageFrom.Size = new System.Drawing.Size(93, 22);
            this.nudPageFrom.TabIndex = 3;
            this.nudPageFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPageFrom
            // 
            this.lblPageFrom.Location = new System.Drawing.Point(220, 53);
            this.lblPageFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPageFrom.Name = "lblPageFrom";
            this.lblPageFrom.Size = new System.Drawing.Size(143, 25);
            this.lblPageFrom.TabIndex = 2;
            this.lblPageFrom.Text = "From:";
            this.lblPageFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbResolution
            // 
            this.gbResolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResolution.Controls.Add(this.nudDpi);
            this.gbResolution.Controls.Add(this.label1);
            this.gbResolution.Location = new System.Drawing.Point(13, 140);
            this.gbResolution.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbResolution.Name = "gbResolution";
            this.gbResolution.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbResolution.Size = new System.Drawing.Size(559, 74);
            this.gbResolution.TabIndex = 1;
            this.gbResolution.TabStop = false;
            this.gbResolution.Text = "DPI - Resolution";
            // 
            // gbOutput
            // 
            this.gbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOutput.Controls.Add(this.lblFileType);
            this.gbOutput.Controls.Add(this.cboFileType);
            this.gbOutput.Controls.Add(this.txtFilenameFormat);
            this.gbOutput.Controls.Add(this.lblFilenameFormat);
            this.gbOutput.Controls.Add(this.btnBrowseOutputFolder);
            this.gbOutput.Controls.Add(this.txtFolder);
            this.gbOutput.Controls.Add(this.lblFolder);
            this.gbOutput.Location = new System.Drawing.Point(13, 222);
            this.gbOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOutput.Size = new System.Drawing.Size(559, 201);
            this.gbOutput.TabIndex = 2;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output";
            // 
            // lblFileType
            // 
            this.lblFileType.Location = new System.Drawing.Point(20, 132);
            this.lblFileType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(447, 18);
            this.lblFileType.TabIndex = 5;
            this.lblFileType.Text = "File type:";
            this.lblFileType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cboFileType
            // 
            this.cboFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileType.FormattingEnabled = true;
            this.cboFileType.Location = new System.Drawing.Point(24, 154);
            this.cboFileType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Size = new System.Drawing.Size(509, 24);
            this.cboFileType.TabIndex = 6;
            // 
            // txtFilenameFormat
            // 
            this.txtFilenameFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilenameFormat.Location = new System.Drawing.Point(24, 101);
            this.txtFilenameFormat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilenameFormat.Name = "txtFilenameFormat";
            this.txtFilenameFormat.Size = new System.Drawing.Size(509, 22);
            this.txtFilenameFormat.TabIndex = 4;
            this.txtFilenameFormat.Text = "customname-#pagenum#";
            // 
            // lblFilenameFormat
            // 
            this.lblFilenameFormat.Location = new System.Drawing.Point(20, 79);
            this.lblFilenameFormat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilenameFormat.Name = "lblFilenameFormat";
            this.lblFilenameFormat.Size = new System.Drawing.Size(447, 18);
            this.lblFilenameFormat.TabIndex = 3;
            this.lblFilenameFormat.Text = "Filename format:";
            this.lblFilenameFormat.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnBrowseOutputFolder
            // 
            this.btnBrowseOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutputFolder.Image = global::Ghostscript.Studio.Properties.Resources._16x16_directory;
            this.btnBrowseOutputFolder.Location = new System.Drawing.Point(500, 43);
            this.btnBrowseOutputFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseOutputFolder.Name = "btnBrowseOutputFolder";
            this.btnBrowseOutputFolder.Size = new System.Drawing.Size(35, 32);
            this.btnBrowseOutputFolder.TabIndex = 2;
            this.btnBrowseOutputFolder.UseVisualStyleBackColor = true;
            this.btnBrowseOutputFolder.Click += new System.EventHandler(this.btnBrowseOutputFolder_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(24, 48);
            this.txtFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(465, 22);
            this.txtFolder.TabIndex = 1;
            // 
            // lblFolder
            // 
            this.lblFolder.Location = new System.Drawing.Point(20, 26);
            this.lblFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(447, 18);
            this.lblFolder.TabIndex = 0;
            this.lblFolder.Text = "Folder:";
            this.lblFolder.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FMultiPageSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 542);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbResolution);
            this.Controls.Add(this.gbPages);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkOpenWindowsExplorerWhenDone);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FMultiPageSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FMultiPageSettings";
            ((System.ComponentModel.ISupportInitialize)(this.nudDpi)).EndInit();
            this.gbPages.ResumeLayout(false);
            this.gbPages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPageTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPageFrom)).EndInit();
            this.gbResolution.ResumeLayout(false);
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.NumericUpDown nudDpi;
        public System.Windows.Forms.CheckBox chkOpenWindowsExplorerWhenDone;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbAllPages;
        private System.Windows.Forms.RadioButton rbCustomPages;
        private System.Windows.Forms.RadioButton rbPageRange;
        private System.Windows.Forms.GroupBox gbPages;
        private System.Windows.Forms.GroupBox gbResolution;
        public System.Windows.Forms.NumericUpDown nudPageTo;
        private System.Windows.Forms.Label lblPageTo;
        public System.Windows.Forms.NumericUpDown nudPageFrom;
        private System.Windows.Forms.Label lblPageFrom;
        private System.Windows.Forms.Label lblCustomPages;
        private System.Windows.Forms.TextBox txtCustomPages;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.Label lblFilenameFormat;
        private System.Windows.Forms.Button btnBrowseOutputFolder;
        private System.Windows.Forms.Label lblFolder;
        public System.Windows.Forms.TextBox txtFilenameFormat;
        public System.Windows.Forms.TextBox txtFolder;
        public System.Windows.Forms.ComboBox cboFileType;
    }
}