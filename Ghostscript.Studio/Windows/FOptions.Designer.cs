namespace Ghostscript.Studio.Windows
{
    partial class FOptions
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tpGhostscript = new System.Windows.Forms.TabPage();
            this.cboGhostscriptVersion = new System.Windows.Forms.ComboBox();
            this.lblGhostscriptUseVersion = new System.Windows.Forms.Label();
            this.tpViewer = new System.Windows.Forms.TabPage();
            this.lblViewerProgressiveUpdateIntervalMilliseconds = new System.Windows.Forms.Label();
            this.nudViewerProgressiveUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.lblViewerProgressiveUpdateInterval = new System.Windows.Forms.Label();
            this.chkViewerProgressiveUpdate = new System.Windows.Forms.CheckBox();
            this.tpEditor = new System.Windows.Forms.TabPage();
            this.lblEditorProgressiveUpdateIntervalMilliseconds = new System.Windows.Forms.Label();
            this.nudEditorProgressiveUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.lblEditorProgressiveUpdateInterval = new System.Windows.Forms.Label();
            this.chkEditorProgressiveUpdate = new System.Windows.Forms.CheckBox();
            this.tpOther = new System.Windows.Forms.TabPage();
            this.chkOptionsShowSupportWindow = new System.Windows.Forms.CheckBox();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.lblOtherLanguage = new System.Windows.Forms.Label();
            this.tabOptions.SuspendLayout();
            this.tpGhostscript.SuspendLayout();
            this.tpViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudViewerProgressiveUpdateInterval)).BeginInit();
            this.tpEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditorProgressiveUpdateInterval)).BeginInit();
            this.tpOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(466, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(385, 121);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tabOptions
            // 
            this.tabOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOptions.Controls.Add(this.tpGhostscript);
            this.tabOptions.Controls.Add(this.tpViewer);
            this.tabOptions.Controls.Add(this.tpEditor);
            this.tabOptions.Controls.Add(this.tpOther);
            this.tabOptions.Location = new System.Drawing.Point(9, 10);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(533, 104);
            this.tabOptions.TabIndex = 3;
            // 
            // tpGhostscript
            // 
            this.tpGhostscript.Controls.Add(this.cboGhostscriptVersion);
            this.tpGhostscript.Controls.Add(this.lblGhostscriptUseVersion);
            this.tpGhostscript.Location = new System.Drawing.Point(4, 22);
            this.tpGhostscript.Name = "tpGhostscript";
            this.tpGhostscript.Padding = new System.Windows.Forms.Padding(3);
            this.tpGhostscript.Size = new System.Drawing.Size(525, 78);
            this.tpGhostscript.TabIndex = 0;
            this.tpGhostscript.Text = "Ghostscript";
            this.tpGhostscript.UseVisualStyleBackColor = true;
            // 
            // cboGhostscriptVersion
            // 
            this.cboGhostscriptVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGhostscriptVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGhostscriptVersion.FormattingEnabled = true;
            this.cboGhostscriptVersion.Location = new System.Drawing.Point(115, 9);
            this.cboGhostscriptVersion.Name = "cboGhostscriptVersion";
            this.cboGhostscriptVersion.Size = new System.Drawing.Size(288, 21);
            this.cboGhostscriptVersion.TabIndex = 8;
            // 
            // lblGhostscriptUseVersion
            // 
            this.lblGhostscriptUseVersion.Location = new System.Drawing.Point(9, 8);
            this.lblGhostscriptUseVersion.Name = "lblGhostscriptUseVersion";
            this.lblGhostscriptUseVersion.Size = new System.Drawing.Size(127, 22);
            this.lblGhostscriptUseVersion.TabIndex = 7;
            this.lblGhostscriptUseVersion.Text = "Use version:";
            this.lblGhostscriptUseVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpViewer
            // 
            this.tpViewer.Controls.Add(this.lblViewerProgressiveUpdateIntervalMilliseconds);
            this.tpViewer.Controls.Add(this.nudViewerProgressiveUpdateInterval);
            this.tpViewer.Controls.Add(this.lblViewerProgressiveUpdateInterval);
            this.tpViewer.Controls.Add(this.chkViewerProgressiveUpdate);
            this.tpViewer.Location = new System.Drawing.Point(4, 23);
            this.tpViewer.Name = "tpViewer";
            this.tpViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tpViewer.Size = new System.Drawing.Size(525, 77);
            this.tpViewer.TabIndex = 2;
            this.tpViewer.Text = "Viewer";
            this.tpViewer.UseVisualStyleBackColor = true;
            // 
            // lblViewerProgressiveUpdateIntervalMilliseconds
            // 
            this.lblViewerProgressiveUpdateIntervalMilliseconds.Location = new System.Drawing.Point(183, 34);
            this.lblViewerProgressiveUpdateIntervalMilliseconds.Name = "lblViewerProgressiveUpdateIntervalMilliseconds";
            this.lblViewerProgressiveUpdateIntervalMilliseconds.Size = new System.Drawing.Size(127, 20);
            this.lblViewerProgressiveUpdateIntervalMilliseconds.TabIndex = 10;
            this.lblViewerProgressiveUpdateIntervalMilliseconds.Text = "milliseconds";
            this.lblViewerProgressiveUpdateIntervalMilliseconds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudViewerProgressiveUpdateInterval
            // 
            this.nudViewerProgressiveUpdateInterval.Location = new System.Drawing.Point(107, 34);
            this.nudViewerProgressiveUpdateInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudViewerProgressiveUpdateInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudViewerProgressiveUpdateInterval.Name = "nudViewerProgressiveUpdateInterval";
            this.nudViewerProgressiveUpdateInterval.Size = new System.Drawing.Size(70, 20);
            this.nudViewerProgressiveUpdateInterval.TabIndex = 1;
            this.nudViewerProgressiveUpdateInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblViewerProgressiveUpdateInterval
            // 
            this.lblViewerProgressiveUpdateInterval.Location = new System.Drawing.Point(26, 34);
            this.lblViewerProgressiveUpdateInterval.Name = "lblViewerProgressiveUpdateInterval";
            this.lblViewerProgressiveUpdateInterval.Size = new System.Drawing.Size(127, 20);
            this.lblViewerProgressiveUpdateInterval.TabIndex = 9;
            this.lblViewerProgressiveUpdateInterval.Text = "Interval:";
            this.lblViewerProgressiveUpdateInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkViewerProgressiveUpdate
            // 
            this.chkViewerProgressiveUpdate.AutoSize = true;
            this.chkViewerProgressiveUpdate.Location = new System.Drawing.Point(9, 12);
            this.chkViewerProgressiveUpdate.Name = "chkViewerProgressiveUpdate";
            this.chkViewerProgressiveUpdate.Size = new System.Drawing.Size(117, 17);
            this.chkViewerProgressiveUpdate.TabIndex = 0;
            this.chkViewerProgressiveUpdate.Text = "Progressive update";
            this.chkViewerProgressiveUpdate.UseVisualStyleBackColor = true;
            this.chkViewerProgressiveUpdate.CheckedChanged += new System.EventHandler(this.chkViewerProgressiveUpdate_CheckedChanged);
            // 
            // tpEditor
            // 
            this.tpEditor.Controls.Add(this.lblEditorProgressiveUpdateIntervalMilliseconds);
            this.tpEditor.Controls.Add(this.nudEditorProgressiveUpdateInterval);
            this.tpEditor.Controls.Add(this.lblEditorProgressiveUpdateInterval);
            this.tpEditor.Controls.Add(this.chkEditorProgressiveUpdate);
            this.tpEditor.Location = new System.Drawing.Point(4, 23);
            this.tpEditor.Name = "tpEditor";
            this.tpEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tpEditor.Size = new System.Drawing.Size(525, 77);
            this.tpEditor.TabIndex = 3;
            this.tpEditor.Text = "Editor";
            this.tpEditor.UseVisualStyleBackColor = true;
            // 
            // lblEditorProgressiveUpdateIntervalMilliseconds
            // 
            this.lblEditorProgressiveUpdateIntervalMilliseconds.Location = new System.Drawing.Point(183, 34);
            this.lblEditorProgressiveUpdateIntervalMilliseconds.Name = "lblEditorProgressiveUpdateIntervalMilliseconds";
            this.lblEditorProgressiveUpdateIntervalMilliseconds.Size = new System.Drawing.Size(127, 20);
            this.lblEditorProgressiveUpdateIntervalMilliseconds.TabIndex = 14;
            this.lblEditorProgressiveUpdateIntervalMilliseconds.Text = "milliseconds";
            this.lblEditorProgressiveUpdateIntervalMilliseconds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudEditorProgressiveUpdateInterval
            // 
            this.nudEditorProgressiveUpdateInterval.Location = new System.Drawing.Point(107, 34);
            this.nudEditorProgressiveUpdateInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudEditorProgressiveUpdateInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudEditorProgressiveUpdateInterval.Name = "nudEditorProgressiveUpdateInterval";
            this.nudEditorProgressiveUpdateInterval.Size = new System.Drawing.Size(70, 20);
            this.nudEditorProgressiveUpdateInterval.TabIndex = 12;
            this.nudEditorProgressiveUpdateInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblEditorProgressiveUpdateInterval
            // 
            this.lblEditorProgressiveUpdateInterval.Location = new System.Drawing.Point(26, 34);
            this.lblEditorProgressiveUpdateInterval.Name = "lblEditorProgressiveUpdateInterval";
            this.lblEditorProgressiveUpdateInterval.Size = new System.Drawing.Size(127, 20);
            this.lblEditorProgressiveUpdateInterval.TabIndex = 13;
            this.lblEditorProgressiveUpdateInterval.Text = "Interval:";
            this.lblEditorProgressiveUpdateInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEditorProgressiveUpdate
            // 
            this.chkEditorProgressiveUpdate.AutoSize = true;
            this.chkEditorProgressiveUpdate.Location = new System.Drawing.Point(9, 12);
            this.chkEditorProgressiveUpdate.Name = "chkEditorProgressiveUpdate";
            this.chkEditorProgressiveUpdate.Size = new System.Drawing.Size(117, 17);
            this.chkEditorProgressiveUpdate.TabIndex = 11;
            this.chkEditorProgressiveUpdate.Text = "Progressive update";
            this.chkEditorProgressiveUpdate.UseVisualStyleBackColor = true;
            this.chkEditorProgressiveUpdate.CheckedChanged += new System.EventHandler(this.chkEditorProgressiveUpdate_CheckedChanged);
            // 
            // tpOther
            // 
            this.tpOther.Controls.Add(this.chkOptionsShowSupportWindow);
            this.tpOther.Controls.Add(this.cboLanguage);
            this.tpOther.Controls.Add(this.lblOtherLanguage);
            this.tpOther.Location = new System.Drawing.Point(4, 23);
            this.tpOther.Name = "tpOther";
            this.tpOther.Padding = new System.Windows.Forms.Padding(3);
            this.tpOther.Size = new System.Drawing.Size(525, 77);
            this.tpOther.TabIndex = 1;
            this.tpOther.Text = "Other options";
            this.tpOther.UseVisualStyleBackColor = true;
            // 
            // chkOptionsShowSupportWindow
            // 
            this.chkOptionsShowSupportWindow.AutoSize = true;
            this.chkOptionsShowSupportWindow.Location = new System.Drawing.Point(12, 47);
            this.chkOptionsShowSupportWindow.Name = "chkOptionsShowSupportWindow";
            this.chkOptionsShowSupportWindow.Size = new System.Drawing.Size(273, 17);
            this.chkOptionsShowSupportWindow.TabIndex = 10;
            this.chkOptionsShowSupportWindow.Text = "Show support window (NAG) when application starts";
            this.chkOptionsShowSupportWindow.UseVisualStyleBackColor = true;
            // 
            // cboLanguage
            // 
            this.cboLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(115, 9);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(395, 21);
            this.cboLanguage.TabIndex = 9;
            // 
            // lblOtherLanguage
            // 
            this.lblOtherLanguage.Location = new System.Drawing.Point(9, 8);
            this.lblOtherLanguage.Name = "lblOtherLanguage";
            this.lblOtherLanguage.Size = new System.Drawing.Size(127, 22);
            this.lblOtherLanguage.TabIndex = 8;
            this.lblOtherLanguage.Text = "Language:";
            this.lblOtherLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 152);
            this.Controls.Add(this.tabOptions);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FOptions";
            this.Load += new System.EventHandler(this.FOptions_Load);
            this.tabOptions.ResumeLayout(false);
            this.tpGhostscript.ResumeLayout(false);
            this.tpViewer.ResumeLayout(false);
            this.tpViewer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudViewerProgressiveUpdateInterval)).EndInit();
            this.tpEditor.ResumeLayout(false);
            this.tpEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditorProgressiveUpdateInterval)).EndInit();
            this.tpOther.ResumeLayout(false);
            this.tpOther.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tpGhostscript;
        private System.Windows.Forms.TabPage tpOther;
        private System.Windows.Forms.Label lblGhostscriptUseVersion;
        private System.Windows.Forms.Label lblOtherLanguage;
        private System.Windows.Forms.ComboBox cboGhostscriptVersion;
        private System.Windows.Forms.ComboBox cboLanguage;
        private System.Windows.Forms.TabPage tpViewer;
        private System.Windows.Forms.TabPage tpEditor;
        private System.Windows.Forms.CheckBox chkViewerProgressiveUpdate;
        private System.Windows.Forms.NumericUpDown nudViewerProgressiveUpdateInterval;
        private System.Windows.Forms.Label lblViewerProgressiveUpdateIntervalMilliseconds;
        private System.Windows.Forms.Label lblViewerProgressiveUpdateInterval;
        private System.Windows.Forms.Label lblEditorProgressiveUpdateIntervalMilliseconds;
        private System.Windows.Forms.NumericUpDown nudEditorProgressiveUpdateInterval;
        private System.Windows.Forms.Label lblEditorProgressiveUpdateInterval;
        private System.Windows.Forms.CheckBox chkEditorProgressiveUpdate;
        private System.Windows.Forms.CheckBox chkOptionsShowSupportWindow;
    }
}