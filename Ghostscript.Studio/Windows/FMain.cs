#region This file is part of Ghostscript.Studio application
//
// FMain.cs
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

namespace Ghostscript.Studio.Windows
{
    public partial class FMain : Form
    {

        #region Constructor

        public FMain()
        {
            InitializeComponent();

            this.Font = Program.DefaultFont;

            this.Text = Program.NAME + " " + Program.Version;

            this.Localize();
            this.AttachCommands();
        }

        #endregion

        #region FMain_FormClosing

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommandManager.Exit.Invoke();

            if (EnvironmentManager.Workspaces.Count > 0)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Localize

        private void Localize()
        {
            foreach (ToolStripMenuItem tsi in mnuMain.Items)
            {
                this.LocalizeMenuDropDownItem(tsi, 0);
            }

            foreach(ToolStripItem tsi in tsMain.Items)
            {
                this.LocalizeAndAttachToolbarItem(tsi);
            }

            foreach (ToolStripItem tsi in defaultEditorContextMenu.Items)
            {
                if (tsi.GetType() == typeof(ToolStripMenuItem))
                {
                    this.LocalizeMenuDropDownItem(tsi as ToolStripMenuItem, 1);
                }
            }
        }

        #endregion

        #region LocalizeMenuDropDownItem

        private void LocalizeMenuDropDownItem(ToolStripMenuItem tsi, int level)
        {
            if (tsi.DropDownItems.Count > 0 || level == 0)
            {
                if (level == 0)
                {
                    tsi.Text = LocalizationManager.GetMenuEntry(tsi.Tag.ToString().ToLower());
                }
                else
                {
                    tsi.Text = LocalizationManager.GetMenuSubEntry(tsi.Tag.ToString().ToLower());
                }

                foreach (ToolStripItem subTsi in tsi.DropDownItems)
                {
                    if (subTsi.GetType() == typeof(ToolStripMenuItem))
                    {
                        this.LocalizeMenuDropDownItem(subTsi as ToolStripMenuItem, level + 1);
                    }
                }
            }
            else
            {
                tsi.Text = LocalizationManager.GetMenuCommand(tsi.Tag.ToString().ToLower());
            }
        }

        #endregion

        #region LocalizeAndAttachToolbarItem

        private void LocalizeAndAttachToolbarItem(ToolStripItem tsi)
        {
            if (tsi.GetType() != typeof(ToolStripSeparator) && 
                tsi.GetType() != typeof(ToolStripTextBox) &&
                tsi.GetType() != typeof(ToolStripLabel))
            {
                tsi.ToolTipText = LocalizationManager.GetMenuCommand(tsi.Tag.ToString().ToLower()).Replace("&", "");
            }

            tsb_New_Ghostscript_Processor.Text = LocalizationManager.GetMenuCommand("tsb_new_ghostscript_processor");
            tsb_New_PostScript_Editor.Text = LocalizationManager.GetMenuCommand("tsb_new_postscript_editor");
        }

        #endregion

        #region AttachCommands

        private void AttachCommands()
        {
            // >>>>> FILE RELATED

            CommandManager.NewGhostscriptProcessor.AddSource(
                new ToolStripMenuItemCommandSource(mnu_File_New_Ghostscript_Processor),
                new ToolStripMenuItemCommandSource(tsb_New_Ghostscript_Processor));

            CommandManager.NewPostScriptEditor.AddSource(
                new ToolStripMenuItemCommandSource(mnu_File_New_PostScript_Editor),
                new ToolStripMenuItemCommandSource(tsb_New_PostScript_Editor));

            CommandManager.Open.AddSource(
                new ToolStripMenuItemCommandSource(mnu_File_Open),
                new ToolStripButtonCommandSource(tsb_Open));

            CommandManager.Save.AddSource(
                new ToolStripMenuItemCommandSource(mnu_File_Save),
                new ToolStripButtonCommandSource(tsb_Save));

            CommandManager.SaveAs.AddSource(
                new ToolStripMenuItemCommandSource(mnu_File_Save_As));

            CommandManager.SaveAll.AddSource(
                new ToolStripMenuItemCommandSource(mnu_File_Save_All),
                new ToolStripButtonCommandSource(tsb_Save_All));

            CommandManager.Exit.AddSource(
                new ToolStripMenuItemCommandSource(mnu_File_Exit));

            // >>>>> EDIT RELATED

            CommandManager.Undo.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Edit_Undo),
                new ToolStripMenuItemCommandSource(ctx_editor_Undo),
                new ToolStripButtonCommandSource(tsb_Undo));

