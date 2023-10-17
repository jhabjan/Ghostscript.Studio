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
using Artifex.Ghostscript.NET.Viewer;
using System.Text;
using Ghostscript.Studio.IO;
using Ghostscript.Studio.Workspaces.Editor.Debugger;

namespace Ghostscript.Studio.Workspaces.Editor
{
    public partial class FEditorWorkspace : FWorkspaceBase
    {

        #region Private variables

        private Scintilla _editor = new Scintilla();
        private GhostscriptViewer _viewer = new GhostscriptViewer();
        private EditorStdIO _stdIo;

        private string _currentFile = null;
        private int _untitledNumber;

        private bool _isViewing = false;

        private EditableControlHandler _editableControlHandler = new EditableControlHandler();

        private bool _disablePreviewAndCommands = false;

        #endregion

        #region Constructor

        public FEditorWorkspace()
        {
            InitializeComponent();

            this.Font = Program.DefaultFont;

            this.TranslateUI();

            GhostscriptStudio.OptionsChanged += new EventHandler(GhostscriptStudio_OptionsChanged);

            _editor.Margins.Margin0.Width = 45;
            _editor.ConfigurationManager.Language = "ps";
            _editor.Dock = DockStyle.Fill;

            spEditorViewer.Panel1.Controls.Add(_editor);

            _editor.ContextMenuStrip = GhostscriptStudio.MainWindow.GetDefaultEditorContextMenu();
            rtbOutput.ContextMenuStrip = GhostscriptStudio.MainWindow.GetDefaultEditorContextMenu();

            _viewer.DisplaySize += new GhostscriptViewerViewEventHandler(_viewer_DisplaySize);
            _viewer.DisplayUpdate += new GhostscriptViewerViewEventHandler(_viewer_DisplayUpdate);
            _viewer.DisplayPage += new GhostscriptViewerViewEventHandler(_viewer_DisplayPage);

            _stdIo = new EditorStdIO(rtbOutput);
            _viewer.AttachStdIO(_stdIo);

            _editableControlHandler.QueryAndSetWorkspaceCommandUIState += new EventHandler(_editableControlHandler_QueryAndSetWorkspaceCommandUIState);
            _editableControlHandler.ContentChanged += new EventHandler(_editableControlHandler_ContentChanged);

            ControlsHelper.EnsureFocusOnMouseDown(rtbOutput);

            this.ApplyApplicationOptions();
        }

        #endregion

        #region GhostscriptStudio_OptionsChanged

        void GhostscriptStudio_OptionsChanged(object sender, EventArgs e)
        {
            this.ApplyApplicationOptions();
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

            this.AttachCommandHandlers();

            _editableControlHandler.RegisterControlForUIStateChangeHandling(_editor, rtbOutput);
            _editableControlHandler.RegisterControlForContentChangeHandling(_editor);

            pbPage.Focus();

            EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
        }

        #endregion

        #region TranslateUI

        private void TranslateUI()
        {
            lblOutputDebug.Text = LocalizationManager.GetFormText("editor.lblOutputDebug");
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
            this.SubscribeToCommand(CommandManager.FirstPage, new CommandEventHandler(Command_FirstPage));
            this.SubscribeToCommand(CommandManager.PreviousPage, new CommandEventHandler(Command_PreviousPage));
            this.SubscribeToCommand(CommandManager.NextPage, new CommandEventHandler(Command_NextPage));
            this.SubscribeToCommand(CommandManager.LastPage, new CommandEventHandler(Command_LastPage));
            this.SubscribeToCommand(CommandManager.ZoomIn, new CommandEventHandler(Command_ZoomIn));
            this.SubscribeToCommand(CommandManager.ZoomOut, new CommandEventHandler(Command_ZoomOut));
            this.SubscribeToCommand(CommandManager.PageNumber, new CommandEventHandler(Command_PageNumber));
            this.SubscribeToCommand(CommandManager.TotalPages, new CommandEventHandler(Command_TotalPages));
            this.SubscribeToCommand(CommandManager.SaveCurrentPageAsImage, new CommandEventHandler(Command_SaveCurrentPageAsImage));
            this.SubscribeToCommand(CommandManager.SaveMultiplePagesAsImages, new CommandEventHandler(Command_SaveMultiplePagesAsImages));
        }

        #endregion

        #region ApplyApplicationOptions

