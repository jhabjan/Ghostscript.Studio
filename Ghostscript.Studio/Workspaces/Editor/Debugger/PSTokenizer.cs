#region This file is part of Ghostscript.Studio application
//
// PSTokenizer.cs
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
using System.Text;
using Ghostscript.Studio.IO;

namespace Ghostscript.Studio.Workspaces.Editor.Debugger
{
    public class PSTokenizer
    {

        #region Private constants

        private const int CHAR_NULL = 0x0;                          // \0
        private const int CHAR_TAB = 0x09;                          // \t
        private const int CHAR_LINE_FEED = 0x0A;                    // \n
        private const int CHAR_FORM_FEED = 0x0C;                    // \f
        private const int CHAR_CARRIAGE_RETURN = 0x0D;              // \r
        private const int CHAR_WHITE_SPACE = 0x20;                  // " "

        private const int CHAR_OPEN_PARENTHESIS_BRACKET = 0x28;     // (
        private const int CHAR_CLOSE_PARENTHESIS_BRACKET = 0x29;    // )
        private const int CHAR_OPEN_ANGLED_BRACKET = 0x3C;          // <
        private const int CHAR_CLOSE_ANGLED_BRACKET = 0x3E;         // >
        private const int CHAR_OPEN_SQUARE_BRACKET = 0x5B;          // [
        private const int CHAR_CLOSE_SQUARE_BRACKET = 0x5D;         // ]
        private const int CHAR_OPEN_CURLY_BRACKET = 0x7B;           // {
        private const int CHAR_CLOSE_CURLY_BRACKET = 0x7D;          // }

        private const int CHAR_SLASH = 0x2F;                        // /
        private const int CHAR_BACKSLASH = 0x5C;                    // \
        private const int CHAR_PERCENT_SIGN = 0x25;                 // %
        private const int CHAR_TILDE = 0x7E;                        // ~

        #endregion

        #region Private variables

        private StreamScanner _scanner = null;

        #endregion

        #region Constructor

        public PSTokenizer(Stream stream)
        {
            _scanner = new StreamScanner(stream);
        }

        #endregion

        #region NextToken

        public PSToken NextToken()
        {
            while (true)
            {
                int c = _scanner.Read();

                switch (c)
                {
                    case CHAR_TAB:
                    case CHAR_LINE_FEED:
                    case CHAR_FORM_FEED:
                    case CHAR_CARRIAGE_RETURN:
                    case CHAR_WHITE_SPACE:
                        {
                            break;
                        }
                    case -1:
                        {
                            return null;
                        }
                    case CHAR_PERCENT_SIGN:
                        {
                            return this.ReadComment();
                        }
                    case CHAR_SLASH:
                        {
                            return this.ReadLiteralName();
                        }
                    case CHAR_OPEN_CURLY_BRACKET:
                        {
                            return PSToken.ProcedureOpen;
                        }
                    case CHAR_CLOSE_CURLY_BRACKET:
                        {
                            return PSToken.ProcedureClose;
                        }
                    case CHAR_OPEN_SQUARE_BRACKET:
                        {
                            return PSToken.ArrayOpen;
                        }
                    case CHAR_CLOSE_SQUARE_BRACKET:
                        {
                            return PSToken.ArrayClose;
                        }
                    case CHAR_OPEN_PARENTHESIS_BRACKET:
                        {
                            return this.ReadLiteralTextString();
                        }
                    case CHAR_OPEN_ANGLED_BRACKET:
                        {
                            return this.ReadHexadecimalString();
                        }
                    default:
                        {
                            return this.ReadNumberOrExecutableName();
                        }
                }
            }
        }

        #endregion

        #region ReadComment

        private PSToken ReadComment()
        {
            _scanner.GoBack(1);

            int startPosition = _scanner.Position;

            int c;

            StringBuilder value = new StringBuilder();

            while ((c = _scanner.Read()) > -1)
            {
                if (this.IsCrOrLf(c))
                {
                    return new PSToken(PSTokenType.Comment, value.ToString(), startPosition, _scanner.Position - 1);
                }
                else
                {
                    value.Append((char)c);
                }
            }

            return null;
        }

        #endregion

        #region ReadLiteralName

        private PSToken ReadLiteralName()
        {
            int c;

            int startPosition = _scanner.Position;

            StringBuilder value = new StringBuilder("/");

            while ((c = _scanner.Read()) > -1)
            {
                if (this.IsDelimiterOrWhiteSpaceCharacter(c))
                {
                    _scanner.GoBack(1);
                    return new PSToken(PSTokenType.LiteralName, value.ToString(), startPosition, _scanner.Position - 1);
                }
                else
                {
                    value.Append((char)c);
                }
            }

            return null;
        }

        #endregion

        #region ReadNumberOrExecutableName

        private PSToken ReadNumberOrExecutableName()
        {
            _scanner.GoBack(1);

            int startPosition = _scanner.Position;

            int c;

            StringBuilder value = new StringBuilder();

            while ((c = _scanner.Read()) > -1)
            {
                if (this.IsDelimiterOrWhiteSpaceCharacter(c))
                {
                    _scanner.GoBack(1);
                    return new PSToken(PSTokenType.NumberOrExecutableName, value.ToString(), startPosition, _scanner.Position - 1);
                }
                else
                {
                    value.Append((char)c);
                }
            }

            return null;
        }

