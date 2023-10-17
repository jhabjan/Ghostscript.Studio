#region This file is part of Ghostscript.Studio application
//
// CDATA.cs
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
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Ghostscript.Studio
{
    /// <summary>
    /// Class used for a string xml serialization. 
    /// This class will wrap a string value with a CDATA section.
    /// </summary>
    [Serializable]
    public class CDATA : IXmlSerializable
    {
        #region Private variables

        private string _text;

        #endregion

        #region Constructor

        public CDATA() { }

        #endregion

        #region Constructor - text

        public CDATA(string text)
        {
            _text = text;
        }

        #endregion

        #region Text

        public string Text
        {
            get { return _text; }
        }

        #endregion

        #region GetSchema

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        #endregion

        #region ReadXml

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            _text = reader.ReadElementString();
        }

        #endregion

        #region WriteXml

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteCData(_text);
        }

        #endregion

        #region Implicit CDATA operator

        public static implicit operator CDATA(string value)
        {
            return new CDATA(value);
        }

        #endregion

        #region Implicit String operator

        public static implicit operator string(CDATA value)
        {
            if (value == null)
                return string.Empty;

            return value.Text;
        }

        #endregion

        #region CDATA + CDATA operator

        public static CDATA operator + (CDATA first, CDATA second)
        {
            return new CDATA(first.Text + second.Text);
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return _text;
        }

        #endregion
    }
}
