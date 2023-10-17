using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using Ghostscript.Studio.Lexers;
using Ghostscript.Studio.Commands;
using Ghostscript.Studio.Managers;
using Ghostscript.Studio.Windows;
using Artifex.Ghostscript.NET.Viewer;
using System.IO;

namespace Ghostscript.Studio.Workspaces.Viewer
{
    public partial class FViewerWorkspace : FWorkspaceBase
    {

        #region Private variables

        private GhostscriptViewer _viewer;
        private bool _disablePreviewAndCommands = false;

        #endregion

        #region Constructor

        public FViewerWorkspace()
        {
            InitializeComponent();

            GhostscriptStudio.OptionsChanged += new EventHandler(GhostscriptStudio_OptionsChanged);

            _viewer = new GhostscriptViewer();

            _viewer.DisplaySize += new GhostscriptViewerViewEventHandler(_viewer_DisplaySize);
            _viewer.DisplayUpdate += new GhostscriptViewerViewEventHandler(_viewer_DisplayUpdate);
            _viewer.DisplayPage += new GhostscriptViewerViewEventHandler(_viewer_DisplayPage);

            this.ApplyApplicationOptions();
        }

        #endregion

        #region GhostscriptStudio_OptionsChanged

        void GhostscriptStudio_OptionsChanged(object sender, EventArgs e)
        {
            this.ApplyApplicationOptions();
        }

        #endregion

        #region FViewerWorkspace_Shown

        private void FViewerWorkspace_Shown(object sender, EventArgs e)
        {
            this.AttachCommandHandlers();
            EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
        }

        #endregion

        #region AttachCommandHandlers

        private void AttachCommandHandlers()
        {
            this.SubscribeToCommand(CommandManager.FirstPage, new CommandEventHandler(Command_FirstPage));
            this.SubscribeToCommand(CommandManager.PreviousPage, new CommandEventHandler(Command_PreviousPage));
            this.SubscribeToCommand(CommandManager.NextPage, new CommandEventHandler(Command_NextPage));
            this.SubscribeToCommand(CommandManager.LastPage, new CommandEventHandler(Command_LastPage));
            this.SubscribeToCommand(CommandManager.ZoomIn, new CommandEventHandler(Command_ZoomIn));
            this.SubscribeToCommand(CommandManager.ZoomOut, new CommandEventHandler(Command_ZoomOut));
            this.SubscribeToCommand(CommandManager.PageNumber, new CommandEventHandler(Command_PageNumber));
            this.SubscribeToCommand(CommandManager.TotalPages, new CommandEventHandler(Command_TotalPages));
            this.SubscribeToCommand(CommandManager.SaveCurrentPageAsImage, new CommandEventHandler(Command_SaveCurrentPageAsImage));
            this.SubscribeToCommand(CommandManager.SaveMultiplePagesAsImages, new CommandEventHandler(Command_SaveMultiplePagesAsImages));
        }

        #endregion

        #region ApplyApplicationOptions

        private void ApplyApplicationOptions()
        {
            _viewer.ProgressiveUpdate = GhostscriptStudio.Options.Viewer_ProgressiveUpdate;
            _viewer.ProgressiveUpdateInterval = GhostscriptStudio.Options.Viewer_ProgressiveUpdate_Interval;
        }

        #endregion

        #region Open

        public override bool Open(string path)
        {
            try
            {
                _viewer.Open(path, UIHelper.GetGhostscriptVersionInfoFromOptions(), true);

                this.Text = Path.GetFileName(path);

                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        #endregion

        #region _viewer_DisplaySize

        void _viewer_DisplaySize(object sender, GhostscriptViewerViewEventArgs e)
        {
            if (_disablePreviewAndCommands)
                return;

            pbPage.Width = e.Image.Width;
            pbPage.Height = e.Image.Height;
            pbPage.Image = null;
            pbPage.Update();
            pbPage.Image = e.Image;
        }

        #endregion

        #region _viewer_DisplayUpdate

        void _viewer_DisplayUpdate(object sender, GhostscriptViewerViewEventArgs e)
        {
            if (_disablePreviewAndCommands)
                return;

            pbPage.Invalidate();
            pbPage.Update();
        }

        #endregion

        #region _viewer_DisplayPage

        void _viewer_DisplayPage(object sender, GhostscriptViewerViewEventArgs e)
        {
            if (_disablePreviewAndCommands)
                return;

            pbPage.Invalidate();
            pbPage.Update();
        }

        #endregion

        #region Command_FirstPage

        private void Command_FirstPage(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _viewer.CanShowFirstPage;
            }
            else
            {
                _viewer.ShowFirstPage();
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_PreviousPage

        private void Command_PreviousPage(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _viewer.CanShowPreviousPage;
            }
            else
            {
                _viewer.ShowPreviousPage();
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_NextPage

        private void Command_NextPage(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _viewer.CanShowNextPage;
            }
            else
            {
                _viewer.ShowNextPage();
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_LastPage

        private void Command_LastPage(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _viewer.CanShowLastPage;
            }
            else
            {
                _viewer.ShowLastPage();
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_ZoomIn

        private void Command_ZoomIn(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _viewer.CanZoomIn;
            }
            else
            {
                _viewer.ZoomIn();
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_ZoomOut

        private void Command_ZoomOut(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _viewer.CanZoomOut;
            }
            else
            {
                _viewer.ZoomOut();
                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_PageNumber

        private void Command_PageNumber(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
                e.UIValue = _disablePreviewAndCommands ? e.UIValue : _viewer.CurrentPageNumber;
            }
            else
            {
                if (_disablePreviewAndCommands)
                    return;

                int pageNumber = _viewer.CurrentPageNumber;

                if (int.TryParse(e.Command.Value.ToString(), out pageNumber))
                {
                    if (_viewer.IsPageNumberValid(pageNumber))
                    {
                        _viewer.ShowPage(pageNumber);
                    }
                }

                EnvironmentManager.QueryAndSetWorkspaceCommandUIState();
            }
        }

        #endregion

        #region Command_TotalPages

        private void Command_TotalPages(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = true;
                e.UIValue = "/ " + _viewer.LastPageNumber.ToString();
            }
        }

        #endregion

        #region Command_SaveCurrentPageAsImage

        private void Command_SaveCurrentPageAsImage(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _viewer.CurrentPageNumber >= _viewer.FirstPageNumber && _viewer.CurrentPageNumber <= _viewer.LastPageNumber;
            }
            else
            {
                _disablePreviewAndCommands = true;

                try
                {
                    GhostscriptViewerToImageUtility.CurrentViewPageToImage(_viewer);
                }
                finally
                {
                    _disablePreviewAndCommands = false;
                }
            }
        }

        #endregion

        #region Command_SaveMultiplePagesAsImages

        private void Command_SaveMultiplePagesAsImages(object sender, CommandEventArgs e)
        {
            if (e.Type == CommandEventType.UIStateQuery)
            {
                e.UIEnabled = _viewer.CurrentPageNumber >= _viewer.FirstPageNumber && _viewer.CurrentPageNumber <= _viewer.LastPageNumber;
            }
            else
            {
                _disablePreviewAndCommands = true;

                try
                {
                    GhostscriptViewerToImageUtility.CurrentViewPagesToImages(_viewer);
                }
                finally
                {
                    _disablePreviewAndCommands = false;
                }
            }
        }

        #endregion

    }
}
