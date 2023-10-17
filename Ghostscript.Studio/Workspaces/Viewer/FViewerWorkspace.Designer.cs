namespace Ghostscript.Studio.Workspaces.Viewer
{
    partial class FViewerWorkspace
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
            this.panHost = new System.Windows.Forms.Panel();
            this.pbPage = new System.Windows.Forms.PictureBox();
            this.panHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPage)).BeginInit();
            this.SuspendLayout();
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
            this.panHost.Size = new System.Drawing.Size(659, 431);
            this.panHost.TabIndex = 6;
            // 
            // pbPage
            // 
            this.pbPage.BackColor = System.Drawing.Color.White;
            this.pbPage.Location = new System.Drawing.Point(4, 4);
            this.pbPage.Name = "pbPage";
            this.pbPage.Size = new System.Drawing.Size(126, 118);
            this.pbPage.TabIndex = 1;
            this.pbPage.TabStop = false;
            // 
            // FViewerWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 431);
            this.Controls.Add(this.panHost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "FViewerWorkspace";
            this.Text = "FViewer";
            this.Shown += new System.EventHandler(this.FViewerWorkspace_Shown);
            this.panHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panHost;
        private System.Windows.Forms.PictureBox pbPage;

    }
}