#region This file is part of Ghostscript.Studio application
//
// XmlHelper.cs
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
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Ghostscript.Studio
{
    public class XmlHelper
    {

        #region SaveAsXml

        public static void SaveToXmlFile(object instance, string path)
        {
            XmlSerializer xs = new XmlSerializer(instance.GetType());
            XmlSerializerNamespaces xn = new XmlSerializerNamespaces();
            xn.Add(string.Empty, string.Empty);

            XmlWriterSettings xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            using (XmlWriter writer = XmlWriter.Create(fs, xmlSettings))
            {
                xs.Serialize(writer, instance, xn);
            }
        }

        #endregion

        #region CreateFromXml

        public static object CreateFromXmlFile(string path, Type objectType)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            XmlSerializer xs = new XmlSerializer(objectType);

            object instance = null;

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                instance = xs.Deserialize(fs);
            }

            return instance;
        }

        #endregion

    }
}
