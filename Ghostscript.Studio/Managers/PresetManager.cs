#region This file is part of Ghostscript.Studio application
//
// PresetManager.cs
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

namespace Ghostscript.Studio
{
    public class PresetManager
    {

        #region GetPresets

        public static List<PresetFile> GetPresets(PresetType type)
        {
            string presetsPath = GetPresetsPath(type);
            string presetsFilter = "*" + GetPresetExtension(type);

            IOHelper.EnsureDirectory(presetsPath);

            string[] files = Directory.GetFiles(presetsPath, presetsFilter);

            List<PresetFile> presetFiles = new List<PresetFile>();

            foreach (string file in files)
            {
                presetFiles.Add(new PresetFile(file));
            }

            return presetFiles;
        }

        #endregion

        #region GetPresetsPath

        public static string GetPresetsPath(PresetType type)
        {
            switch (type)
            {
                case PresetType.GhostscriptProcessorSwitches:
                    return Program.MapDataPath("switchespresets");
                case PresetType.GhostscriptProcessorPostScript:
                    return Program.MapDataPath("postscriptpresets");
            }

            return string.Empty;
        }

        #endregion

        #region GetPresetExtension

        public static string GetPresetExtension(PresetType type)
        {
            switch (type)
            {
                case PresetType.GhostscriptProcessorSwitches:
                    return ".gssp";
                case PresetType.GhostscriptProcessorPostScript:
                    return ".gspp";
            }

            return string.Empty;
        }

        #endregion

    }
}
