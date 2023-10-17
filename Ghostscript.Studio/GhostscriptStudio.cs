#region This file is part of Ghostscript.Studio application
//
// GhostscriptStudio.cs
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
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Ghostscript.Studio.Windows;
using WeifenLuo.WinFormsUI.Docking;
using Ghostscript.Studio.Managers;
using Ghostscript.Studio.Workspaces;
using Ghostscript.Studio.Workspaces.Processor;
using Artifex.Ghostscript.NET;

namespace Ghostscript.Studio
{
    public static class GhostscriptStudio
    {
        #region Private variables

        private static FMain _mainWindow = null;
        private static GhostscriptStudioOptions _options;

        #endregion

        #region Public events

        public static event EventHandler OptionsChanged;

        #region OnOptionsChanged

        private static void OnOptionsChanged(EventArgs e)
        {
            if (OptionsChanged != null)
            {
                OptionsChanged(null, e);
            }
        }

        #endregion

        #endregion

        #region MainWindow

        public static FMain MainWindow
        {
            get { return _mainWindow; }
            set { _mainWindow = value; }
        }

        #endregion

        #region WorkspaceHost

        public static DockPanel WorkspaceHost
        {
            get { return _mainWindow.dockPanel; }
        }

        #endregion

        #region Options

        public static GhostscriptStudioOptions Options
        {
            get 
            {
                if (_options == null)
                {
                    _options = GhostscriptStudioOptions.Open(Path.Combine(Program.ApplicationDataPath, "Ghostscript.Studio." + Program.Version + ".config"));

                    if (_options == null)
                    {
                        _options = new GhostscriptStudioOptions();
                    }
                }

                return _options; 
            }
        }

        #endregion

        #region SaveOptions

        public static void SaveOptions()
        {
            GhostscriptStudioOptions.Save(GhostscriptStudio.Options, Path.Combine(Program.ApplicationDataPath, "Ghostscript.Studio." + Program.Version + ".config"));
            OnOptionsChanged(new EventArgs());
        }

        #endregion
    }

    #region class GhostscriptStudioOptions

    [Serializable]
    [XmlRoot("GhostscriptStudioOptions")]
    public class GhostscriptStudioOptions
    {

        #region Constructor

        public GhostscriptStudioOptions()
        {
            GhostscriptVersionInfo gvi = GhostscriptVersionInfo.GetLastInstalledVersion(GhostscriptLicense.GPL | GhostscriptLicense.AFPL, GhostscriptLicense.GPL);

            ShowSupportWindowAtStartup = true;
            Language = "en-US";
            ShowSupportWindowAtStartup = true;
            GhostscriptVersion = gvi.LicenseType + " " + gvi.Version.ToString();
            Editor_ProgressiveUpdate = true;
            Editor_ProgressiveUpdate_Interval = 100;
            Viewer_ProgressiveUpdate = true;
            Viewer_ProgressiveUpdate_Interval = 100;
            SaveSinglePageToImage_OpenOutputLocation = true;
            SaveSinglePageToImage_Dpi = 96;
        }

        #endregion

        #region Properties

        public bool ShowSupportWindowAtStartup { get; set; }
        public string GhostscriptVersion { get; set; }
        public string Language { get; set; }
        public bool Editor_ProgressiveUpdate { get; set; }
        public int Editor_ProgressiveUpdate_Interval { get; set; }
        public bool Viewer_ProgressiveUpdate { get; set; }
        public int Viewer_ProgressiveUpdate_Interval { get; set; }
        public bool SaveSinglePageToImage_OpenOutputLocation { get; set; }
        public int SaveSinglePageToImage_Dpi { get; set; }
        public string Processor_LastOutputFolder { get; set; }
        public string MultipageSettings_LastOutputFolder { get; set; }

        #endregion

        #region Open

        public static GhostscriptStudioOptions Open(string path)
        {
            GhostscriptStudioOptions op = XmlHelper.CreateFromXmlFile(path, typeof(GhostscriptStudioOptions)) as GhostscriptStudioOptions;
            return op;
        }

        #endregion

        #region Save

        public static void Save(object instance, string path)
        {
            XmlHelper.SaveToXmlFile(instance, path);
        }

        #endregion
    }

    #endregion
}
