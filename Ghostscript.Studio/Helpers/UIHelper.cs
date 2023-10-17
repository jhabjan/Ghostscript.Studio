#region This file is part of Ghostscript.Studio application
//
// UIHelper.cs
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
using Artifex.Ghostscript.NET;
using System.Windows.Forms;

namespace Ghostscript.Studio
{
    public class UIHelper
    {
        #region GetInstalledGhostscriptVersionsForDisplay

        public static List<ComboBoxItem> GetInstalledGhostscriptVersionsForDisplay()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();
            List<GhostscriptVersionInfo> gsVersions = GhostscriptVersionInfo.GetInstalledVersions(GhostscriptLicense.GPL | GhostscriptLicense.AFPL);

            foreach (GhostscriptVersionInfo v in gsVersions)
            {
                items.Add(new ComboBoxItem(v.LicenseType + " " + v.Version.ToString(), v.LicenseType.ToString() + " Ghostscript v." + v.Version.ToString()));
            }

            return items;
        }

        #endregion

        #region GetLanguagesForDisplay

        public static List<ComboBoxItem> GetLanguagesForDisplay()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();

            List<Language> languages = LocalizationManager.GetLanguagesHeaders();
            foreach (Language l in languages)
            {
                items.Add(new ComboBoxItem(l.Culture, l.Name));
            }

            return items;
        }

        #endregion

        #region GetGhostscriptVersionInfoFromOptions

        public static GhostscriptVersionInfo GetGhostscriptVersionInfoFromOptions()
        {
            List<GhostscriptVersionInfo> gsVersions = GhostscriptVersionInfo.GetInstalledVersions(GhostscriptLicense.GPL | GhostscriptLicense.AFPL);

            foreach (GhostscriptVersionInfo v in gsVersions)
            {
                string gsVersion = v.LicenseType + " " + v.Version.ToString();

                if (gsVersion == GhostscriptStudio.Options.GhostscriptVersion)
                {
                    return v;
                }
            }

            return GhostscriptVersionInfo.GetLastInstalledVersion(GhostscriptLicense.GPL | GhostscriptLicense.AFPL, GhostscriptLicense.GPL);
        }

        #endregion

        #region GetComboBoxValue

        public static string GetComboBoxValue(ComboBox combobox)
        {
            if (combobox.SelectedItem == null)
                return null;

            return (combobox.SelectedItem as ComboBoxItem).Value;
        }

        #endregion
    }
}
