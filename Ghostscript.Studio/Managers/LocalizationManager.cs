#region This file is part of Ghostscript.Studio application
//
// LocalizationManager.cs
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
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.IO;

namespace Ghostscript.Studio
{
    public class LocalizationManager
    {

        #region Private constants

        private const string TRANSLATION_MISSING = ">> MISSING TRANSLATION";

        #endregion

        #region Private variables

        public static Language _defaultLanguage = null;
        public static Language _userLanguage = null;

        #endregion

        #region Initialize

        public static void Initialize()
        {
            string languagePath = Program.MapAppPath("Localization\\language." + GhostscriptStudio.Options.Language + ".xml");

            // load default app language (this one is always up-to-date)
            MemoryStream msDefLng = new MemoryStream(Properties.Resources.language_en_US);
            _defaultLanguage = Language.Load(msDefLng, false);
            msDefLng.Close(); msDefLng.Dispose(); msDefLng = null;

            // load user selected language
            try
            {
                if (File.Exists(languagePath))
                {
                    _userLanguage = Language.Load(languagePath, false);
                }
            }
            catch { }
        }

        #endregion

        #region CurrentLanguage

        public static Language CurrentLanguage
        {
            get
            {
                Language lng = _userLanguage;

                if (lng == null)
                {
                    lng = _defaultLanguage;
                }

                return lng;
            }
        }

        #endregion

        #region MessageBox

        public static LanguageMessageBox MessageBox
        {
            get
            {
                return LocalizationManager.CurrentLanguage.MessageBox;
            }
        }

        #endregion

        #region GetMessageBoxItem

        public static LanguageMessageBoxItem GetMessageBoxItem(string id)
        {
            Dictionary<string, LanguageMessageBoxItem> items = LocalizationManager.MessageBox.Items;

            if (items.ContainsKey(id))
            {
                return items[id];
            }
            else
            {
                return _defaultLanguage.MessageBox.Items[id];
            }
        }

        #endregion

        #region GetMenuEntry

        public static string GetMenuEntry(string id)
        {
            Dictionary<string, string> items = LocalizationManager.CurrentLanguage.Menu.Entries;

            if (items.ContainsKey(id))
            {
                return items[id];
            }
            else
            {
                try
                {
                    return _defaultLanguage.Menu.Entries[id];
                }
                catch
                {
                    return TRANSLATION_MISSING;
                }
            }
        }

        #endregion

        #region GetMenuSubEntry

        public static string GetMenuSubEntry(string id)
        {
            Dictionary<string, string> items = LocalizationManager.CurrentLanguage.Menu.SubEntries;

            if (items.ContainsKey(id))
            {
                return items[id];
            }
            else
            {
                if (_defaultLanguage.Menu.SubEntries.ContainsKey(id))
                {
                    return _defaultLanguage.Menu.SubEntries[id];
                }
                else
                {
                    return TRANSLATION_MISSING;
                }
            }
        }

        #endregion

        #region GetMenuCommand

        public static string GetMenuCommand(string id)
        {
            Dictionary<string, string> items = LocalizationManager.CurrentLanguage.Menu.Commands;

            if (items.ContainsKey(id))
            {
                return items[id];
            }
            else
            {
                if (_defaultLanguage.Menu.Commands.ContainsKey(id))
                {
                    return _defaultLanguage.Menu.Commands[id];
                }
                else
                {
                    // check maybe sub entry has this value
                    return GetMenuSubEntry(id);
                }
            }
        }

        #endregion

        #region GetFormText

        public static string GetFormText(string id)
        {
            if (LocalizationManager.CurrentLanguage.Form.ContainsKey(id))
            {
                return LocalizationManager.CurrentLanguage.Form[id];
            }
            else
            {
                return _defaultLanguage.Form[id];
            }
        }

        #endregion

        #region GetLanguagesHeaders

        public static List<Language> GetLanguagesHeaders()
        {
            List<Language> languages = new List<Language>();

            string locPath = Program.MapAppPath("localization");

            if (Directory.Exists(locPath))
            {
                DirectoryInfo di = new DirectoryInfo(Program.MapAppPath("localization"));
                FileInfo[] files = di.GetFiles("language.*.xml");

                foreach (FileInfo file in files)
                {
                    Language l = Language.Load(file.FullName, true);
                    languages.Add(l);
                }
            }

            return languages;
        }

        #endregion

    }

    #region Class Language

