#region This file is part of Ghostscript.Studio application
//
// GhostscriptViewerToImageUtility.cs
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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Artifex.Ghostscript.NET.Viewer;
using Artifex.Ghostscript.NET.Rasterizer;
using Ghostscript.Studio.Windows;

namespace Ghostscript.Studio
{
    public class GhostscriptViewerToImageUtility : IProgressNotificationExecution
    {

        #region Private variables

        private GhostscriptViewer _viewer;
        private int _DPI;
        private List<int> _pages;
        private string _directory;
        private string _filename;

        #endregion

        #region Constructor

        public GhostscriptViewerToImageUtility(GhostscriptViewer viewer, int dpi, List<int> pages, string directory, string filename)
        {
            _viewer = viewer;
            _DPI = dpi;
            _pages = pages;
            _directory = directory;
            _filename = filename;
        }

        #endregion

        #region Execute

        public void Execute(FProgress progress)
        {
            ImageFormat outputFormat = this.GetImageFormatFromExtension(Path.GetExtension(_filename));

            string message = LocalizationManager.GetFormText("other.message.savingpage");

            progress.Minimum = 1;
            progress.Maximum = _pages.Count;

            GhostscriptRasterizer rasterizer = new GhostscriptRasterizer(_viewer);

            try
            {
                int pageCounter = 0;

                for (int index = 0; index < _pages.Count; index++)
                {
                    pageCounter++;

                    int pageNumber = _pages[index];

                    progress.Description = string.Format(message, pageCounter, progress.Maximum);
                    progress.Value = pageCounter;
                    progress.DoEvents();

                    //Image img = rasterizer.GetPage(_xDPI, _yDPI, pageNumber);
                    Image img = rasterizer.GetPage(_DPI, pageNumber);

                    if (progress.Cancel)
                    {
                        break;
                    }

                    string outputPath = Path.Combine(_directory, _filename.Replace("#pagenumber#", pageNumber.ToString()));

                    if (File.Exists(outputPath))
                    {
                        File.Delete(outputPath);
                    }

                    if (img != null)
                    {
                        img.Save(outputPath, outputFormat);
                    }
                }
            }
            finally
            {
                rasterizer.Dispose();
            }
        }

        #endregion

        #region CurrentViewPageToImage

        public static void CurrentViewPageToImage(GhostscriptViewer viewer)
        {
            using (FSinglePageSettings frmSettings = new FSinglePageSettings())
            {
                frmSettings.Text = LocalizationManager.GetFormText("other.title.savecurrentpageasimage.settings");

                frmSettings.nudDpi.Value = GhostscriptStudio.Options.SaveSinglePageToImage_Dpi;
                frmSettings.chkOpenWindowsExplorerWhenDone.Checked = GhostscriptStudio.Options.SaveSinglePageToImage_OpenOutputLocation;

                if (frmSettings.ShowDialog(GhostscriptStudio.MainWindow) == System.Windows.Forms.DialogResult.OK)
                {
                    GhostscriptStudio.Options.SaveSinglePageToImage_Dpi = (int)frmSettings.nudDpi.Value;
                    GhostscriptStudio.Options.SaveSinglePageToImage_OpenOutputLocation = frmSettings.chkOpenWindowsExplorerWhenDone.Checked;
                    GhostscriptStudio.SaveOptions();

                    string path = DialogsHelper.ShowSaveFileDialog(
                                        GhostscriptStudio.MainWindow,
                                        LocalizationManager.GetFormText("other.title.savecurrentpageasimage.saveas"),
                                        "PNG Image|*.png|" +
                                        "JPEG Image|*.jpeg|" +
                                        "BMP Image|*.bmp");

                    if (string.IsNullOrWhiteSpace(path))
                    {
                        return;
                    }

                    string directory = Path.GetDirectoryName(path);
                    string filename = Path.GetFileName(path);

                    GhostscriptViewerToImageUtility gviu = new GhostscriptViewerToImageUtility(
                            viewer,
                            (int)frmSettings.nudDpi.Value,
                            new List<int>() { viewer.CurrentPageNumber },
                            directory,
                            filename);

                    using (FProgress frmProgress = new FProgress(gviu))
                    {
                        frmProgress.Text = LocalizationManager.GetFormText("other.title.savecurrentpageasimage.progress");

                        if (frmProgress.ShowDialog(GhostscriptStudio.MainWindow) != System.Windows.Forms.DialogResult.Cancel)
                        {
                            if (frmSettings.chkOpenWindowsExplorerWhenDone.Checked)
                            {
                                Process.Start("explorer", directory);
                            }

                            DialogsHelper.ShowMessageBox(GhostscriptStudio.MainWindow, "saving_page_to_image_completed", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        #endregion

        #region CurrentViewPagesToImages

        public static void CurrentViewPagesToImages(GhostscriptViewer viewer)
        {
            using (FMultiPageSettings frmSettings = new FMultiPageSettings(viewer.FirstPageNumber, viewer.LastPageNumber))
            {
                frmSettings.Text = LocalizationManager.GetFormText("other.title.savemlutiplepagesasimages.settings");

                if (frmSettings.ShowDialog(GhostscriptStudio.MainWindow) == System.Windows.Forms.DialogResult.OK)
                {
                    GhostscriptViewerToImageUtility gviu = new GhostscriptViewerToImageUtility(
                            viewer,
                            (int)frmSettings.nudDpi.Value,
                            frmSettings.SelectedPages,
                            frmSettings.txtFolder.Text.Trim(),
                            frmSettings.txtFilenameFormat.Text.Trim() + UIHelper.GetComboBoxValue(frmSettings.cboFileType));

                    using (FProgress frmProgress = new FProgress(gviu))
                    {
                        frmProgress.Text = LocalizationManager.GetFormText("other.title.savemlutiplepagesasimages.progress");

                        if (frmProgress.ShowDialog(GhostscriptStudio.MainWindow) != System.Windows.Forms.DialogResult.Cancel)
                        {
                            if (frmSettings.chkOpenWindowsExplorerWhenDone.Checked)
                            {
                                Process.Start("explorer", frmSettings.txtFolder.Text.Trim());
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region GetImageFormatFromExtension

        private ImageFormat GetImageFormatFromExtension(string extension)
        {
            switch (extension.ToLower())
            {
                case ".png":
                    return ImageFormat.Png;
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".bmp":
                    return ImageFormat.Bmp;
                default:
                    return ImageFormat.Gif;
            }
        }

        #endregion
    }
}
