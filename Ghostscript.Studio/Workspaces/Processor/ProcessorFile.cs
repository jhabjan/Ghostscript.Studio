#region This file is part of Ghostscript.Studio application
//
// ProcessorFile.cs
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
using System.Xml;
using System.Xml.Serialization;

namespace Ghostscript.Studio.Workspaces.Processor
{
    [Serializable]
    [XmlRoot("GhostscriptStudioProcessor")]
    public class ProcessorFile
    {

        #region Constructor

        public ProcessorFile()
        {
            InputFiles = new List<CDATA>();
        }

        #endregion

        #region Properties

        public CDATA Text { get; set; }
        public CDATA PostScript { get; set; }
        [XmlArrayItem("File")]
        public List<CDATA> InputFiles { get; set; }
        public CDATA OutputPath { get; set; }
        public CDATA OutputFilenameFormat { get; set; }

        #endregion

        #region Open

        public static ProcessorFile Open(string path)
        {
            ProcessorFile pf = XmlHelper.CreateFromXmlFile(path, typeof(ProcessorFile)) as ProcessorFile;
            return pf;
        }

        #endregion

        #region Save

        public static void Save(object instance, string path)
        {
            XmlHelper.SaveToXmlFile(instance, path);
        }

        #endregion
    }
}
