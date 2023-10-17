#region This file is part of Ghostscript.Studio application
//
// DefaultEditableControl.cs
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

namespace Ghostscript.Studio
{
    public class DefaultEditableControl : EditableControlBase
    {

        #region Public properties

        #region CanUndo

        public override bool CanUndo
        {
            get { return false; }
        }

        #endregion

        #region CanRedo

        public override bool CanRedo
        {
            get { return false; }
        }

        #endregion

        #region CanCut

        public override bool CanCut
        {
            get { return false; }
        }

        #endregion

        #region CanCopy

        public override bool CanCopy
        {
            get { return false; }
        }

        #endregion

        #region CanPaste

        public override bool CanPaste
        {
            get { return false; }
        }

        #endregion

        #region CanSelectAll

        public override bool CanSelectAll
        {
            get { return false; }
        }

        #endregion

        #endregion

        #region Public methods

        #region Undo

        public override void Undo()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Redo

        public override void Redo()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Cut

        public override void Cut()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Copy

        public override void Copy()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Paste

        public override void Paste()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region SelectAll

        public override void SelectAll()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

    }
}
