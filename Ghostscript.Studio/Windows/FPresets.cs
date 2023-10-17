#region This file is part of Ghostscript.Studio application
//
// FPresets.cs
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
using System.Windows.Forms;
using System.IO;
using Ghostscript.Studio.Lexers;
using ScintillaNET;

namespace Ghostscript.Studio.Windows
{
    public partial class FPresets : Form
    {

        #region Private variables

        private PresetType _presetType;
        private bool _isEditing = false;
        private bool _isNew = false;
        private Scintilla _editor = new Scintilla();
        private List<PresetFile> _presetFiles = new List<PresetFile>();
        private bool _openNewFromOutside = false;
        private string _outsideContent = string.Empty;

        #endregion

        #region Constructor

        public FPresets(PresetType presetType)
        {
            _presetType = presetType;

            InitializeComponent();

            this.Font = Program.DefaultFont;

            _editor.Margins.Margin0.Width = 45;
            _editor.Dock = DockStyle.Fill;

            if (presetType == PresetType.GhostscriptProcessorPostScript)
            {
                _editor.ConfigurationManager.Language = "ps";
            }
            else
            {
                _editor.StyleNeeded += new EventHandler<StyleNeededEventArgs>(_editor_StyleNeeded);
                GhostscriptProcessorLexer.Init(_editor);
            }

            ScintillaHelper.SetScrollWidthTracking(_editor);
            ScintillaHelper.SetFont(_editor, new System.Drawing.Font("Courier New", 10f));

            panEditor.Controls.Add(_editor);

            this.SetControlsState();

            this.TranslateUI();
        }

        #endregion

        #region TranslateUI

        private void TranslateUI()
        {
            if (_presetType == PresetType.GhostscriptProcessorSwitches)
            {
                this.Text = LocalizationManager.GetFormText("presets.title.ghostscriptprocessorswitchespresets");
            }
            else if (_presetType == PresetType.GhostscriptProcessorPostScript)
            {
                this.Text = LocalizationManager.GetFormText("presets.title.ghostscriptprocessorpostscriptpresets");
            }

            lblName.Text = LocalizationManager.GetFormText("presets.lblName");
            lblDescription.Text = LocalizationManager.GetFormText("presets.lblDescription");
            btnNew.Text = LocalizationManager.GetFormText("presets.btnNew");
            btnEdit.Text = LocalizationManager.GetFormText("presets.btnEdit");
            btnSave.Text = LocalizationManager.GetFormText("presets.btnSave");
            btnCancel.Text = LocalizationManager.GetFormText("presets.btnCancel");
            btnDelete.Text = LocalizationManager.GetFormText("presets.btnDelete");
            btnImport.Text = LocalizationManager.GetFormText("presets.btnImport");
            btnExport.Text = LocalizationManager.GetFormText("presets.btnExport");
            btnClose.Text = LocalizationManager.GetFormText("presets.btnClose");
        }

        #endregion

        #region FPresets_Shown

        private void FPresets_Shown(object sender, EventArgs e)
        {
            this.LoadList();

            if (_openNewFromOutside)
            {
                btnNew_Click(this, new EventArgs());
                _editor.Text = _outsideContent;
                _openNewFromOutside = false;
            }

            this.SetControlsState();
        }

        #endregion

        #region _editor_StyleNeeded

        void _editor_StyleNeeded(object sender, StyleNeededEventArgs e)
        {
            GhostscriptProcessorLexer.StyleNeeded((Scintilla)sender, e.Range);
        }

        #endregion

        #region btnNew_Click

        private void btnNew_Click(object sender, EventArgs e)
        {
            _isEditing = true;
            _isNew = true;

            lbPresets.SelectedIndex = -1;

            this.ClearFields();

            this.SetControlsState();
        }

        #endregion

        #region btnEdit_Click

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _isEditing = true;
            _isNew = false;
            this.SetControlsState();
        }

        #endregion

