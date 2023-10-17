#region This file is part of Ghostscript.Studio application
//
// FProcessorWorkspace.cs
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
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ScintillaNET;
using Ghostscript.Studio.Lexers;
using Ghostscript.Studio.Commands;
using Ghostscript.Studio.Managers;
using Artifex.Ghostscript.NET.Processor;
using Ghostscript.Studio.Windows;
using System.Text;

namespace Ghostscript.Studio.Workspaces.Processor
{
    public partial class FProcessorWorkspace : FWorkspaceBase
    {

        #region Private variables

        private Scintilla _editor = new Scintilla();
        private Scintilla _cPostScript = new Scintilla();

        private string _currentFile = null;
        private int _untitledNumber;

        private ThreadedGhostscriptProcessor _processor = new ThreadedGhostscriptProcessor();
        private ProcessorStdIOHandler _processorStdIO;
        private List<string> _switches;

        private EditableControlHandler _editableControlHandler = new EditableControlHandler();

        #endregion

        #region Constructor

        public FProcessorWorkspace()
        {
            InitializeComponent();

            this.Font = Program.DefaultFont;

            this.TranslateUI();

            _editor.Margins.Margin0.Width = 30;
            _editor.StyleNeeded += new EventHandler<StyleNeededEventArgs>(_editor_StyleNeeded);
            _editor.Dock = DockStyle.Fill;

            ScintillaHelper.SetScrollWidthTracking(_editor);
            ScintillaHelper.SetFont(_editor, new System.Drawing.Font("Courier New", 10f));

            GhostscriptProcessorLexer.Init(_editor);

            panProcessorEditor.Controls.Add(_editor);
            panProcessorEditor.Controls.SetChildIndex(_editor, 0);

            _cPostScript.Margins.Margin0.Width = 30;
            _cPostScript.Dock = DockStyle.Fill;
            _cPostScript.ConfigurationManager.Language = "ps";

            ScintillaHelper.SetScrollWidthTracking(_cPostScript);
            ScintillaHelper.SetFont(_cPostScript, new System.Drawing.Font("Courier New", 10f));            

            panPostScriptEditor.Controls.Add(_cPostScript);
            panPostScriptEditor.Controls.SetChildIndex(_cPostScript, 0);

            _processorStdIO = new ProcessorStdIOHandler(Processor_StdInputEventHandler, Processor_StdOutputEventHandler, Processor_StdErrorEventHandler);

            _processor.ProcessingStarted += new EventHandler(Processor_ProcessingStarted);
            _processor.Processing += new GhostscriptProcessorProcessingEventHandler(Processor_Processing);
            _processor.ProcessingEnded += new EventHandler(Processor_ProcessingEnded);
            _processor.Error += new GhostscriptProcessorErrorEventHandler(Processor_Error);


            _editor.ContextMenuStrip = GhostscriptStudio.MainWindow.GetDefaultEditorContextMenu(); 
            _cPostScript.ContextMenuStrip = GhostscriptStudio.MainWindow.GetDefaultEditorContextMenu();
            txtOutputFolder.ContextMenuStrip = GhostscriptStudio.MainWindow.GetDefaultEditorContextMenu();
            txtFilenameFormat.ContextMenuStrip = GhostscriptStudio.MainWindow.GetDefaultEditorContextMenu();
            rtbOutput.ContextMenuStrip = GhostscriptStudio.MainWindow.GetDefaultEditorContextMenu();

            _editableControlHandler.QueryAndSetWorkspaceCommandUIState += new EventHandler(_editableControlHandler_QueryAndSetWorkspaceCommandUIState);
            _editableControlHandler.ContentChanged += new EventHandler(_editableControlHandler_ContentChanged);

            ControlsHelper.EnsureFocusOnMouseDown(txtOutputFolder, txtFilenameFormat, rtbOutput);

            this.PopulateSwitchesPresets();
            this.PopulatePostScriptPresets();
        }

        #endregion

        #region FProcessorWorkspace_Load

        private void FProcessorWorkspace_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region FProcessorWorkspace_Shown

