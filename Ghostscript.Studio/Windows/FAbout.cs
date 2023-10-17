#region This file is part of Ghostscript.Studio application
//
// FAbout.cs
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
using System.Reflection;
using System.Drawing;
using System.IO;

namespace Ghostscript.Studio.Windows
{
    public partial class FAbout : Form
    {

        #region Constructor

        public FAbout()
        {
            InitializeComponent();

            this.Font = Program.DefaultFont;

            this.TranslateUI();
        }

        #endregion

        #region TranslateUI

        private void TranslateUI()
        {
            this.Text = LocalizationManager.GetFormText("about.title");
            btnClose.Text = LocalizationManager.GetFormText("about.btnClose");
            lblVersion.Text = string.Format(LocalizationManager.GetFormText("about.version"), Program.Version);
            lblComponentsUsed.Text = LocalizationManager.GetFormText("about.lblComponentsUsed");
            lblTranslations.Text = LocalizationManager.GetFormText("about.lblTranslations");
        }

        #endregion

        #region HexConverter

        private string HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        #endregion

        #region wbAbout_NewWindow

        void wbAbout_NewWindow(object sender, CancelEventArgs e)
        {
            string url = wbAbout.Document.ActiveElement.GetAttribute("href");
            System.Diagnostics.Process.Start(url);
            e.Cancel = true;
        }

        #endregion

        #region wbComponentsUsed_NewWindow

        void wbComponentsUsed_NewWindow(object sender, CancelEventArgs e)
        {
            string url = wbComponentsUsed.Document.ActiveElement.GetAttribute("href");
            System.Diagnostics.Process.Start(url);
            e.Cancel = true;
        }

        #endregion

        #region btnClose_Click

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region FAbout_Shown

        private void FAbout_Shown(object sender, EventArgs e)
        {
            string about = global::Ghostscript.Studio.Properties.Resources.about_main;
            about = about.Replace("#bgcolor", this.HexConverter(Color.LightYellow));
            wbAbout.DocumentText = about;
            wbAbout.NewWindow += new CancelEventHandler(wbAbout_NewWindow);

            string componentsUsed = global::Ghostscript.Studio.Properties.Resources.about_used_components;
            componentsUsed = componentsUsed.Replace("#bgcolor", this.HexConverter(Color.LightYellow));
            wbComponentsUsed.DocumentText = componentsUsed;
            wbComponentsUsed.NewWindow += new CancelEventHandler(wbComponentsUsed_NewWindow);

            string translations = global::Ghostscript.Studio.Properties.Resources.about_translations;
            translations = translations.Replace("#bgcolor", this.HexConverter(Color.LightYellow));

            string langTemp = "<span>#language&nbsp;:&nbsp;#author&nbsp;(<a href=\"#email\">#email</a>)</span></br>";

            System.Text.StringBuilder sbLanguages = new System.Text.StringBuilder();

            List<Language> languages = LocalizationManager.GetLanguagesHeaders();
            foreach (Language l in languages)
            {
                sbLanguages.AppendLine(langTemp.Replace("#language", l.InternationalName).Replace("#author", l.AuthorName).Replace("#email", l.AuthorEmail));
            }

            translations = translations.Replace("#languages", sbLanguages.ToString());

            wbTranslations.DocumentText = translations;
        }

        #endregion

    }
}
