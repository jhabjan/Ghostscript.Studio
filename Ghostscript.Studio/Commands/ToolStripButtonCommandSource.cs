﻿#region This file is part of Ghostscript.Studio application
//
// ToolStripButtonCommandSource.cs
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

namespace Ghostscript.Studio.Commands
{
    /// <summary>
    /// Command source wrapper for the ToolStripButton.
    /// </summary>
    public class ToolStripButtonCommandSource : CommandSource
    {
        #region Private variables

        private ToolStripButton _toolStripButton;

        #endregion

        #region Constructor

        public ToolStripButtonCommandSource(ToolStripButton toolStripButton)
        {
            _toolStripButton = toolStripButton;
            _toolStripButton.Click += new EventHandler(toolStripButton_Click);
        }

        #endregion

        #region toolStripButton_Click

        void toolStripButton_Click(object sender, EventArgs e)
        {
            base.OnRunCommand(e);
        }

        #endregion

        #region Enabled

        public override bool Enabled
        {
            get
            {
                return _toolStripButton.Enabled;
            }
            set
            {
                _toolStripButton.Enabled = value;
            }
        }

        #endregion

        #region Value

        public override object Value
        {
            get { return null; }
            set { }
        }

        #endregion
    }
}
