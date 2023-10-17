#region This file is part of Ghostscript.Studio application
//
// Program.cs
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
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using Ghostscript.Studio.Windows;
using Ghostscript.Studio.Managers;
using Artifex.Ghostscript.NET;

namespace Ghostscript.Studio
{
    static class Program
    {
        #region Public variables

        public static string NAME = "Ghostscript Studio";

        #endregion

        #region Private variables

        private static string[] _args;
        private static bool _openFromArgsFirst = false;
        private static Font _defaultFont;

        #endregion

        #region Main

        [STAThread]
        static void Main(string[] args)
        {
            _args = args;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LocalizationManager.Initialize();

            GhostscriptVersionInfo gv = GhostscriptVersionInfo.GetLastInstalledVersion(GhostscriptLicense.GPL | GhostscriptLicense.AFPL, GhostscriptLicense.GPL);

            if (gv == null)
            {
                if (Environment.Is64BitProcess)
                {
                    DialogsHelper.ShowMessageBox(null, "ghostscript_x64_not_found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogsHelper.ShowMessageBox(null, "ghostscript_x32_not_found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            _defaultFont = new Font("Calibri", 9f, FontStyle.Regular);

            if (_defaultFont.FontFamily.Name != "Calibri")
            {
                _defaultFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            }

            GhostscriptStudio.MainWindow = new FMain();

            EnvironmentManager.Initialize();

            // first time scintilla loading takes more than 500 milliseconds
            // let's load it at this point so user does not expirience ui freezing later
            ScintillaNET.Scintilla sc = new ScintillaNET.Scintilla();
            sc.ConfigurationManager.Language = "ps";

            Application.Run(GhostscriptStudio.MainWindow);
        }

        #endregion

        #region AppPath

        public static string AppPath
        {
            get
            {
                return Application.StartupPath;
            }
        }

        #endregion

        #region MapAppPath

        public static string MapAppPath(string path)
        {
            return Path.Combine(Program.AppPath, path);
        }

        #endregion

        #region MapDataPath

        public static string MapDataPath(string path)
        {
            return Path.Combine(Program.ApplicationDataPath, path);
        }

        #endregion

        #region ApplicationDataPath

        public static string ApplicationDataPath
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                //string path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Ghostscript.Studio");
                //IOHelper.EnsureDirectory(path);
                //return path;
            }
        }

        #endregion

        #region Args

        public static string[] Args
        {
            get { return _args; }
        }

        #endregion

        #region OpenFromProgramArgsFirst

        public static bool OpenFromProgramArgsFirst
        {
            get { return _openFromArgsFirst; }
            set { _openFromArgsFirst = value; }
        }

        #endregion

        #region Version

        public static string Version
        {
            get
            {
                Version v = Assembly.GetExecutingAssembly().GetName().Version;
                return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
            }
        }

        #endregion

        #region DefaultFont

        public static Font DefaultFont
        {
            get { return _defaultFont; }
        }

        #endregion
    }

}
