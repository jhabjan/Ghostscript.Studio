#region This file is part of Ghostscript.Studio application
//
// PresetFile.cs
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

namespace Ghostscript.Studio
{
    public class PresetFile
    {

        #region Private variables

        private string _path;

        #endregion

        #region Constructor

        public PresetFile() { }

        #endregion
        
        #region Constructor - path

        public PresetFile(string path)
        {
            _path = path;
        }

        #endregion

        #region Read

        public Preset Read()
        {
            return Preset.Open(_path);
        }

        #endregion

        #region Name

        public string Name
        {
            get { return Path.GetFileNameWithoutExtension(_path); }
        }

        #endregion

        #region FileName

        public string FileName
        {
            get { return _path; }
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return this.Name;
        }

        #endregion

        #region Replace

        public void Replace(Preset preset)
        {
            this.Delete();

            string newPresetPath = Path.Combine(PresetManager.GetPresetsPath(preset.Type), preset.Name + PresetManager.GetPresetExtension(preset.Type));
            
            Preset.Save(preset, newPresetPath);
            
            _path = newPresetPath;
        }

        #endregion

        #region Save

        public void Save(Preset preset)
        {
            string presetPath = Path.Combine(PresetManager.GetPresetsPath(preset.Type), preset.Name + PresetManager.GetPresetExtension(preset.Type));

            Preset.Save(preset, presetPath);

            _path = presetPath;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }

            _path = string.Empty;
        }

        #endregion

    }
}
