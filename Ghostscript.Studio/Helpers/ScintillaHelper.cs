#region This file is part of Ghostscript.Studio application
//
// ScintillaHelper.cs
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
using System.Windows.Forms;
using System.Drawing;
using ScintillaNET;

namespace Ghostscript.Studio
{
    public class ScintillaHelper
    {

        #region SetScrollWidthTracking

        public static void SetScrollWidthTracking(Scintilla scintilla)
        {
            const uint SCI_SETSCROLLWIDTHTRACKING = 2516;

            scintilla.NativeInterface.SendMessageDirect(Constants.SCI_SETSCROLLWIDTH, 1);
            scintilla.NativeInterface.SendMessageDirect(SCI_SETSCROLLWIDTHTRACKING, true);
        }

        #endregion

        #region SetFont

        public static void SetFont(Scintilla scintilla, System.Drawing.Font font)
        {
            scintilla.Font = font;

            scintilla.Styles.Default.Font = font;

            scintilla.Styles[0].Font = font;               //white space
            scintilla.Styles[1].Font = font;               //comments-block
            scintilla.Styles[2].Font = font;               //comments-singlechar
            scintilla.Styles[3].Font = font;               //half-formed comment
            scintilla.Styles[4].Font = font;               //numbers
            scintilla.Styles[5].Font = font;               //keyword after complete
            scintilla.Styles[6].Font = font;               //quoted text-double
            scintilla.Styles[7].Font = font;               //quoted text-single
            scintilla.Styles[8].Font = font;               //"table" keyword l
            scintilla.Styles[9].Font = font;               //? knows
            scintilla.Styles[10].Font = font;              //symbol (<>);=-
            scintilla.Styles[11].Font = font;              //half-formed words
            scintilla.Styles[12].Font = font;              //mixed quoted text 'text"  ?strange
            scintilla.Styles[14].Font = font;              //sql-type keyword (still looks weird)
            scintilla.Styles[15].Font = font;              //sql @symbol in a comment 
            scintilla.Styles[16].Font = font;              //sql function returning INT
            scintilla.Styles[19].Font = font;              //in/out
            scintilla.Styles[32].Font = font;              //plain ordinary whitespace, that exists everywhere

            scintilla.Styles[StylesCommon.LineNumber].Font = font;
            scintilla.Styles[StylesCommon.BraceBad].Font = font;
            scintilla.Styles[StylesCommon.BraceLight].Font = font;
            scintilla.Styles[StylesCommon.CallTip].Font = font;
            scintilla.Styles[StylesCommon.ControlChar].Font = font;
            scintilla.Styles[StylesCommon.Default].Font = font;
            scintilla.Styles[StylesCommon.IndentGuide].Font = font;
            scintilla.Styles[StylesCommon.LastPredefined].Font = font;
            scintilla.Styles[StylesCommon.Max].Font = font;
        }

        #endregion

    }
}
