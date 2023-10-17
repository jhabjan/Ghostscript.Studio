#region This file is part of Ghostscript.Studio application
//
// FWorkspaceBase.cs
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
using System.Windows.Forms;
using Ghostscript.Studio.Windows;
using Ghostscript.Studio.Commands;
using Ghostscript.Studio.Managers;

namespace Ghostscript.Studio.Workspaces
{
    public partial class FWorkspaceBase : FDockableWindow
    {
        #region Private variables

        private bool _isDirty = false;
        private bool _canClose = false;

        #endregion

        #region Constructor

        public FWorkspaceBase()
        {
            InitializeComponent();
        }

        #endregion

        #region SubscribeToCommand

        public void SubscribeToCommand(Command command, CommandEventHandler dispatchTo)
        {
            EnvironmentManager.SubscribeToCommand(this, command, dispatchTo);
        }

        #endregion

        #region IsDirty

        public virtual bool IsDirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }

        #endregion

        #region IsRunning

        public virtual bool IsRunning
        {
            get { return false; }
        }

        #endregion

        #region CanClose

        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        #endregion

        #region Open

        public virtual bool Open(string path)
        {
            return true;
        }

        #endregion

        #region SaveAll

        public virtual bool SaveAll()
        {
            return true;
        }

        #endregion
    }
}