        private void ApplyApplicationOptions()
        {
            _viewer.ProgressiveUpdate = GhostscriptStudio.Options.Editor_ProgressiveUpdate;
            _viewer.ProgressiveUpdateInterval = GhostscriptStudio.Options.Editor_ProgressiveUpdate_Interval;
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

        #region _viewer_DisplaySize

        void _viewer_DisplaySize(object sender, GhostscriptViewerViewEventArgs e)
        {
            if (_disablePreviewAndCommands)
                return;

            pbPage.Width = e.Image.Width;
            pbPage.Height = e.Image.Height;
            pbPage.Image = null;
            pbPage.Update();
            pbPage.Image = e.Image;
        }

        #endregion

        #region _viewer_DisplayUpdate

        void _viewer_DisplayUpdate(object sender, GhostscriptViewerViewEventArgs e)
        {
            if (_disablePreviewAndCommands)
                return;

            pbPage.Invalidate();
            pbPage.Update();
        }

        #endregion

        #region _viewer_DisplayPage

        void _viewer_DisplayPage(object sender, GhostscriptViewerViewEventArgs e)
        {
            if (_disablePreviewAndCommands)
                return;

            pbPage.Invalidate();
            pbPage.Update();
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
            _editor.Text = File.ReadAllText(path);
            _editor.UndoRedo.EmptyUndoBuffer();
            _currentFile = path;

            EnvironmentManager.QueryAndSetWorkspaceCommandUIState();

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
                File.WriteAllText(_currentFile, _editor.Text);

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
            sfd.Filter = "PostScript file|*.ps";
            if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                _currentFile = sfd.FileName;

                File.WriteAllText(_currentFile, _editor.Text);

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
                    return LocalizationManager.GetFormText("editor.untitled") + _untitledNumber.ToString() + ".ps";
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
                e.UIEnabled = !_isViewing;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(_editor.Text))
                {
                    return;
                }

                if (this.IsDirty)
                {
                    if (!this.Save())
                    {
                        return;
                    }
                }

                _isViewing = true;

                rtbOutput.Clear();

                this.SetUIState(true);

                _viewer.Open(_currentFile, UIHelper.GetGhostscriptVersionInfoFromOptions(), true);

                //_viewer.Open(UIHelper.GetGhostscriptVersionInfoFromOptions(), true);


                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_Stop

        private void Command_Stop(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _isViewing;
            }
            else
            {
                _isViewing = false;

                this.SetUIState(false);
                
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_FirstPage

        private void Command_FirstPage(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _isViewing && _viewer.CanShowFirstPage;
            }
            else
            {
                _viewer.ShowFirstPage();
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_PreviousPage

        private void Command_PreviousPage(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _isViewing && _viewer.CanShowPreviousPage;
            }
            else
            {
                _viewer.ShowPreviousPage();
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_NextPage

        private void Command_NextPage(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _isViewing && _viewer.CanShowNextPage;
            }
            else
            {
                _viewer.ShowNextPage();
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_LastPage

        private void Command_LastPage(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _isViewing && _viewer.CanShowLastPage;
            }
            else
            {
                _viewer.ShowLastPage();
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_ZoomIn

        private void Command_ZoomIn(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _isViewing && _viewer.CanZoomIn && _viewer.LastPageNumber > 0;
            }
            else
            {
                _viewer.ZoomIn();
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_ZoomOut

        private void Command_ZoomOut(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _isViewing && _viewer.CanZoomOut && _viewer.LastPageNumber > 0;
            }
            else
            {
                _viewer.ZoomOut();
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_PageNumber

        private void Command_PageNumber(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _isViewing;
                
                if (_isViewing)
                {
                    e.UIValue = _disablePreviewAndCommands ? e.UIValue : _viewer.CurrentPageNumber;
                }
            }
            else
            {
                if (_disablePreviewAndCommands)
                    return;

                int pageNumber = _viewer.CurrentPageNumber;

                if (int.TryParse(e.Command.Value.ToString(), out pageNumber))
                {
                    if (_viewer.IsPageNumberValid(pageNumber))
                    {
                        _viewer.ShowPage(pageNumber);
                    }
                }

                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_TotalPages

        private void Command_TotalPages(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _isViewing;

                if (_isViewing)
                {
                    e.UIValue = "/ " + _viewer.LastPageNumber.ToString();
                }
            }
        }

        #endregion

        #region Command_SaveCurrentPageAsImage

        private void Command_SaveCurrentPageAsImage(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _isViewing && _viewer.CurrentPageNumber >= _viewer.FirstPageNumber && _viewer.CurrentPageNumber <= _viewer.LastPageNumber;
            }
            else
            {
                _disablePreviewAndCommands = true;

                try
                {
                    GhostscriptViewerToImageUtility.CurrentViewPageToImage(_viewer);
                }
                finally
                {
                    _disablePreviewAndCommands = false;
                }
            }
        }

        #endregion

        #region Command_SaveMultiplePagesAsImages

        private void Command_SaveMultiplePagesAsImages(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _isViewing && _viewer.CurrentPageNumber >= _viewer.FirstPageNumber && _viewer.CurrentPageNumber <= _viewer.LastPageNumber;
            }
            else
            {
                _disablePreviewAndCommands = true;

                try
                {
                    GhostscriptViewerToImageUtility.CurrentViewPagesToImages(_viewer);
                }
                finally
                {
                    _disablePreviewAndCommands = false;
                }
            }
        }

        #endregion

        #region AppendToOutput

        private void AppendToTheOutput(string text)
        {
            rtbOutput.AppendText(text);
            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        #endregion

        #region SetUIState

        private void SetUIState(bool forView)
        {
            _editor.IsReadOnly = forView;

            if (forView)
            {
                _editor.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                _editor.BackColor = System.Drawing.Color.White;
            }

            _editor.Lexing.Colorize();
        }

        #endregion

    }
}