        private void FProcessorWorkspace_Shown(object sender, EventArgs e)
        {
            _editor.Lexing.Colorize();

            if (!this.IsFilenameSet)
            {
                _untitledNumber = Managers.EnvironmentManager.GetNextUntitledNumber();
            }

            this.SetDirtyMode(false);

            _editableControlHandler.RegisterControlForUIStateChangeHandling(_editor, _cPostScript, txtOutputFolder, txtFilenameFormat, rtbOutput);
            _editableControlHandler.RegisterControlForContentChangeHandling(_editor, _cPostScript, txtOutputFolder, txtFilenameFormat);

            this.AttachCommandHandlers();

            EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
        }

        #endregion

        #region TranslateUI

        private void TranslateUI()
        {
            lblInputAndOutputFiles.Text = LocalizationManager.GetFormText("processor.lblInputAndOutputFiles");
            lblOutputDebug.Text = LocalizationManager.GetFormText("processor.lblOutputDebug");
            lblInputFiles.Text = LocalizationManager.GetFormText("processor.lblInputFiles");
            lblOutputFolder.Text = LocalizationManager.GetFormText("processor.lblOutputFolder");
            lblFilenameFormat.Text = LocalizationManager.GetFormText("processor.lblFilenameFormat");
            lblSwitches.Text = LocalizationManager.GetFormText("processor.lblSwitches");
            lblPostScriptToExecute.Text = LocalizationManager.GetFormText("processor.lblPostScriptToExecute");

            toolTip.SetToolTip(btnAddInputFile, LocalizationManager.GetFormText("processor.btnAddInputFile"));
            toolTip.SetToolTip(btnRemoveInputFile, LocalizationManager.GetFormText("processor.btnRemoveInputFile"));
            toolTip.SetToolTip(btnClearInputFiles, LocalizationManager.GetFormText("processor.btnClearInputFiles"));
            toolTip.SetToolTip(btnBrowseOutputFolder, LocalizationManager.GetFormText("processor.btnBrowseOutputFolder"));

            toolTip.SetToolTip(btnCreateSwitchesPreset, LocalizationManager.GetFormText("processor.btnCreateSwitchesPreset"));
            toolTip.SetToolTip(btnSwitchesPresetManager, LocalizationManager.GetFormText("processor.btnSwitchesPresetManager"));
            toolTip.SetToolTip(btnApplySwitchesPreset, LocalizationManager.GetFormText("processor.btnApplySwitchesPreset"));
            toolTip.SetToolTip(btnCreatePostScriptPreset, LocalizationManager.GetFormText("processor.btnCreatePostScriptPreset"));
            toolTip.SetToolTip(btnPostScriptPresetManager, LocalizationManager.GetFormText("processor.btnPostScriptPresetManager"));
            toolTip.SetToolTip(btnApplyPostScriptPreset, LocalizationManager.GetFormText("processor.btnApplyPostScriptPreset"));
        }

        #endregion

        #region AttachCommandHandlers

        private void AttachCommandHandlers()
        {
            this.SubscribeToCommand(CommandManager.Save, new CommandEventHandler(Command_Save));
            this.SubscribeToCommand(CommandManager.SaveAs, new CommandEventHandler(Command_SaveAs));
            this.SubscribeToCommand(CommandManager.Undo, new CommandEventHandler(Command_Undo));
            this.SubscribeToCommand(CommandManager.Redo, new CommandEventHandler(Command_Redo));
            this.SubscribeToCommand(CommandManager.Cut, new CommandEventHandler(Command_Cut));
            this.SubscribeToCommand(CommandManager.Copy, new CommandEventHandler(Command_Copy));
            this.SubscribeToCommand(CommandManager.Paste, new CommandEventHandler(Command_Paste));
            this.SubscribeToCommand(CommandManager.SelectAll, new CommandEventHandler(Command_SelectAll));
            this.SubscribeToCommand(CommandManager.Start, new CommandEventHandler(Command_Start));
            this.SubscribeToCommand(CommandManager.Stop, new CommandEventHandler(Command_Stop));
        }

        #endregion

        #region _editor_StyleNeeded

        void _editor_StyleNeeded(object sender, StyleNeededEventArgs e)
        {
            GhostscriptProcessorLexer.StyleNeeded((Scintilla)sender, e.Range);
        }

        #endregion

        #region _editableControlHandler_QueryAndSetWorkspaceCommandUIState

