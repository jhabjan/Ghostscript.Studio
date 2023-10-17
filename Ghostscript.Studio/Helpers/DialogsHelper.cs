#region This file is part of Ghostscript.Studio application
//
// DialogsHelper.cs
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

namespace Ghostscript.Studio
{
    public class DialogsHelper
    {
        #region ShowMessageBox

        public static DialogResult ShowMessageBox(IWin32Window owner, string id, MessageBoxButtons buttons, MessageBoxIcon icon, params object[] args)
        {
            LanguageMessageBoxItem lmbi = LocalizationManager.GetMessageBoxItem(id);
            return MessageBox.Show(owner, string.Format(lmbi.Message, args), lmbi.Title, buttons, icon);
        }

        #endregion

        #region ShowFolderBrowserDialog

        public static string ShowFolderBrowserDialog(IWin32Window owner, string selectedPath)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = true;
                fbd.SelectedPath = selectedPath;
                if (fbd.ShowDialog(owner) == DialogResult.OK)
                {
                    return fbd.SelectedPath;
                }

                return null;
            }
        }

        #endregion

        #region ShowOpenFileDialog

        public static string[] ShowOpenFileDialog(IWin32Window owner, string title, string filter, bool multiSelect)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = title;
                ofd.Filter = filter;
                ofd.Multiselect = multiSelect;
             
                if (ofd.ShowDialog(owner) == DialogResult.OK)
                {
                    if (multiSelect)
                    {
                        return ofd.FileNames;
                    }
                    else
                    {
                        return new string[] { ofd.FileName };
                    }
                }

                return null;
            }
        }

        #endregion

        #region ShowSaveFileDialog

        public static string ShowSaveFileDialog(IWin32Window owner, string title, string filter)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = title;
                sfd.Filter = filter;

                if (sfd.ShowDialog(owner) == DialogResult.OK)
                {
                    return sfd.FileName;
                }

                return null;
            }
        }

        #endregion
    }
}
