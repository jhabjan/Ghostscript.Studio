#region This file is part of Ghostscript.Studio application
//
// FProgress.cs
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

namespace Ghostscript.Studio.Windows
{
    public partial class FProgress : Form
    {

        #region Private variables

        private IProgressNotificationExecution _progressNotificationExecution;
        private bool _cancel = false;

        #endregion

        #region Constructor

        public FProgress(IProgressNotificationExecution progressNotificationExecution)
        {
            InitializeComponent();

            this.Font = Program.DefaultFont;

            _progressNotificationExecution = progressNotificationExecution;

            this.TranslateUI();
        }

        #endregion

        #region TranslateUI

        private void TranslateUI()
        {
            btnCancel.Text = LocalizationManager.GetFormText("global.cancel");
        }

        #endregion

        #region FProgress_Shown

        private void FProgress_Shown(object sender, EventArgs e)
        {
            _progressNotificationExecution.Execute(this);

            if (_cancel)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

            this.Close();
        }

        #endregion

        #region Minimum

        public int Minimum
        {
            get { return pbProgress.Minimum; }
            set { pbProgress.Minimum = value; }
        }

        #endregion

        #region Maximum

        public int Maximum
        {
            get { return pbProgress.Maximum; }
            set { pbProgress.Maximum = value; }
        }

        #endregion

        #region Value

        public int Value
        {
            get { return pbProgress.Value; }
            set 
            { 
                pbProgress.Value = value;
                pbProgress.Refresh();
            }
        }

        #endregion

        #region Increment

        public void Increment(int value)
        {
            pbProgress.Increment(value);
            pbProgress.Refresh();
        }

        #endregion

        #region PerformStep

        public void PerformStep()
        {
            pbProgress.PerformStep();
            pbProgress.Refresh();
        }

        #endregion

        #region Description

        public string Description
        {
            get { return lblProgress.Text; }
            set 
            { 
                lblProgress.Text = value;
                lblProgress.Update();
            }
        }

        #endregion

        #region DoEvents

        public void DoEvents()
        {
            Application.DoEvents();
        }

        #endregion

        #region btnCancel_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancel = true;
        }

        #endregion

        #region Cancel

        public bool Cancel
        {
            get { return _cancel; }
        }

        #endregion

        #region FProgress_FormClosing

        private void FProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                _cancel = true;
            }
        }

        #endregion

    }
}
