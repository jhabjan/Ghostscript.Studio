#region This file is part of Ghostscript.Studio application
//
// EditorStdIO.cs
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Artifex.Ghostscript.NET;

namespace Ghostscript.Studio.Workspaces.Editor
{
    public class EditorStdIO : GhostscriptStdIO
    {
        #region Private variables

        private RichTextBox _output;

        #endregion

        #region Constructor

        public EditorStdIO(RichTextBox output) : base(true, true, true) 
        {
            _output = output;
        }

        #endregion

        #region StdIn

        public override void StdIn(out string input, int count)
        {
            input = string.Empty;
        }

        #endregion

        #region StdOut

        public override void StdOut(string output)
        {
            this.AppendToOutput(output);
        }

        #endregion

        #region StdError

        public override void StdError(string error)
        {
            this.AppendToOutput(error);
        }

        #endregion

        #region AppendToOutput

        private void AppendToOutput(string message)
        {
            if (_output.InvokeRequired)
            {
                _output.Invoke(new OutputEventHandler(AppendToOutput), message);
            }
            else
            {
                _output.AppendText(message + "\r\n");
                _output.SelectionStart = _output.Text.Length;
                _output.ScrollToCaret();
            }
        }

        #endregion

        #region OutputEventHandler

        public delegate void OutputEventHandler(string message);

        #endregion
    }
}
