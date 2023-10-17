namespace Ghostscript.Studio.Windows
{
    partial class FAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAbout));
            this.btnClose = new System.Windows.Forms.Button();
            this.panTop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTopBorder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.wbComponentsUsed = new System.Windows.Forms.WebBrowser();
            this.lblComponentsUsed = new System.Windows.Forms.Label();
            this.wbAbout = new System.Windows.Forms.WebBrowser();
            this.lblTranslations = new System.Windows.Forms.Label();
            this.wbTranslations = new System.Windows.Forms.WebBrowser();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(409, 441);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panTop
            // 
            this.panTop.BackColor = System.Drawing.Color.White;
            this.panTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panTop.Controls.Add(this.pictureBox1);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(492, 73);
            this.panTop.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Ghostscript.Studio.Properties.Resources.Ghostscript_Studio;
            this.pictureBox1.Location = new System.Drawing.Point(126, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTopBorder
            // 
            this.lblTopBorder.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTopBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTopBorder.Location = new System.Drawing.Point(0, 73);
            this.lblTopBorder.Name = "lblTopBorder";
            this.lblTopBorder.Size = new System.Drawing.Size(492, 1);
            this.lblTopBorder.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(0, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 1);
            this.label1.TabIndex = 3;
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVersion.Location = new System.Drawing.Point(5, 87);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(340, 22);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Version: x.x.x.x.";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wbComponentsUsed
            // 
            this.wbComponentsUsed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbComponentsUsed.IsWebBrowserContextMenuEnabled = false;
            this.wbComponentsUsed.Location = new System.Drawing.Point(9, 221);
            this.wbComponentsUsed.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbComponentsUsed.Name = "wbComponentsUsed";
            this.wbComponentsUsed.ScriptErrorsSuppressed = true;
            this.wbComponentsUsed.Size = new System.Drawing.Size(475, 65);
            this.wbComponentsUsed.TabIndex = 5;
            // 
            // lblComponentsUsed
            // 
            this.lblComponentsUsed.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblComponentsUsed.Location = new System.Drawing.Point(6, 198);
            this.lblComponentsUsed.Name = "lblComponentsUsed";
            this.lblComponentsUsed.Size = new System.Drawing.Size(474, 22);
            this.lblComponentsUsed.TabIndex = 7;
            this.lblComponentsUsed.Text = "Components used in this application:";
            this.lblComponentsUsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wbAbout
            // 
            this.wbAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbAbout.IsWebBrowserContextMenuEnabled = false;
            this.wbAbout.Location = new System.Drawing.Point(9, 120);
            this.wbAbout.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbAbout.Name = "wbAbout";
            this.wbAbout.ScriptErrorsSuppressed = true;
            this.wbAbout.Size = new System.Drawing.Size(475, 71);
            this.wbAbout.TabIndex = 8;
            // 
            // lblTranslations
            // 
            this.lblTranslations.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTranslations.Location = new System.Drawing.Point(6, 295);
            this.lblTranslations.Name = "lblTranslations";
            this.lblTranslations.Size = new System.Drawing.Size(474, 22);
            this.lblTranslations.TabIndex = 11;
            this.lblTranslations.Text = "Translations:";
            this.lblTranslations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wbTranslations
            // 
            this.wbTranslations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbTranslations.IsWebBrowserContextMenuEnabled = false;
            this.wbTranslations.Location = new System.Drawing.Point(9, 318);
            this.wbTranslations.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbTranslations.Name = "wbTranslations";
            this.wbTranslations.ScriptErrorsSuppressed = true;
            this.wbTranslations.Size = new System.Drawing.Size(475, 101);
            this.wbTranslations.TabIndex = 10;
            // 
            // FAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 472);
            this.Controls.Add(this.lblTranslations);
            this.Controls.Add(this.wbTranslations);
            this.Controls.Add(this.wbAbout);
            this.Controls.Add(this.lblComponentsUsed);
            this.Controls.Add(this.wbComponentsUsed);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTopBorder);
            this.Controls.Add(this.panTop);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FAbout";
            this.Shown += new System.EventHandler(this.FAbout_Shown);
            this.panTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Label lblTopBorder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.WebBrowser wbComponentsUsed;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblComponentsUsed;
        private System.Windows.Forms.WebBrowser wbAbout;
        private System.Windows.Forms.Label lblTranslations;
        private System.Windows.Forms.WebBrowser wbTranslations;
    }
}