        #endregion

        #region ReadLiteralTextString

        private PSToken ReadLiteralTextString()
        {
            int parenthesisMatch = 1;
            bool backslashPrefix = false;
            int startPosition = _scanner.Position;

            int c;

            StringBuilder value = new StringBuilder();

            while ((c = _scanner.Read()) > -1)
            {
                switch (c)
                {
                    case CHAR_OPEN_PARENTHESIS_BRACKET:
                        {
                            parenthesisMatch++;
                            break;
                        }
                    case CHAR_CLOSE_PARENTHESIS_BRACKET:
                        {
                            parenthesisMatch--;
                            break;
                        }
                    case CHAR_BACKSLASH:
                        {
                            backslashPrefix = false;

                            int e  = _scanner.Read();

                            switch (e)
                            {
                                case CHAR_CARRIAGE_RETURN:
                                case CHAR_LINE_FEED:
                                    {
                                        if (c == CHAR_CARRIAGE_RETURN)
                                        {
                                            _scanner.GoForward(2);
                                        }

                                        c = 0;
                                        break;
                                    }
                                case 't':
                                    {
                                        c = CHAR_TAB;
                                        break;
                                    }
                                case  'n':
                                    {
                                        c = CHAR_LINE_FEED;
                                        break;
                                    }
                                case 'f':
                                    {
                                        c = CHAR_FORM_FEED;
                                        break;
                                    }
                                case 'r':
                                    {
                                        c = CHAR_CARRIAGE_RETURN;
                                        break;
                                    }
                                case CHAR_BACKSLASH:
                                    {
                                        c = CHAR_BACKSLASH;
                                        break;
                                    }
                                default:
                                    {
                                        backslashPrefix = true;
                                        c = e;
                                        break;
                                    }
                            }

                            break;
                        }
                    case CHAR_CARRIAGE_RETURN:
                    case CHAR_LINE_FEED:
                        {
                            if (c == CHAR_CARRIAGE_RETURN)
                            {
                                _scanner.GoForward(1);
                            }

                            if (backslashPrefix)
                            {
                                c = 0;
                            }

                            backslashPrefix = false;

                            break;
                        }
                }

                if (parenthesisMatch != 0)
                {
                    if (c > 0)
                    {
                        value.Append((char)c);
                    }
                    else if (c < 0)
                    {
                        throw new Exception("Invalid escape character");
                    }
                }
                else
                {
                    return new PSToken(PSTokenType.LiteralTextString, "(" + value.ToString().Trim('\r', '\n') + ")", startPosition, _scanner.Position - 1);
                }
            }

            return null;
        }

        #endregion

        #region ReadHexadecimalString

        private PSToken ReadHexadecimalString()
        {
            int c;

            int startPosition = _scanner.Position;

            StringBuilder value = new StringBuilder();

            while ((c = _scanner.Read()) > -1)
            {
                if (c == CHAR_CLOSE_ANGLED_BRACKET)
                {
                    return new PSToken(PSTokenType.HexadecimalString, value.ToString().Trim('\r', '\n'), startPosition, _scanner.Position - 1);
                }
                else
                {
                    value.Append((char)c);
                }
            }

            return null;
        }

        #endregion

        #region IsWhiteSpaceCharacter

        private bool IsWhiteSpaceCharacter(int c)
        {
            return c == CHAR_NULL || 
                   c == CHAR_TAB || 
                   c == CHAR_LINE_FEED || 
                   c == CHAR_FORM_FEED || 
                   c == CHAR_CARRIAGE_RETURN || 
                   c == CHAR_WHITE_SPACE;
        }

        #endregion

        #region IsDelimiter

        public bool IsDelimiter(int c)
        {
            return c == CHAR_OPEN_PARENTHESIS_BRACKET ||
                   c == CHAR_CLOSE_PARENTHESIS_BRACKET ||
                   c == CHAR_OPEN_ANGLED_BRACKET ||
                   c == CHAR_CLOSE_ANGLED_BRACKET ||
                   c == CHAR_OPEN_SQUARE_BRACKET ||
                   c == CHAR_CLOSE_SQUARE_BRACKET ||
                   c == CHAR_OPEN_CURLY_BRACKET ||
                   c == CHAR_CLOSE_CURLY_BRACKET || 
                   c == CHAR_SLASH;
        }

        #endregion

        #region IsDelimiterOrWhiteSpaceCharacter

        private bool IsDelimiterOrWhiteSpaceCharacter(int c)
        {
            return this.IsWhiteSpaceCharacter(c) || this.IsDelimiter(c);
        }

        #endregion

        #region IsCrOrLf

        public bool IsCrOrLf(int c)
        {
            return c == CHAR_LINE_FEED || c == CHAR_CARRIAGE_RETURN;
        }

        #endregion

    }
}