        void _editableControlHandler_QueryAndSetWorkspaceCommandUIState(object sender, EventArgs e)
        {
            EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
        }

        #endregion

        #region _editableControlHandler_ContentChanged

        void _editableControlHandler_ContentChanged(object sender, EventArgs e)
        {
            this.SetDirtyMode(true);
        }

        #endregion

        #region IsRunning

        public override bool IsRunning
        {
            get
            {
                return _processor.IsRunning;
            }
        }

        #endregion

        #region SetDirtyMode

        private void SetDirtyMode(bool isDirty)
        {
            base.IsDirty = isDirty;

            this.Text = this.GetStateTitle();

            EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
        }

        #endregion

        #region IsFilenameSet

        private bool IsFilenameSet
        {
            get { return !string.IsNullOrWhiteSpace(_currentFile); }
        }

        #endregion

        #region GetStateTitle

        private string GetStateTitle()
        {
            string prefix = string.Empty;

            if (this.IsDirty)
            {
                prefix = "*";
            }

            return  prefix + this.Title;
        }

        #endregion

        #region Open

        public override bool Open(string path)
        {
            ProcessorFile pf = ProcessorFile.Open(path);

            _currentFile = path;
   
            _editor.Text = pf.Text;
            _editor.UndoRedo.EmptyUndoBuffer();

            _cPostScript.Text = pf.PostScript;
            _cPostScript.UndoRedo.EmptyUndoBuffer();
            
            txtOutputFolder.Text = pf.OutputPath;
            txtFilenameFormat.Text = pf.OutputFilenameFormat;

            foreach (string file in pf.InputFiles)
            {
                lbInputFiles.Items.Add(file);
            }

            return true;
        }

        #endregion

        #region Save

        private bool Save()
        {
            if (!this.IsFilenameSet)
            {
                return SaveAs();
            }

            if (this.IsDirty)
            {
                ProcessorFile pf = new ProcessorFile();
                pf.Text = _editor.Text;
                pf.PostScript = _cPostScript.Text;
                
                foreach (object file in lbInputFiles.Items)
                {
                    pf.InputFiles.Add(file.ToString());
                }

                pf.OutputPath = txtOutputFolder.Text;
                pf.OutputFilenameFormat = txtFilenameFormat.Text;
                ProcessorFile.Save(pf, _currentFile);

                this.SetDirtyMode(false);

                return true;
            }

            return false;
        }

        #endregion

        #region SaveAs

        private bool SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = this.Title;
            sfd.Filter = "Ghostscript.Studio Processor|*.gspr";
            if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                ProcessorFile pf = new ProcessorFile();
                pf.Text = _editor.Text;
                pf.PostScript = _cPostScript.Text;
                pf.OutputPath = txtOutputFolder.Text;
                pf.OutputFilenameFormat = txtFilenameFormat.Text;

                ProcessorFile.Save(pf, sfd.FileName);

                _currentFile = sfd.FileName;

                this.SetDirtyMode(false);

                return true;
            }

