#region This file is part of Ghostscript.Studio application
//
// FOptions.cs
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Artifex.Ghostscript.NET;

namespace Ghostscript.Studio.Windows
{
    public partial class FOptions : Form
    {
        #region Constructor

        public FOptions()
        {
            InitializeComponent();

            this.Font = Program.DefaultFont;

            this.TranslateUI();
        }

        #endregion

        #region TranslateUI

        private void TranslateUI()
        {
            this.Text = LocalizationManager.GetFormText("options.title");
            btnOk.Text = LocalizationManager.GetFormText("options.btnOk");
            btnCancel.Text = LocalizationManager.GetFormText("options.btnCancel");
            tpOther.Text = LocalizationManager.GetFormText("options.tabOther");
            
            lblGhostscriptUseVersion.Text = LocalizationManager.GetFormText("options.ghostscript.lblGhostscriptUseVersion");
            lblOtherLanguage.Text = LocalizationManager.GetFormText("options.other.lblOtherLanguage");

            tpViewer.Text = LocalizationManager.GetFormText("options.tabViewer");
            chkViewerProgressiveUpdate.Text = LocalizationManager.GetFormText("options.viewer.chkViewerProgressiveUpdate");
            lblViewerProgressiveUpdateInterval.Text = LocalizationManager.GetFormText("options.viewer.lblViewerProgressiveUpdateInterval");
            lblViewerProgressiveUpdateIntervalMilliseconds.Text = LocalizationManager.GetFormText("options.viewer.lblViewerProgressiveUpdateIntervalMilliseconds");

            tpEditor.Text = LocalizationManager.GetFormText("options.tabEditor");
            chkEditorProgressiveUpdate.Text = LocalizationManager.GetFormText("options.editor.chkEditorProgressiveUpdate");
            lblEditorProgressiveUpdateInterval.Text = LocalizationManager.GetFormText("options.editor.lblEditorProgressiveUpdateInterval");
            lblEditorProgressiveUpdateIntervalMilliseconds.Text = LocalizationManager.GetFormText("options.editor.lblEditorProgressiveUpdateIntervalMilliseconds");

            chkOptionsShowSupportWindow.Text = LocalizationManager.GetFormText("options.other.chkOptionsShowSupportWindow");
        }

        #endregion

        #region FOptions_Load

        private void FOptions_Load(object sender, EventArgs e)
        {
            this.PopulateDropDowns();

            cboGhostscriptVersion.SelectedValue = GhostscriptStudio.Options.GhostscriptVersion;
            cboLanguage.SelectedValue = GhostscriptStudio.Options.Language;

            chkEditorProgressiveUpdate.Checked = GhostscriptStudio.Options.Editor_ProgressiveUpdate;
            nudEditorProgressiveUpdateInterval.Value = GhostscriptStudio.Options.Editor_ProgressiveUpdate_Interval;
            
            chkViewerProgressiveUpdate.Checked = GhostscriptStudio.Options.Viewer_ProgressiveUpdate;
            nudViewerProgressiveUpdateInterval.Value = GhostscriptStudio.Options.Viewer_ProgressiveUpdate_Interval;
            
            chkOptionsShowSupportWindow.Checked = GhostscriptStudio.Options.ShowSupportWindowAtStartup;

            this.SetUIState();
        }

        #endregion

        #region btnCancel_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region btnOk_Click

        private void btnOk_Click(object sender, EventArgs e)
        {
            string bkpLanguage = GhostscriptStudio.Options.Language;
            GhostscriptStudio.Options.GhostscriptVersion = (cboGhostscriptVersion.SelectedItem as ComboBoxItem).Value;
            GhostscriptStudio.Options.Language = (cboLanguage.SelectedItem as ComboBoxItem).Value;

            GhostscriptStudio.Options.Editor_ProgressiveUpdate = chkEditorProgressiveUpdate.Checked;
            GhostscriptStudio.Options.Editor_ProgressiveUpdate_Interval = (int)nudEditorProgressiveUpdateInterval.Value;
            GhostscriptStudio.Options.Viewer_ProgressiveUpdate = chkViewerProgressiveUpdate.Checked;
            GhostscriptStudio.Options.Viewer_ProgressiveUpdate_Interval = (int)nudViewerProgressiveUpdateInterval.Value;

            GhostscriptStudio.Options.ShowSupportWindowAtStartup = chkOptionsShowSupportWindow.Checked;

            GhostscriptStudio.SaveOptions();

            if (bkpLanguage != GhostscriptStudio.Options.Language)
            {
                DialogsHelper.ShowMessageBox(GhostscriptStudio.MainWindow, "language_switch_restart", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        #endregion

        #region PopulateDropDowns

        private void PopulateDropDowns()
        {
            cboGhostscriptVersion.DisplayMember = "DisplayText";
            cboGhostscriptVersion.ValueMember = "Value";
            cboGhostscriptVersion.DataSource = UIHelper.GetInstalledGhostscriptVersionsForDisplay();

            cboLanguage.DisplayMember = "DisplayText";
            cboLanguage.ValueMember = "Value";
            cboLanguage.DataSource = UIHelper.GetLanguagesForDisplay();
        }

        #endregion

        #region chkViewerProgressiveUpdate_CheckedChanged

        private void chkViewerProgressiveUpdate_CheckedChanged(object sender, EventArgs e)
        {
            this.SetUIState();
        }

        #endregion

        #region chkEditorProgressiveUpdate_CheckedChanged

        private void chkEditorProgressiveUpdate_CheckedChanged(object sender, EventArgs e)
        {
            this.SetUIState();
        }

        #endregion

        private void SetUIState()
        {
            nudViewerProgressiveUpdateInterval.Enabled = chkViewerProgressiveUpdate.Checked;
            nudEditorProgressiveUpdateInterval.Enabled = chkEditorProgressiveUpdate.Checked;
        }

    }
}