    public class Language
    {

        #region Public variables

        public string Name { get; set; }
        public string InternationalName { get; set; }
        public string Culture { get; set; }
        public string AppVersion { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }

        public LanguageMenu Menu = new LanguageMenu();
        public LanguageMessageBox MessageBox = new LanguageMessageBox();
        public Dictionary<string, string> Form = new Dictionary<string, string>();

        #endregion

        #region Load - path, headerOnly

        public static Language Load(string path, bool headerOnly)
        {
            Stream srm = File.OpenRead(path);
            Language l = Language.Load(srm, headerOnly);
            srm.Close(); srm.Dispose(); srm = null;
            return l;
        }

        #endregion

        #region Load - stream, headerOnly

        public static Language Load(Stream stream, bool headerOnly)
        {
            Language l = new Language();

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(stream);

            XmlNode xnlang = xdoc.SelectSingleNode("ghostscriptstudio/language");
            l.Name = xnlang.Attributes["name"].Value;
            l.InternationalName = xnlang.Attributes["international_name"].Value;
            l.Culture = xnlang.Attributes["culture"].Value;
            l.AppVersion = xnlang.Attributes["app_version"].Value;
            l.AuthorName = xnlang.Attributes["author_name"].Value;
            l.AuthorEmail = xnlang.Attributes["author_email"].Value;

            if (!headerOnly)
            {
                XmlNode xnmenu = xnlang.SelectSingleNode("menu");
                XmlNodeList xnitems = xnmenu.SelectNodes("entries/item");

                foreach (XmlNode xn in xnitems)
                {
                    l.Menu.Entries.Add(xn.Attributes["id"].Value, xn.Attributes["value"].Value);
                }

                xnitems = xnmenu.SelectNodes("subentries/item");

                foreach (XmlNode xn in xnitems)
                {
                    l.Menu.SubEntries.Add(xn.Attributes["id"].Value, xn.Attributes["value"].Value);
                }

                xnitems = xnmenu.SelectNodes("commands/item");

                foreach (XmlNode xn in xnitems)
                {
                    l.Menu.Commands.Add(xn.Attributes["id"].Value, xn.Attributes["value"].Value);
                }

                XmlNode xnmsgbox = xnlang.SelectSingleNode("messagebox");

                l.MessageBox.Ok = xnmsgbox.Attributes["ok"].Value;
                l.MessageBox.Yes = xnmsgbox.Attributes["yes"].Value;
                l.MessageBox.No  = xnmsgbox.Attributes["no"].Value;
                l.MessageBox.Cancel = xnmsgbox.Attributes["cancel"].Value;
                l.MessageBox.Ignore = xnmsgbox.Attributes["ignore"].Value;
                l.MessageBox.Retry = xnmsgbox.Attributes["retry"].Value;
                l.MessageBox.Abort = xnmsgbox.Attributes["abort"].Value;

                xnitems = xnmsgbox.SelectNodes("item");

                foreach (XmlNode xn in xnitems)
                {
                    l.MessageBox.Items.Add(xn.Attributes["id"].Value, new LanguageMessageBoxItem() { Title = xn.Attributes["title"].Value, Message = xn.Attributes["message"].Value });
                }

                xnitems = xnlang.SelectNodes("form/item");

                foreach (XmlNode xn in xnitems)
                {
                    l.Form.Add(xn.Attributes["id"].Value, xn.Attributes["value"].Value);
                }
                
            }

            xdoc = null;

            return l;
        }

        #endregion

    }

    #endregion

    #region Class LanguageMenu

    public class LanguageMenu
    {
        public Dictionary<string, string> Entries = new Dictionary<string, string>();
        public Dictionary<string, string> SubEntries = new Dictionary<string, string>();
        public Dictionary<string, string> Commands = new Dictionary<string, string>();
    }

    #endregion

    #region Class LanguageMessageBoxItem

    public class LanguageMessageBoxItem
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }

    #endregion

    #region Class LanguageMessageBox

    public class LanguageMessageBox
    {
        public string Ok { get; set; }
        public string Cancel { get; set; }
        public string Ignore { get; set; }
        public string Retry { get; set; }
        public string Yes { get; set; }
        public string No { get; set; }
        public string Abort { get; set; }

        public Dictionary<string, LanguageMessageBoxItem> Items = new Dictionary<string, LanguageMessageBoxItem>();
    }

    #endregion

}