            CommandManager.Redo.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Edit_Redo),
                new ToolStripMenuItemCommandSource(ctx_editor_Redo),
                new ToolStripButtonCommandSource(tsb_Redo));

            CommandManager.Cut.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Edit_Cut),
                new ToolStripMenuItemCommandSource(ctx_editor_Cut),
                new ToolStripButtonCommandSource(tsb_Cut));

            CommandManager.Copy.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Edit_Copy),
                new ToolStripMenuItemCommandSource(ctx_editor_Copy),
                new ToolStripButtonCommandSource(tsb_Copy));

            CommandManager.Paste.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Edit_Paste),
                new ToolStripMenuItemCommandSource(ctx_editor_Paste),
                new ToolStripButtonCommandSource(tsb_Paste));

            CommandManager.SelectAll.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Edit_Select_All),
                new ToolStripMenuItemCommandSource(ctx_editor_Select_All));

            // >>>>> VIEW RELATED

            CommandManager.FirstPage.AddSource(
                new ToolStripMenuItemCommandSource(mnu_View_First_Page),
                new ToolStripButtonCommandSource(tsb_First_Page));

            CommandManager.PreviousPage.AddSource(
                new ToolStripMenuItemCommandSource(mnu_View_Previous_Page),
                new ToolStripButtonCommandSource(tsb_Previous_Page));

            CommandManager.NextPage.AddSource(
                new ToolStripMenuItemCommandSource(mnu_View_Next_Page),
                new ToolStripButtonCommandSource(tsb_Next_Page));

            CommandManager.LastPage.AddSource(
                new ToolStripMenuItemCommandSource(mnu_View_Last_Page),
                new ToolStripButtonCommandSource(tsb_Last_Page));

            CommandManager.ZoomIn.AddSource(
                new ToolStripMenuItemCommandSource(mnu_View_Zoom_In),
                new ToolStripButtonCommandSource(tsb_Zoom_In));

            CommandManager.ZoomOut.AddSource(
                new ToolStripMenuItemCommandSource(mnu_View_Zoom_Out),
                new ToolStripButtonCommandSource(tsb_Zoom_Out));

            CommandManager.PageNumber.AddSource(
                new ToolStripTextBoxCommandSource(tst_Page_Number));

            CommandManager.TotalPages.AddSource(
                new ToolStripLabelCommandSource(tsl_Total_Pages));

            // >>>>> WORKSPACE RELATED

            CommandManager.SaveCurrentPageAsImage.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Workspace_Save_Current_Page_As_Image));

            CommandManager.SaveMultiplePagesAsImages.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Workspace_Save_Multiple_Pages_As_Images));

            // >>>>> RUN RELATED

            CommandManager.Start.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Run_Start),
                new ToolStripButtonCommandSource(tsb_Start));

            CommandManager.Stop.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Run_Stop),
                new ToolStripButtonCommandSource(tsb_Stop));

            // >>>>> TOOLS RELATED

            CommandManager.Options.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Tools_Options));

            CommandManager.GhostscripProcessorSwitchesPresets.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Tools_Ghostscript_Processor_Switches_Presets));

            CommandManager.GhostscripProcessorPostscriptPresets.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Tools_Ghostscript_Processor_Postscript_Presets));

            // >>>>> HELP RELATED

            CommandManager.CheckForNewRelease.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Help_Check_For_New_Release));

            CommandManager.ReportABug.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Help_Report_A_Bug));

            CommandManager.About.AddSource(
                new ToolStripMenuItemCommandSource(mnu_Help_About));
        }

        #endregion

        #region FMain_Load

        private void FMain_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region GetDefaultEditorContextMenu

        public ContextMenuStrip GetDefaultEditorContextMenu()
        {
            return defaultEditorContextMenu;
        }

        #endregion

        #region FMain_Shown

        private void FMain_Shown(object sender, EventArgs e)
        {
            if (Program.Args != null)
            {
                if (Program.Args.Length == 1)
                {
                    Program.OpenFromProgramArgsFirst = true;
                    CommandManager.Open.Invoke();
                    Program.OpenFromProgramArgsFirst = false;
                }
            }

            if (GhostscriptStudio.Options.ShowSupportWindowAtStartup)
            {
                using (FSupport frm = new FSupport())
                {
                    frm.ShowDialog(this);
                    GhostscriptStudio.Options.ShowSupportWindowAtStartup = !frm.chkDontShowThisAgain.Checked;
                    GhostscriptStudio.SaveOptions();
                }
            }
        }

        #endregion

    }
}
