namespace Ghostscript.Studio.Workspaces.Editor
{
    partial class FEditorWorkspace
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
            this.panEditor = new System.Windows.Forms.Panel();
            this.spEditorViewer = new System.Windows.Forms.SplitContainer();
            this.panHost = new System.Windows.Forms.Panel();
            this.pbPage = new System.Windows.Forms.PictureBox();
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
            this.panEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spEditorViewer)).BeginInit();
            this.spEditorViewer.Panel2.SuspendLayout();
            this.spEditorViewer.SuspendLayout();
            this.panHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPage)).BeginInit();
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
            this.statusStrip.Location = new System.Drawing.Point(0, 540);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 7;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(384, 17);
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(384, 17);
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
            this.spDocAndOther.Panel1.Controls.Add(this.panEditor);
            // 
            // spDocAndOther.Panel2
            // 
            this.spDocAndOther.Panel2.Controls.Add(this.panOutputDebug);
            this.spDocAndOther.Panel2.Controls.Add(this.panOutputTitle);
            this.spDocAndOther.Size = new System.Drawing.Size(784, 540);
            this.spDocAndOther.SplitterDistance = 356;
            this.spDocAndOther.TabIndex = 6;
            // 
            // panEditor
            // 
            this.panEditor.Controls.Add(this.spEditorViewer);
            this.panEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panEditor.Location = new System.Drawing.Point(0, 0);
            this.panEditor.Name = "panEditor";
            this.panEditor.Size = new System.Drawing.Size(784, 356);
            this.panEditor.TabIndex = 2;
            // 
            // spEditorViewer
            // 
            this.spEditorViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spEditorViewer.Location = new System.Drawing.Point(0, 0);
            this.spEditorViewer.Name = "spEditorViewer";
            // 
            // spEditorViewer.Panel2
            // 
            this.spEditorViewer.Panel2.Controls.Add(this.panHost);
            this.spEditorViewer.Size = new System.Drawing.Size(784, 356);
            this.spEditorViewer.SplitterDistance = 465;
            this.spEditorViewer.TabIndex = 0;
            // 
            // panHost
            // 
            this.panHost.AutoScroll = true;
            this.panHost.BackColor = System.Drawing.Color.DarkGray;
            this.panHost.Controls.Add(this.pbPage);
            this.panHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panHost.Location = new System.Drawing.Point(0, 0);
            this.panHost.Name = "panHost";
            this.panHost.Padding = new System.Windows.Forms.Padding(4);
            this.panHost.Size = new System.Drawing.Size(315, 356);
            this.panHost.TabIndex = 7;
            // 
            // pbPage
            // 
            this.pbPage.BackColor = System.Drawing.Color.White;
            this.pbPage.Location = new System.Drawing.Point(4, 4);
            this.pbPage.Name = "pbPage";
            this.pbPage.Size = new System.Drawing.Size(1, 1);
            this.pbPage.TabIndex = 1;
            this.pbPage.TabStop = false;
            // 
            // panOutputDebug
            // 
            this.panOutputDebug.Controls.Add(this.rtbOutput);
            this.panOutputDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panOutputDebug.Location = new System.Drawing.Point(0, 18);
            this.panOutputDebug.Name = "panOutputDebug";
            this.panOutputDebug.Size = new System.Drawing.Size(784, 162);
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
            this.rtbOutput.Size = new System.Drawing.Size(784, 162);
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
            this.panOutputTitle.Size = new System.Drawing.Size(784, 18);
            this.panOutputTitle.TabIndex = 0;
            // 
            // lblOutputDebug
            // 
            this.lblOutputDebug.BackColor = System.Drawing.Color.SteelBlue;
            this.lblOutputDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutputDebug.ForeColor = System.Drawing.Color.White;
            this.lblOutputDebug.Location = new System.Drawing.Point(0, 0);
            this.lblOutputDebug.Name = "lblOutputDebug";
            this.lblOutputDebug.Size = new System.Drawing.Size(784, 18);
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
            // FEditorWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.spDocAndOther);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "FEditorWorkspace";
            this.Text = "FProcessorWorkspace";
            this.Load += new System.EventHandler(this.FProcessorWorkspace_Load);
            this.Shown += new System.EventHandler(this.FProcessorWorkspace_Shown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.spDocAndOther.Panel1.ResumeLayout(false);
            this.spDocAndOther.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spDocAndOther)).EndInit();
            this.spDocAndOther.ResumeLayout(false);
            this.panEditor.ResumeLayout(false);
            this.spEditorViewer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spEditorViewer)).EndInit();
            this.spEditorViewer.ResumeLayout(false);
            this.panHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPage)).EndInit();
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
        private System.Windows.Forms.Panel panEditor;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip cms_Editor;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.SplitContainer spEditorViewer;
        private System.Windows.Forms.Panel panHost;
        private System.Windows.Forms.PictureBox pbPage;
    }
}