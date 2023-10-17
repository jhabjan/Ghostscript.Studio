#region This file is part of Ghostscript.Studio application
//
// FMultiPageSettings.cs
//
// Author: Josip Habjan (habjan@gmail.com, http://www.linkedin.com/in/habjan) 
// Copyright (c) 2013 - 2023 Josip Habjan. All rights reserved.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace Ghostscript.Studio.Windows
{
    public partial class FMultiPageSettings : Form
    {

        #region Private variables

        private int _firstPage;
        private int _lastPage;

        #endregion

        #region Constructor

        public FMultiPageSettings(int firstPage, int lastPage)
        {
            _firstPage = firstPage;
            _lastPage = lastPage;

            InitializeComponent();

            this.Font = Program.DefaultFont;

            nudPageFrom.Minimum = _firstPage;
            nudPageFrom.Maximum = _lastPage;
            nudPageTo.Minimum = _firstPage;
            nudPageTo.Maximum = _lastPage;

            nudPageFrom.Value = firstPage;
            nudPageTo.Value = lastPage;

            this.TranslateUI();

            cboFileType.Items.Add(new ComboBoxItem(".png", "PNG"));
            cboFileType.Items.Add(new ComboBoxItem(".jpeg", "JPEG"));
            cboFileType.Items.Add(new ComboBoxItem(".bmp", "BMP"));
            cboFileType.SelectedIndex = 0;

            this.AdjustUIState();
        }

        #endregion

        #region TranslateUI

        private void TranslateUI()
        {
            gbPages.Text = LocalizationManager.GetFormText("multipagesettings.gbPages");
            rbAllPages.Text = LocalizationManager.GetFormText("multipagesettings.rbAllPages");
            rbPageRange.Text = LocalizationManager.GetFormText("multipagesettings.rbPageRange");
            lblPageFrom.Text = LocalizationManager.GetFormText("multipagesettings.lblPageFrom");
            lblPageTo.Text = LocalizationManager.GetFormText("multipagesettings.lblPageTo");
            rbCustomPages.Text = LocalizationManager.GetFormText("multipagesettings.rbCustomPages");
            lblCustomPages.Text = LocalizationManager.GetFormText("multipagesettings.lblCustomPages");
            gbResolution.Text = LocalizationManager.GetFormText("multipagesettings.gbResolution");
            gbOutput.Text = LocalizationManager.GetFormText("multipagesettings.gbOutput");
            lblFolder.Text = LocalizationManager.GetFormText("multipagesettings.lblFolder");
            lblFilenameFormat.Text = LocalizationManager.GetFormText("multipagesettings.lblFilenameFormat");
            lblFileType.Text = LocalizationManager.GetFormText("multipagesettings.lblFileType");
            chkOpenWindowsExplorerWhenDone.Text = LocalizationManager.GetFormText("multipagesettings.chkOpenWindowsExplorerWhenDone");
            txtFilenameFormat.Text = LocalizationManager.GetFormText("multipagesettings.filenameformat.page") + "-#pagenumber#";

            btnOk.Text = LocalizationManager.GetFormText("global.ok");
            btnCancel.Text = LocalizationManager.GetFormText("global.cancel");
        }

        #endregion

        #region btnBrowseOutputFolder_Click

        private void btnBrowseOutputFolder_Click(object sender, EventArgs e)
        {
            string selectedFolder = txtFolder.Text;

            if (string.IsNullOrWhiteSpace(selectedFolder))
            {
                selectedFolder = GhostscriptStudio.Options.MultipageSettings_LastOutputFolder;
            }

            string path = DialogsHelper.ShowFolderBrowserDialog(GhostscriptStudio.MainWindow, selectedFolder);
            if (path != null)
            {
                GhostscriptStudio.Options.MultipageSettings_LastOutputFolder = path;
                GhostscriptStudio.SaveOptions();

                txtFolder.Text = path;
            }
        }

        #endregion

        #region rbAllPages_CheckedChanged

        private void rbAllPages_CheckedChanged(object sender, EventArgs e)
        {
            this.AdjustUIState();
        }

        #endregion

        #region rbPageRange_CheckedChanged

        private void rbPageRange_CheckedChanged(object sender, EventArgs e)
        {
            this.AdjustUIState();
        }

        #endregion

        #region rbCustomPages_CheckedChanged

        private void rbCustomPages_CheckedChanged(object sender, EventArgs e)
        {
            this.AdjustUIState();
        }

        #endregion

        #region AdjustUIState

        private void AdjustUIState()
        {
            lblPageFrom.Enabled = rbPageRange.Checked;
            lblPageTo.Enabled = rbPageRange.Checked;
            nudPageFrom.Enabled = rbPageRange.Checked;
            nudPageTo.Enabled = rbPageRange.Checked;
            txtCustomPages.Enabled = rbCustomPages.Checked;
        }

        #endregion

        #region btnOk_Click

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbPageRange.Checked)
            {
                if (nudPageTo.Value < nudPageFrom.Value)
                {
                    DialogsHelper.ShowMessageBox(this, "multipagesettings_page_to_smaller_than_from", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    return;
                }
            }

            if (rbCustomPages.Checked)
            {
                if (txtCustomPages.Text.Trim().Length == 0)
                {
                    DialogsHelper.ShowMessageBox(this, "multipagesettings_custom_pages_cannot_be_empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    return;
                }

                if (!this.AreCustomPagesValid(txtCustomPages.Text, _firstPage, _lastPage))
                {
                    DialogsHelper.ShowMessageBox(this, "multipagesettings_custom_pages_not_valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(txtFolder.Text))
            {
                DialogsHelper.ShowMessageBox(this, "multipagesettings_output_folder_empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            if (!Directory.Exists(txtFolder.Text.Trim()))
            {
                DialogsHelper.ShowMessageBox(this, "multipagesettings_output_folder_missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFilenameFormat.Text))
            {
                DialogsHelper.ShowMessageBox(this, "multipagesettings_output_filename_empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            if (!txtFilenameFormat.Text.Contains("#pagenumber"))
            {
                DialogsHelper.ShowMessageBox(this, "multipagesettings_output_filename_missing_page_tag", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            string outputFileNameExtension = Path.GetExtension(txtFilenameFormat.Text.Trim().Replace("#pagenumber#", ""));

            if (outputFileNameExtension.Length > 0)
            {
                DialogsHelper.ShowMessageBox(this, "multipagesettings_output_filename_remove_extension", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
        }

        #endregion

        #region SelectedPages

        public List<int> SelectedPages
        {
            get
            {
                List<int> res = new List<int>();

                if (rbAllPages.Checked)
                {
                    for (int pageNumber = _firstPage; pageNumber <= _lastPage; pageNumber++)
                    {
                        res.Add(pageNumber);
                    }
                }
                else if (rbPageRange.Checked)
                {
                    for (int pageNumber = (int)nudPageFrom.Value; pageNumber <= (int)nudPageTo.Value; pageNumber++)
                    {
                        res.Add(pageNumber);
                    }
                }
                else if (rbCustomPages.Checked)
                {
                    string[] pages = txtCustomPages.Text.Trim().Split(',');

                    foreach (string tmpPage in pages)
                    {
                        string page = tmpPage.Trim();

                        res.Add(int.Parse(page));
                    }
                }

                return res;
            }
        }

        #endregion

        #region AreCustomPagesValid

        private bool AreCustomPagesValid(string value, int min, int max)
        {
            try
            {
                string[] pages = value.Split(',');

                foreach(string tmpPage in pages)
                {
                    string page = tmpPage.Trim();
                    int pageNumber = 0;

                    if (!int.TryParse(page, out pageNumber))
                    {
                        return false;
                    }

                    if (pageNumber < min || pageNumber > max)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
