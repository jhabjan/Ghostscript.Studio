#region This file is part of Ghostscript.Studio application
//
// EditableControlHandler.cs
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
using ScintillaNET;

namespace Ghostscript.Studio
{
    public class EditableControlHandler : EditableControlBase
    {
        #region Private variables

        private EditableControlBase _editableControl = new DefaultEditableControl();

        #endregion

        #region Public events

        public event EventHandler QueryAndSetWorkspaceCommandUIState;
        public event EventHandler ContentChanged;

        #endregion

        #region OnQueryAndSetWorkspaceCommandUIState

        protected void OnQueryAndSetWorkspaceCommandUIState(EventArgs e)
        {
            if (QueryAndSetWorkspaceCommandUIState != null)
            {
                QueryAndSetWorkspaceCommandUIState(this, e);
            }
        }

        #endregion

        #region OnContentChanged

        protected void OnContentChanged(EventArgs e)
        {
            if (ContentChanged != null)
            {
                ContentChanged(this, e);
            }
        }

        #endregion

        #region RegisterControlForUIStateChangeHandling

        public void RegisterControlForUIStateChangeHandling(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.Enter += EditableControl_Enter;
                control.Leave += EditableControl_Leave;

                Type controlType = control.GetType();

                if (controlType == typeof(Scintilla))
                {
                    Scintilla ctrl = control as Scintilla;
                    ctrl.SelectionChanged += EditableControl_SelectionChanged;
                }
                else if (controlType == typeof(TextBox))
                {
                    TextBox ctrl = control as TextBox;
                    // textbox doesn't supprot SelectionChanged so this is the closest we can do for now
                    ctrl.MouseUp += EditableControl_SelectionChanged;
                    ctrl.KeyUp += EditableControl_SelectionChanged;
                    ctrl.TextChanged += EditableControl_ContentChanged;
                }
                else if (controlType == typeof(RichTextBox))
                {
                    RichTextBox ctrl = control as RichTextBox;
                    ctrl.SelectionChanged += EditableControl_SelectionChanged;
                }
            }
        }

        #endregion

        #region RegisterControlForContentChangeHandling

        public void RegisterControlForContentChangeHandling(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                Type controlType = control.GetType();

                if (controlType == typeof(Scintilla))
                {
                    Scintilla ctrl = control as Scintilla;
                    ctrl.TextChanged += EditableControl_ContentChanged;
                }
                else if (controlType == typeof(TextBox))
                {
                    TextBox ctrl = control as TextBox;
                    ctrl.TextChanged += EditableControl_ContentChanged;
                }
                else if (controlType == typeof(RichTextBox))
                {
                    RichTextBox ctrl = control as RichTextBox;
                    ctrl.TextChanged += EditableControl_ContentChanged;
                }
            }
        }

        #endregion

        #region EditableControl_Enter

        void EditableControl_Enter(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Scintilla))
            {
                _editableControl = new ScintillaEditableControl(sender as Scintilla);
            }
            else if (sender.GetType() == typeof(TextBox))
            {
                _editableControl = new TextBoxEditableControl(sender as TextBox);
            }
            else if (sender.GetType() == typeof(RichTextBox))
            {
                _editableControl = new RichTextBoxEditableControl(sender as RichTextBox);
            }
            else
            {
                _editableControl = new DefaultEditableControl();
            }

            this.OnQueryAndSetWorkspaceCommandUIState(new EventArgs());
        }

        #endregion

        #region EditableControl_Leave

        void EditableControl_Leave(object sender, EventArgs e)
        {
            _editableControl = new DefaultEditableControl();

            this.OnQueryAndSetWorkspaceCommandUIState(new EventArgs());
        }

        #endregion

        #region EditableControl_SelectionChanged

        void EditableControl_SelectionChanged(object sender, EventArgs e)
        {
            this.OnQueryAndSetWorkspaceCommandUIState(new EventArgs());
        }

        #endregion

        #region EditableControl_ContentChanged

        void EditableControl_ContentChanged(object sender, EventArgs e)
        {
            this.OnContentChanged(new EventArgs());
        }

        #endregion

        #region Public properties

        #region CanUndo

        public override bool CanUndo
        {
            get { return _editableControl.CanUndo; }
        }

        #endregion

        #region CanRedo

        public override bool CanRedo
        {
            get { return _editableControl.CanRedo; }
        }

        #endregion

        #region CanCut

        public override bool CanCut
        {
            get { return _editableControl.CanCut; }
        }

        #endregion

        #region CanCopy

        public override bool CanCopy
        {
            get { return _editableControl.CanCopy; }
        }

        #endregion

        #region CanPaste

        public override bool CanPaste
        {
            get { return _editableControl.CanPaste; }
        }

        #endregion

        #region CanSelectAll

        public override bool CanSelectAll
        {
            get { return _editableControl.CanSelectAll; }
        }

        #endregion

        #endregion

        #region Public methods

        #region Undo

        public override void Undo()
        {
            _editableControl.Undo();
            this.OnQueryAndSetWorkspaceCommandUIState(new EventArgs());
        }

        #endregion

        #region Redo

        public override void Redo()
        {
            _editableControl.Redo();
            this.OnQueryAndSetWorkspaceCommandUIState(new EventArgs());
        }

        #endregion

        #region Cut

        public override void Cut()
        {
            _editableControl.Cut();
            this.OnQueryAndSetWorkspaceCommandUIState(new EventArgs());
        }

        #endregion

        #region Copy

        public override void Copy()
        {
            _editableControl.Copy();
            this.OnQueryAndSetWorkspaceCommandUIState(new EventArgs());
        }

        #endregion

        #region Paste

        public override void Paste()
        {
            _editableControl.Paste();
            this.OnQueryAndSetWorkspaceCommandUIState(new EventArgs());
        }

        #endregion

        #region SelectAll

        public override void SelectAll()
        {
            _editableControl.SelectAll();
            this.OnQueryAndSetWorkspaceCommandUIState(new EventArgs());
        }

        #endregion

        #endregion

    }
}
