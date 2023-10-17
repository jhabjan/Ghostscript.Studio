#region This file is part of Ghostscript.Studio application
//
// SystemEnvironment.cs
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
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Ghostscript.Studio.Commands;
using Ghostscript.Studio.Managers;
using Ghostscript.Studio.Windows;
using Ghostscript.Studio.Workspaces;
using Ghostscript.Studio.Workspaces.Processor;
using Ghostscript.Studio.Workspaces.Viewer;
using Ghostscript.Studio.Workspaces.Editor;

namespace Ghostscript.Studio.Environments
{
    public class SystemEnvironment : EnvironmentBase
    {
        #region Constructor

        public SystemEnvironment()
        {
            this.SubscribeToCommand(CommandManager.NewGhostscriptProcessor, new CommandEventHandler(Command_NewGhostscriptProcessor));
            this.SubscribeToCommand(CommandManager.NewPostScriptEditor, new CommandEventHandler(Command_NewPostScriptEditor));
            this.SubscribeToCommand(CommandManager.Open, new CommandEventHandler(Command_Open));
            this.SubscribeToCommand(CommandManager.SaveAll, new CommandEventHandler(Command_SaveAll));
            this.SubscribeToCommand(CommandManager.Exit, new CommandEventHandler(Command_Exit));
            this.SubscribeToCommand(CommandManager.Options, new CommandEventHandler(Command_Options));
            this.SubscribeToCommand(CommandManager.GhostscripProcessorSwitchesPresets, new CommandEventHandler(Command_GhostscripProcessorSwitchesPresets));
            this.SubscribeToCommand(CommandManager.GhostscripProcessorPostscriptPresets, new CommandEventHandler(Command_GhostscripProcessorPostscriptPresets));
            this.SubscribeToCommand(CommandManager.CheckForNewRelease, new CommandEventHandler(Command_CheckForNewRelease));
            this.SubscribeToCommand(CommandManager.ReportABug, new CommandEventHandler(Command_ReportABug));
            this.SubscribeToCommand(CommandManager.About, new CommandEventHandler(Command_About));
        }

        #endregion

        #region Command_NewGhostscriptProcessor

        private void Command_NewGhostscriptProcessor(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
                return;
            }

            EnvironmentManager.AddWorkspace(new FProcessorWorkspace());
        }

        #endregion

        #region Command_NewPostScriptEditor

        private void Command_NewPostScriptEditor(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
                return;
            }

