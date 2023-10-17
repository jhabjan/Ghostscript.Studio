#region This file is part of Ghostscript.Studio application
//
// Command.cs
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

namespace Ghostscript.Studio.Commands
{
    public class Command
    {
        #region Private variables

        private List<CommandSource> _sources = new List<CommandSource>();
        private CommandEventHandler _dispatchTo;

        #endregion

        #region Command

        public Command(CommandEventHandler dispatchTo)
        {
            _dispatchTo = dispatchTo;
        }

        #endregion

        #region AddSource

        public void AddSource(params CommandSource[] commandSources)
        {
            foreach (CommandSource commandSource in commandSources)
            {
                commandSource.RunCommand += new EventHandler(commandSource_RunCommand);
                _sources.Add(commandSource);
            }
        }

        #endregion

        #region commandSource_RunCommand

        private void commandSource_RunCommand(object sender, EventArgs e)
        {
            if (_dispatchTo != null)
            {
                _dispatchTo(this, new CommandEventArgs(this, CommandEventType.RunCommand));
            }
        }

        #endregion

        #region Invoke

        public void Invoke()
        {
            this.commandSource_RunCommand(this, new EventArgs());
        }

        #endregion

        #region Enabled

        public bool Enabled
        {
            get
            {
                return _sources[0].Enabled;
            }
            set
            {
                foreach (CommandSource commandSource in _sources)
                {
                    if (commandSource.Enabled != value)
                    {
                        commandSource.Enabled = value;
                    }
                }
            }
        }

        #endregion

        #region Value

        public object Value
        {
            get
            {
                return _sources[0].Value;
            }
            set
            {
                foreach (CommandSource commandSource in _sources)
                {
                    if (commandSource.Value != value)
                    {
                        commandSource.Value = value;
                    }
                }
            }
        }

        #endregion
    }
}
