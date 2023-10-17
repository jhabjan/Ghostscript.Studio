#region This file is part of Ghostscript.Studio application
//
// EnvironmentManager.cs
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
using Ghostscript.Studio.Commands;
using Ghostscript.Studio.Environments;
using Ghostscript.Studio.Workspaces;

namespace Ghostscript.Studio.Managers
{
    public class EnvironmentManager
    {
        #region Private variables

        private static int _untitledCounter = 0;
        private static SystemEnvironment _systemEnvironment = new SystemEnvironment();
        private static Dictionary<FWorkspaceBase, WorkspaceEnvironment> _workspaces = new Dictionary<FWorkspaceBase, WorkspaceEnvironment>();
        private static WorkspaceEnvironment _activeWorkspace = null;

        #endregion

        #region Initialize

        public static void Initialize()
        {
            GhostscriptStudio.WorkspaceHost.ActiveDocumentChanged += new EventHandler(WorkspaceHost_ActiveDocumentChanged);
            EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
        }

        #endregion

        #region AddWorkspace

        public static void AddWorkspace(FWorkspaceBase workspace)
        {
            _workspaces.Add(workspace, new WorkspaceEnvironment(workspace));
            workspace.FormClosing += new FormClosingEventHandler(Workspace_FormClosing);
            workspace.Show(GhostscriptStudio.WorkspaceHost);

            EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
        }

        #endregion

        #region WorkspaceHost_ActiveDocumentChanged

        private static void WorkspaceHost_ActiveDocumentChanged(object sender, EventArgs e)
        {
            FWorkspaceBase workspace = GhostscriptStudio.WorkspaceHost.ActiveDocument as FWorkspaceBase;

            if (workspace != null)
            {
                _activeWorkspace = _workspaces[workspace];
            }
            else
            {
                _activeWorkspace = null;
            }

            EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
        }

        #endregion

        #region Workspace_FormClosing

        private static void Workspace_FormClosing(object sender, FormClosingEventArgs e)
        {
            FWorkspaceBase frm = sender as FWorkspaceBase;

            if (!frm.CanClose)
            {
                if (frm.IsDirty)
                {
                    DialogResult r = DialogsHelper.ShowMessageBox(GhostscriptStudio.MainWindow, "changes_made_wanna_save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, frm.Text.Replace("*", ""));

                    if (r == DialogResult.Yes)
                    {
                        if (!frm.SaveAll())
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    else if (r == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            _workspaces.Remove(frm);
        }

        #endregion

        #region RunSystemCommand

        public static void RunSystemCommand(object sender, CommandEventArgs e)
        {
            _systemEnvironment.SubscribedCommands[e.Command](sender, e);
        }

        #endregion

        #region RunWorkspaceCommand

        public static void RunWorkspaceCommand(object sender, CommandEventArgs e)
        {
            if (_activeWorkspace != null)
            {
                if (_activeWorkspace.SubscribedCommands.ContainsKey(e.Command))
                {
                    _activeWorkspace.SubscribedCommands[e.Command](sender, e);
                }
            }
        }

        #endregion

        #region SubscribeToCommand

        public static void SubscribeToCommand(FWorkspaceBase workspace, Command command, CommandEventHandler dispatchTo)
        {
            _workspaces[workspace].SubscribeToCommand(command, dispatchTo);
        }

        #endregion

        #region GetNextUntitleNumber

        public static int GetNextUntitledNumber()
        {
            _untitledCounter++;
            return _untitledCounter;
        }

        #endregion

        #region QueryAndSetWorkspaceCommandUIState

        public static void QueryAndSetWorkspaceCommandUIState()
        {
            EnvironmentManager.QueryAndSetSystemCommandUIState();

            if (_activeWorkspace == null)
            {
                CommandManager.DisableAllWorkspaceCommands();
                return;
            }

            Dictionary<Command, CommandEventHandler> subscribedCommands = _activeWorkspace.SubscribedCommands;

            foreach (Command command in CommandManager.WorkspaceCommands)
            {
                if (subscribedCommands.ContainsKey(command))
                {
                    CommandEventArgs cea = new CommandEventArgs(command, CommandEventType.UIStateQuery);
                    cea.UIEnabled = command.Enabled;
                    cea.UIValue = command.Value;
                    subscribedCommands[command](command, cea);
                    command.Enabled = cea.UIEnabled;
                    command.Value = cea.UIValue;
                }
                else
                {
                    command.Enabled = false;
                    command.Value = null;
                }
            }
        }

        #endregion

        #region QueryAndSetSystemCommandUIState

        public static void QueryAndSetSystemCommandUIState()
        {
            Dictionary<Command, CommandEventHandler> subscribedCommands = _systemEnvironment.SubscribedCommands;

            foreach (Command command in CommandManager.SystemCommands)
            {
                if (subscribedCommands.ContainsKey(command))
                {
                    CommandEventArgs cea = new CommandEventArgs(command, CommandEventType.UIStateQuery);
                    cea.UIEnabled = command.Enabled;
                    cea.UIValue = command.Value;
                    subscribedCommands[command](command, cea);
                    command.Enabled = cea.UIEnabled;
                    command.Value = cea.UIValue;
                }
                else
                {
                    command.Enabled = false;
                    command.Value = null;
                }
            }
        }

        #endregion

        #region Workspaces

        public static Dictionary<FWorkspaceBase, WorkspaceEnvironment> Workspaces
        {
            get { return _workspaces; }
        }

        #endregion
    }
}
