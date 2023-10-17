#region This file is part of Ghostscript.Studio application
//
// GhostscriptProcessorLexer.cs
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
using System.Drawing;
using ScintillaNET;

namespace Ghostscript.Studio.Lexers
{
    public class GhostscriptProcessorLexer
    {

        #region Constants

        private const int EOL = -1;

        private const int DEFAULT_STYLE = 32;
        
        private const int KEY_STYLE = 11;
        private const int VALUE_STYLE = 12;
        private const int ASSIGNMENT_STYLE = 13;
        private const int COMMENT_STYLE = 14;
        private const int QUOTED_STYLE = 15;

        #endregion Constants

        #region Private variables

        private Scintilla _scintilla;
        private int _startPos;

        private int _index;
        private string _text;

        #endregion

        #region Constructor

        private GhostscriptProcessorLexer(Scintilla scintilla, int startPos, int length)
        {
            this._scintilla = scintilla;
            this._startPos = startPos;

            this._text = scintilla.GetRange(startPos, startPos + length).Text;
        }

        #endregion

        #region Init

        public static void Init(Scintilla scintilla)
        {
            scintilla.Indentation.SmartIndentType = SmartIndent.None;
            scintilla.ConfigurationManager.Language = String.Empty;
            scintilla.Lexing.LexerName = "container";
            scintilla.Lexing.Lexer = Lexer.Container;

            scintilla.Styles[QUOTED_STYLE].ForeColor = Color.DarkRed; 
            scintilla.Styles[KEY_STYLE].ForeColor = Color.Blue;
            scintilla.Styles[ASSIGNMENT_STYLE].ForeColor = Color.LightSlateGray;
            scintilla.Styles[VALUE_STYLE].ForeColor = Color.DarkRed;
            scintilla.Styles[COMMENT_STYLE].ForeColor = Color.Green;
            scintilla.Styles[COMMENT_STYLE].Italic = true;
        }

        #endregion

        #region Read

        private int Read()
        {
            if (_index < _text.Length)
                return _text[_index];

            return EOL;
        }

        #endregion

        #region SetStyle

        private void SetStyle(int style, int length)
        {
            if (length > 0)
            {
                ((INativeScintilla)_scintilla).SetStyling(length, style);
            }
        }

        #endregion

        #region Style

        public void Style()
        {
            ((INativeScintilla)_scintilla).StartStyling(_startPos, 0x1F);

            // Run our humble lexer...
            StyleWhitespace();

            switch(Read())
            {             
                case '!':

                    // Comment
                    SetStyle(COMMENT_STYLE, _text.Length - _index);
                    break;
                
                default:

                    // Key, assignment, quote, value, comment
                    StyleUntilMatch(KEY_STYLE, new char[] { '=', '!' });
                    switch (Read())
                    {
                        case '=':

                            // Assignment, quote, value, comment
                            StyleCh(ASSIGNMENT_STYLE);
                            switch (Read())
                            {
                                case '"':

                                    // Quote
                                    StyleCh(QUOTED_STYLE);  // '"'
                                    StyleUntilMatch(QUOTED_STYLE, new char[] { '"' });
                                    
                                    // Make sure it wasn't an escaped quote
                                    if (_index > 0 && _index < _text.Length && _text[_index - 1] == '\\')
                                        goto case '"';

                                    StyleCh(QUOTED_STYLE); // '"'
                                    goto default;

                                default:

                                    // Value, comment
                                    StyleUntilMatch(VALUE_STYLE, new char[] { '!' });
                                    SetStyle(COMMENT_STYLE, _text.Length - _index);
                                    break;
                            }
                            break;

                        default: // '!', EOL

                            // Comment
                            SetStyle(COMMENT_STYLE, _text.Length - _index);
                            break;
                    }
                    break;
            }
        }

        #endregion

        #region StyleCh

        private void StyleCh(int style)
        {
            SetStyle(style, 1);
            _index++;
        }

        #endregion

        #region StyleNeeded

        public static void StyleNeeded(Scintilla scintilla, Range range)
        {
            Line oneLine = range.StartingLine;

            while (oneLine.Length > 0)
            {
                GhostscriptProcessorLexer lexer = new GhostscriptProcessorLexer(scintilla, oneLine.StartPosition, oneLine.Length);
                lexer.Style();
                oneLine = oneLine.Next;
            }
        }

        #endregion

        #region StyleUntilMatch

        private void StyleUntilMatch(int style, char[] chars)
        {
            // Advance until we match a char in the array
            int startIndex = _index;
            while (_index < _text.Length && Array.IndexOf<char>(chars, _text[_index]) < 0)
                _index++;

            if (startIndex != _index)
                SetStyle(style, _index - startIndex);
        }

        #endregion

        #region StyleWhitespace

        private void StyleWhitespace()
        {
            int startIndex = _index;
         
            while (_index < _text.Length && Char.IsWhiteSpace(_text[_index]))
                _index++;

            SetStyle(DEFAULT_STYLE, _index - startIndex);
        }

        #endregion Methods

    }
}