        #region btnSave_Click

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                DialogsHelper.ShowMessageBox(this, "presets_name_cannot_be_empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IOHelper.IsFilenameValid(txtName.Text.Trim()))
            {
                DialogsHelper.ShowMessageBox(this, "presets_name_contains_illegal_characters", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool alreadyExist = false;

            foreach (PresetFile pf in _presetFiles)
            {
                if (pf.Name.ToLower() == txtName.Text.Trim().ToLower())
                {
                    if (_isNew)
                    {
                        alreadyExist = true;
                        break;
                    }
                    else
                    {
                        if ((lbPresets.SelectedItem as PresetFile) != pf)
                        {
                            alreadyExist = true;
                            break;
                        }
                    }
                }
            }

            if (alreadyExist)
            {
                DialogsHelper.ShowMessageBox(this, "presets_name_already_exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Preset preset = null;

            preset = new Preset()
            {
                Type = _presetType,
                Name = txtName.Text.Trim(),
                Description = txtDescription.Text,
                Content = _editor.Text
            };

            PresetFile presetFile = null;

            if (_isNew)
            {
                presetFile = new PresetFile();
                presetFile.Save(preset);
                _presetFiles.Add(presetFile);
            }
            else
            {
                presetFile = (lbPresets.SelectedItem as PresetFile);
                presetFile.Replace(preset);
            }

            this.RefreshList(presetFile);

            _isEditing = false;
            this.SetControlsState();
        }

        #endregion

        #region btnCancel_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ClearFields();
            this.RefreshList(null);
            _isEditing = false;
            this.SetControlsState();
        }

        #endregion

        #region btnDelete_Click

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogsHelper.ShowMessageBox(this, "presets_delete_preset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                PresetFile presetFile = lbPresets.SelectedItem as PresetFile;
                presetFile.Delete();
                _presetFiles.Remove(presetFile);
                this.RefreshList(null);
            }
        }

        #endregion

        #region btnImport_Click

        private void btnImport_Click(object sender, EventArgs e)
        {
            string filter = PresetManager.GetPresetExtension(_presetType) + "|*" + PresetManager.GetPresetExtension(_presetType);
            string[] path = DialogsHelper.ShowOpenFileDialog(this, LocalizationManager.GetFormText("presets.title.import"), filter, false);

            if (path != null)
            {
                btnNew_Click(this, new EventArgs());
                PresetFile pf = new PresetFile(path[0]);
                Preset preset = pf.Read();
                txtName.Text = preset.Name;
                txtDescription.Text = preset.Description;
                _editor.Text = preset.Content;
            }
        }

        #endregion

        #region btnExport_Click

        private void btnExport_Click(object sender, EventArgs e)
        {
            string filter = PresetManager.GetPresetExtension(_presetType) + "|*" + PresetManager.GetPresetExtension(_presetType);
            string path = DialogsHelper.ShowSaveFileDialog(this, LocalizationManager.GetFormText("presets.title.export"), filter);

            if (path != null)
            {
                PresetFile pf = new PresetFile((lbPresets.SelectedItem as PresetFile).FileName);
                Preset preset = pf.Read();
                preset.Name = Path.GetFileNameWithoutExtension(path);
                Preset.Save(preset, path);
            }
        }

        #endregion

        #region SetControlsState

        private void SetControlsState()
        {
            lbPresets.Enabled = !_isEditing;
            btnNew.Enabled = !_isEditing;
            btnEdit.Enabled = !_isEditing && lbPresets.SelectedItem != null;
            btnCancel.Enabled = _isEditing;
            btnSave.Enabled = _isEditing;
            btnImport.Enabled = !_isEditing;
            btnExport.Enabled = !_isEditing;
            btnDelete.Enabled = !_isEditing && lbPresets.SelectedItem != null;
            btnClose.Enabled = !_isEditing;
            btnExport.Enabled = !_isEditing && lbPresets.SelectedItem != null;

            txtName.ReadOnly = !_isEditing;
            txtDescription.ReadOnly = !_isEditing;
            _editor.IsReadOnly = !_isEditing;

            if (_editor.IsReadOnly)
            {
                _editor.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                _editor.BackColor = System.Drawing.SystemColors.Window;
            }

            _editor.Lexing.Colorize();
        }

        #endregion

        #region LoadList

        private void LoadList()
        {
            _presetFiles = PresetManager.GetPresets(_presetType);

            lbPresets.DataSource = _presetFiles;
        }

        #endregion

        #region lbPresets_SelectedIndexChanged

        private void lbPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPresets.SelectedItem != null)
            {
                Preset preset = (lbPresets.SelectedItem as PresetFile).Read();
                txtName.Text = preset.Name;
                txtDescription.Text = preset.Description;
                _editor.IsReadOnly = false;
                _editor.Text = preset.Content;
                _editor.IsReadOnly = true;
            }
            else
            {
                this.ClearFields();
            }

            this.SetControlsState();
        }

        #endregion

        #region RefreshList

        private void RefreshList(PresetFile selectedPresetFile)
        {
            this.ClearFields();

            if (selectedPresetFile == null)
            {
                selectedPresetFile = lbPresets.SelectedItem as PresetFile;
            }

            lbPresets.DataSource = null;
            lbPresets.DataSource = _presetFiles;
            lbPresets.SelectedItem = selectedPresetFile;
        }

        #endregion

        #region ClearFields

        private void ClearFields()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            if (_editor.IsReadOnly)
            {
                _editor.IsReadOnly = false;
                _editor.Text = string.Empty;
                _editor.IsReadOnly = true;
            }
            else
            {
                _editor.Text = string.Empty;
            }
        }

        #endregion

        #region OpenNew

        public void OpenNew(string name, string description, string content)
        {
            _openNewFromOutside = true;
            _outsideContent = content;
        }

        #endregion
    }
}
