#region This file is part of Ghostscript.Studio application
//
// GhostscriptProcessorLexer.cs
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
using Ghostscript.Studio.Commands;

namespace Ghostscript.Studio.Managers
{
    public class CommandManager
    {
        #region Public static variables

        // MENU - FILE

        public static readonly Command NewGhostscriptProcessor = new Command(EnvironmentManager.RunSystemCommand);
        public static readonly Command NewPostScriptEditor = new Command(EnvironmentManager.RunSystemCommand);
        public static readonly Command Open = new Command(EnvironmentManager.RunSystemCommand);
        public static readonly Command Save = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command SaveAs = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command SaveAll = new Command(EnvironmentManager.RunSystemCommand);
        public static readonly Command Exit = new Command(EnvironmentManager.RunSystemCommand);

        // MENU - EDIT

        public static readonly Command Undo = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command Redo = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command Cut = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command Copy = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command Paste = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command SelectAll = new Command(EnvironmentManager.RunWorkspaceCommand);

        // MENU - VIEW

        public static readonly Command FirstPage = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command PreviousPage = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command NextPage = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command LastPage = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command ZoomIn = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command ZoomOut = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command PageNumber = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command TotalPages = new Command(EnvironmentManager.RunWorkspaceCommand);

        // MENU - RUN

        public static readonly Command Start = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command Stop = new Command(EnvironmentManager.RunWorkspaceCommand);

        // MENU - WORKSPACE

        public static readonly Command SaveCurrentPageAsImage = new Command(EnvironmentManager.RunWorkspaceCommand);
        public static readonly Command SaveMultiplePagesAsImages = new Command(EnvironmentManager.RunWorkspaceCommand);

        // MENU - TOOLS

        public static readonly Command Options = new Command(EnvironmentManager.RunSystemCommand);
        public static readonly Command GhostscripProcessorSwitchesPresets = new Command(EnvironmentManager.RunSystemCommand);
        public static readonly Command GhostscripProcessorPostscriptPresets = new Command(EnvironmentManager.RunSystemCommand);

        // MENU - HELP

        public static readonly Command CheckForNewRelease = new Command(EnvironmentManager.RunSystemCommand);
        public static readonly Command ReportABug = new Command(EnvironmentManager.RunSystemCommand);
        public static readonly Command About = new Command(EnvironmentManager.RunSystemCommand);



        private static List<Command> _systemCommands = new List<Command>();
        private static List<Command> _workspaceCommands = new List<Command>();

        #endregion

        #region Constructor

        static CommandManager()
        {
            _systemCommands.AddRange(new Command[] { 
                NewGhostscriptProcessor, 
                NewPostScriptEditor,
                Open,
                SaveAll,
                Exit,
                Options,
                GhostscripProcessorSwitchesPresets,
                GhostscripProcessorPostscriptPresets,
                CheckForNewRelease,
                ReportABug,
                About
            });

            _workspaceCommands.AddRange(new Command[] {
                Save,
                SaveAs,
                Undo,
                Redo,
                Cut,
                Copy,
                Paste,
                SelectAll,
                FirstPage,
                PreviousPage,
                NextPage,
                LastPage,
                ZoomIn,
                ZoomOut,
                PageNumber,
                TotalPages,
                SaveCurrentPageAsImage,
                SaveMultiplePagesAsImages,
                Start,
                Stop
            });
        }

        #endregion

        #region SystemCommands

        public static List<Command> SystemCommands
        {
            get { return _systemCommands; }
        }

        #endregion

        #region WorkspaceCommands

        public static List<Command> WorkspaceCommands
        {
            get { return _workspaceCommands; }
        }

        #endregion

        #region DisableAllCommands

        public static void DisableAllCommands()
        {
            CommandManager.DisableAllSystemCommands();
            CommandManager.DisableAllWorkspaceCommands();
        }

        #endregion

        #region EnableAllCommands

        public static void EnableAllCommands()
        {
            CommandManager.EnableAllSystemCommands();
            CommandManager.EnableAllWorkspaceCommands();
        }

        #endregion

        #region DisableAllSystemCommands

        public static void DisableAllSystemCommands()
        {
            foreach (Command command in _systemCommands)
            {
                command.Enabled = false;
                command.Value = null;
            }
        }

        #endregion

        #region DisableAllWorkspaceCommands

        public static void DisableAllWorkspaceCommands()
        {
            foreach (Command command in _workspaceCommands)
            {
                command.Enabled = false;
                command.Value = null;
            }
        }

        #endregion

        #region EnableAllSystemCommands

        public static void EnableAllSystemCommands()
        {
            foreach (Command command in _systemCommands)
            {
                command.Enabled = true;
            }
        }

        #endregion

        #region EnableAllWorkspaceCommands

        public static void EnableAllWorkspaceCommands()
        {
            foreach (Command command in _workspaceCommands)
            {
                command.Enabled = true;
            }
        }

        #endregion

        #region GetWorkspaceUIEnabledState

        public static Dictionary<Command, bool> GetWorkspaceUIEnabledState()
        {
            Dictionary<Command, bool> states = new Dictionary<Command, bool>();

            foreach (Command command in _workspaceCommands)
            {
                states.Add(command, command.Enabled);
            }

            return states;
        }

        #endregion

    }
}