            EnvironmentManager.AddWorkspace(new FEditorWorkspace());
        }

        #endregion

        #region Command_Open

        private void Command_Open(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
                return;
            }

            string filename = string.Empty;

            if (Program.OpenFromProgramArgsFirst)
            {
                filename = Program.Args[0];
            }
            else
            {
                string[] files = DialogsHelper.ShowOpenFileDialog(
                                            GhostscriptStudio.MainWindow, LocalizationManager.GetFormText("global.open"),
                                            "All files|*.pdf;*.ps;*.eps;*.gspr|Ghostscript.Studio Processor|*.gspr|PDF Files|*.pdf|PostScript Files|*.ps|Encapsulated PostScript|*.eps|Ghostscript Studio Project File|*.gspr", false);
                if (files != null)
                {
                    filename = files[0];
                }
            }

            if (!string.IsNullOrWhiteSpace(filename))
            {
                string extension = Path.GetExtension(filename).ToLower();

                FWorkspaceBase workspace = null;

                switch (extension)
                {
                    case ".gspr":
                        {
                            workspace = new FProcessorWorkspace();
                            break;
                        }
                    case ".pdf":
                        {
                            workspace = new FViewerWorkspace();
                            break;
                        }
                    case ".ps":
                        {
                            FOpenMode frm = new FOpenMode();

                            if (frm.ShowDialog(GhostscriptStudio.MainWindow) == System.Windows.Forms.DialogResult.OK)
                            {
                                if (frm.IsForViewing)
                                {
                                    workspace = new FViewerWorkspace();
                                }
                                else
                                {
                                    workspace = new FEditorWorkspace();
                                }
                            }
                            else
                            {
                                return;
                            }

                            break;
                        }
                    case ".eps":
                        {
                            workspace = new FViewerWorkspace();
                            break;
                        }
                }

                workspace.Open(filename);

                EnvironmentManager.AddWorkspace(workspace);
            }
        }

        #endregion

        #region Command_SaveAll

        private void Command_SaveAll(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                foreach (KeyValuePair<FWorkspaceBase, WorkspaceEnvironment> w in EnvironmentManager.Workspaces)
                {
                    if (w.Key.IsDirty)
                    {
                        e.UIEnabled = true;
                        return;
                    }
                }

                e.UIEnabled = false;
                return;
            }
            else
            {
                foreach (KeyValuePair<FWorkspaceBase, WorkspaceEnvironment> w in EnvironmentManager.Workspaces)
                {
                    if (w.Key.IsDirty)
                    {
                        w.Key.Show(GhostscriptStudio.WorkspaceHost);

                        if (!w.Key.SaveAll())
                        {
                            return;
                        }
                    }
                }
            }
        }

        #endregion

        #region Command_Exit

        private void Command_Exit(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
                return;
            }

            Dictionary<FWorkspaceBase, WorkspaceEnvironment> copy = new Dictionary<FWorkspaceBase, WorkspaceEnvironment>(EnvironmentManager.Workspaces);

            foreach (KeyValuePair<FWorkspaceBase, WorkspaceEnvironment> w in copy)
            {
                if (w.Key.IsRunning)
                {
                    DialogsHelper.ShowMessageBox(GhostscriptStudio.MainWindow, "workspace_running", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (w.Key.IsDirty)
                {
                    w.Key.Show(GhostscriptStudio.WorkspaceHost);

                    DialogResult r = DialogsHelper.ShowMessageBox(GhostscriptStudio.MainWindow, "changes_made_wanna_save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, w.Key.Text.Replace("*", ""));

                    if (r == DialogResult.Yes)
                    {
                        if (!w.Key.SaveAll())
                        {
                            return;
                        }
                        else
                        {
                            w.Key.CanClose = true;
                            w.Key.Close();
                        }
                    }
                    else if (r == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (r == DialogResult.No)
                    {
                        w.Key.CanClose = true;
                        w.Key.Close();
                    }
                }
                else
                {
                    w.Key.Close();
                }
            }

            Application.Exit();
        }

        #endregion

        #region Command_Options

        private void Command_Options(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
                return;
            }

            FOptions frm = new FOptions();
            frm.ShowDialog(GhostscriptStudio.MainWindow);
            frm.Dispose(); frm = null;
        }

        #endregion

        #region Command_Options

        private void Command_GhostscripProcessorSwitchesPresets(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
                return;
            }

            using (FPresets frm = new FPresets(PresetType.GhostscriptProcessorSwitches))
            {
                frm.ShowDialog(GhostscriptStudio.MainWindow);
            }
        }

        #endregion

        #region Command_Options

        private void Command_GhostscripProcessorPostscriptPresets(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
                return;
            }

            using (FPresets frm = new FPresets(PresetType.GhostscriptProcessorPostScript))
            {
                frm.ShowDialog(GhostscriptStudio.MainWindow);
            }
        }

        #endregion

        #region Command_CheckForNewRelease

        private void Command_CheckForNewRelease(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
                return;
            }

            Process.Start("https://ghostscriptstudio.codeplex.com");
        }

        #endregion

        #region Command_ReportABug

        private void Command_ReportABug(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
                return;
            }

            Process.Start("https://ghostscriptstudio.codeplex.com/workitem/list/basic");
        }

        #endregion

        #region Command_About

        private void Command_About(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
                return;
            }

            FAbout frm = new FAbout();
            frm.ShowDialog(GhostscriptStudio.MainWindow);
            frm.Dispose(); frm = null;
        }

        #endregion
    }
}