            return false;
        }

        #endregion

        #region SaveAll

        public override bool SaveAll()
        {
            return this.Save();
        }

        #endregion

        #region Title

        public string Title
        {
            get
            {
                if (this.IsFilenameSet)
                {
                    return Path.GetFileName(_currentFile);
                }
                else
                {
                    return LocalizationManager.GetFormText("processor.untitled") + _untitledNumber.ToString() + ".gspr";
                }
            }
        }

        #endregion

        #region Command_Save

        private void Command_Save(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = this.IsDirty;
            }
            else
            {
                this.Save();
            }
        }

        #endregion

        #region Command_SaveAs

        private void Command_SaveAs(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
            }
            else
            {
                this.SaveAs();
            }
        }

        #endregion

        #region Command_Undo

        private void Command_Undo(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _editableControlHandler.CanUndo;
            }
            else
            {
                _editableControlHandler.Undo();
            }
        }

        #endregion

        #region Command_Redo

        private void Command_Redo(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _editableControlHandler.CanRedo;
            }
            else
            {
                _editableControlHandler.Redo();
            }
        }

        #endregion

        #region Command_Cut

        private void Command_Cut(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _editableControlHandler.CanCut;
            }
            else
            {
                _editableControlHandler.Cut();
            }
        }

        #endregion

        #region Command_Copy

        private void Command_Copy(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _editableControlHandler.CanCopy;
            }
            else
            {
                _editableControlHandler.Copy();
            }
        }

        #endregion

        #region Command_Paste

        private void Command_Paste(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _editableControlHandler.CanPaste;
            }
            else
            {
                _editableControlHandler.Paste();
            }
        }

        #endregion

        #region Command_SelectAll

        private void Command_SelectAll(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _editableControlHandler.CanSelectAll;
            }
            else
            {
                _editableControlHandler.SelectAll();
            }
        }

        #endregion

        #region Command_Start

        private void Command_Start(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = !_processor.IsRunning;
            }
            else
            {
                this.Processor_StartProcessing();
            }
        }

        #endregion

        #region Command_Stop

        private void Command_Stop(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _processor.IsRunning;
            }
            else
            {
                this.Processor_StopProcessing();
            }
        }

        #endregion

        #region btnBrowseOutputFolder_Click

        private void btnBrowseOutputFolder_Click(object sender, EventArgs e)
        {
            string selectedFolder = txtOutputFolder.Text;

            if (string.IsNullOrWhiteSpace(selectedFolder))
            {
                selectedFolder = GhostscriptStudio.Options.Processor_LastOutputFolder;
            }

            string path = DialogsHelper.ShowFolderBrowserDialog(GhostscriptStudio.MainWindow, selectedFolder);
            if (path != null)
            {
                GhostscriptStudio.Options.Processor_LastOutputFolder = path;
                GhostscriptStudio.SaveOptions();

                txtOutputFolder.Text = path;

                this.SetDirtyMode(true);
            }
        }

        #endregion

        #region btnAddInputFile_Click

        private void btnAddInputFile_Click(object sender, EventArgs e)
        {
            string[] files = DialogsHelper.ShowOpenFileDialog(GhostscriptStudio.MainWindow, LocalizationManager.GetFormText("processor.dlg.select_files"), "All files|*.*", true);

            if (files != null)
            {
                foreach (string file in files)
                {
                    lbInputFiles.Items.Add(file);
                }

                this.SetDirtyMode(true);
            }
        }

        #endregion

        #region btnRemoveInputFile_Click

        private void btnRemoveInputFile_Click(object sender, EventArgs e)
        {
            if (lbInputFiles.SelectedItems.Count > 0)
            {
                if (DialogsHelper.ShowMessageBox(GhostscriptStudio.MainWindow, 
                                "delete_selected_files_from_list", 
                                MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    List<object> selItems = new List<object>();

                    foreach (object item in lbInputFiles.SelectedItems)
                    {
                        selItems.Add(item);
                    }

                    foreach(object item in selItems)
                    {
                        lbInputFiles.Items.Remove(item);
                    }

                    this.SetDirtyMode(true);
                }
            }
        }

        #endregion

        #region btnClearInputFiles_Click

        private void btnClearInputFiles_Click(object sender, EventArgs e)
        {
            if (lbInputFiles.Items.Count > 0)
            {
                if (DialogsHelper.ShowMessageBox(GhostscriptStudio.MainWindow,
                                "delete_all_files_from_list",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    lbInputFiles.Items.Clear();

                    this.SetDirtyMode(true);
                }
            }
        }

        #endregion

        #region Processor_StartProcessing

        private void Processor_StartProcessing()
        {
            if (lbInputFiles.Items.Count == 0)
            {
                DialogsHelper.ShowMessageBox(GhostscriptStudio.MainWindow, "at_least_one_input_file_required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtOutputFolder.Text))
            {
                DialogsHelper.ShowMessageBox(GhostscriptStudio.MainWindow, "output_folder_not_set", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFilenameFormat.Text))
            {
                DialogsHelper.ShowMessageBox(GhostscriptStudio.MainWindow, "filename_format_not_set", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (object file in lbInputFiles.Items)
            {
                if (!File.Exists(file.ToString()))
                {
                    DialogsHelper.ShowMessageBox(GhostscriptStudio.MainWindow, "file_does_not_exist", MessageBoxButtons.OK, MessageBoxIcon.Error, file);
                    return;
                }
            }

            if (!Directory.Exists(txtOutputFolder.Text))
            {
                DialogsHelper.ShowMessageBox(GhostscriptStudio.MainWindow, "file_does_not_exist", MessageBoxButtons.OK, MessageBoxIcon.Error, txtOutputFolder.Text);
                return;
            }

            rtbOutput.Clear();

            _switches = this.NormalizeAndValidateSwitches();
            _processor.StartProcessing(_switches.ToArray(), _processorStdIO);
        }

        #endregion

        #region Processor_StopProcessing

        private void Processor_StopProcessing()
        {
            _processor.StopProcessing();
        }

        #endregion

        #region Processor_StdInputEventHandler

        private void Processor_StdInputEventHandler(out string input, int count)
        {
            input = string.Empty;
        }

        #endregion

        #region Processor_StdOutputEventHandler

        private void Processor_StdOutputEventHandler(string output)
        {
            if (!_processor.IsStopping)
            {
                this.AppendToTheOutput(output);
            }
        }

        #endregion

        #region Processor_StdErrorEventHandler

        private void Processor_StdErrorEventHandler(string error)
        {
            if (!_processor.IsStopping)
            {
                this.AppendToTheOutput(error);
            }
        }

        #endregion

        #region Processor_Error

        void Processor_Error(object sender, GhostscriptProcessorErrorEventArgs e)
        {
            this.Processor_StdErrorEventHandler(e.Message + "\r\n");
        }

        #endregion

        #region Processor_ProcessingStarted

        private void Processor_ProcessingStarted(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(Processor_ProcessingStarted), sender, e);
            }
            else
            {
                tsProgressBar.Visible = true;

                SetUIState(false);
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();

                this.AppendToTheOutput(string.Format(LocalizationManager.GetFormText("processor.output.started"), DateTime.Now.ToString()) + "\r\n");
                this.AppendToTheOutput(new string('-', 84) + "\r\n");
                
                foreach (string s in _switches)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        this.AppendToTheOutput(s + "\r\n");
                    }
                }

                this.AppendToTheOutput(new string('-', 84) + "\r\n");
            }
        }

        #endregion

        #region Processor_Processing

        private void Processor_Processing(object sender, GhostscriptProcessorProcessingEventArgs e)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new GhostscriptProcessorProcessingEventHandler(Processor_Processing), sender, e);
            }
            else
            {
                tsProgressBar.Maximum = e.TotalPages;
                tsProgressBar.Value = e.CurrentPage;
            }
        }

        #endregion

        #region Processor_ProcessingEnded

        private void Processor_ProcessingEnded(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(Processor_ProcessingEnded), sender, e);
            }
            else
            {
                SetUIState(true);
                tsProgressBar.Value = 0;
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();

                this.AppendToTheOutput(new string('-', 84) + "\r\n");
                
                if (_processor.IsTerminated)
                {
                    this.AppendToTheOutput(string.Format(LocalizationManager.GetFormText("processor.output.stopped"), DateTime.Now.ToString()) + "\r\n");
                }
                else
                {
                    this.AppendToTheOutput(string.Format(LocalizationManager.GetFormText("processor.output.finished"), DateTime.Now.ToString()) + "\r\n");
                }
                
                this.AppendToTheOutput(new string('=', 84) + "\r\n");
                this.AppendToTheOutput("\r\n\r\n");

                tsProgressBar.Visible = false;
            }
        }

        #endregion

        #region AppendToOutput

        private void AppendToTheOutput(string text)
        {
            if (rtbOutput.InvokeRequired)
            {
                rtbOutput.Invoke(new StdOutputEventHandler(AppendToTheOutput), text);
            }
            else
            {
                rtbOutput.AppendText(text);
                rtbOutput.SelectionStart = rtbOutput.Text.Length;
                rtbOutput.ScrollToCaret();
            }
        }

        #endregion

        #region SetUIState

        private void SetUIState(bool enabled)
        {
            spEditors.Enabled = enabled;
            panEditorFiles.Enabled = enabled;
        }

        #endregion

        #region NormalizeAndValidateSwitches

        private List<string> NormalizeAndValidateSwitches()
        {
            List<string> switches = new List<string>();
            switches.Add(string.Empty);

            foreach (Line scLine in _editor.Lines)
            {
                string line = scLine.Text;

                // find if there is a comment in line
                int commentStart = line.IndexOf('!');
                
                if (commentStart > -1)
                {
                    // cut off the comment
                    line = line.Substring(0, commentStart);
                }

                // trim spaces
                line = line.Trim(' ', '\t', '\r', '\n');

                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (line.Contains("="))
                    {
                        string[] parts = line.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length == 0)
                        {
                            line = parts[0];
                        }
                        else
                        {
                            line = parts[0].Trim(' ', '\t', '\r', '\n') + "=" + parts[1].Trim(' ', '\t', '\r', '\n');
                        }
                    }

                    if (line.ToLower() != "-dquiet")
                    {
                        // add switch
                        switches.Add(line);
                    }
                }
            }

            switches.Add("-sOutputFile=" + Path.Combine(txtOutputFolder.Text, txtFilenameFormat.Text));

            if (_cPostScript.Text.Length > 0)
            {
                switches.Add("-c");
                switches.Add(_cPostScript.Text);
            }

            switches.Add("-f");

            foreach (object file in lbInputFiles.Items)
            {
                switches.Add(file.ToString());
            }

            return switches;
        }

        #endregion

        #region btnCreateSwitchesPreset_Click

        private void btnCreateSwitchesPreset_Click(object sender, EventArgs e)
        {
            using (FPresets frm = new FPresets(PresetType.GhostscriptProcessorSwitches))
            {
                frm.OpenNew(string.Empty, string.Empty, _editor.Text);
                frm.ShowDialog(GhostscriptStudio.MainWindow);
                this.PopulateSwitchesPresets();
            }
        }

        #endregion

        #region btnSwitchesPresetManager_Click

        private void btnSwitchesPresetManager_Click(object sender, EventArgs e)
        {
            CommandManager.GhostscripProcessorSwitchesPresets.Invoke();
            this.PopulateSwitchesPresets();
        }

        #endregion

        #region btnApplySwitchesPreset_Click

        private void btnApplySwitchesPreset_Click(object sender, EventArgs e)
        {
            if (cboSwitchesPresets.SelectedItem != null)
            {
                Preset preset = (cboSwitchesPresets.SelectedItem as PresetFile).Read();
                _editor.AppendText(preset.Content);
            }
        }

        #endregion

        #region btnCreatePostScriptPreset_Click

        private void btnCreatePostScriptPreset_Click(object sender, EventArgs e)
        {
            using (FPresets frm = new FPresets(PresetType.GhostscriptProcessorPostScript))
            {
                frm.OpenNew(string.Empty, string.Empty, _cPostScript.Text);
                frm.ShowDialog(GhostscriptStudio.MainWindow);
            }
            this.PopulatePostScriptPresets();
        }

        #endregion

        #region btnPostScriptPresetManager_Click

        private void btnPostScriptPresetManager_Click(object sender, EventArgs e)
        {
            CommandManager.GhostscripProcessorPostscriptPresets.Invoke();
            this.PopulatePostScriptPresets();

        }

        #endregion

        #region btnApplyPostScriptPreset_Click

        private void btnApplyPostScriptPreset_Click(object sender, EventArgs e)
        {
            if (cboPostScriptPresets.SelectedItem != null)
            {
                Preset preset = (cboPostScriptPresets.SelectedItem as PresetFile).Read();
                _cPostScript.AppendText(preset.Content);
            }
        }

        #endregion

        #region PopulateSwitchesPresets

        private void PopulateSwitchesPresets()
        {
            PresetFile selectedPreset = cboSwitchesPresets.SelectedItem as PresetFile;
            cboSwitchesPresets.DataSource = null;
            cboSwitchesPresets.DataSource = PresetManager.GetPresets(PresetType.GhostscriptProcessorSwitches);
            cboSwitchesPresets.SelectedItem = selectedPreset;
        }

        #endregion

        #region PopulatePostScriptPresets

        private void PopulatePostScriptPresets()
        {
            PresetFile selectedPreset = cboPostScriptPresets.SelectedItem as PresetFile;
            cboPostScriptPresets.DataSource = null;
            cboPostScriptPresets.DataSource = PresetManager.GetPresets(PresetType.GhostscriptProcessorPostScript);
            cboPostScriptPresets.SelectedItem = selectedPreset;
        }

        #endregion
    }
}
