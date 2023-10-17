#region This file is part of Ghostscript.Studio application
//
// PSToken.cs
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

namespace Ghostscript.Studio.Workspaces.Editor.Debugger
{

    #region enum PSTokenType

    public enum PSTokenType
    {
        None = 0,
        ArrayOpen,                      // [
        ArrayClose,                     // ]
        DictionaryOpen,                 // <<
        DictionaryClose,                // >>
        ProcedureOpen,                  // {
        ProcedureClose,                 // }
        ASCIIBase85StringOpen,          // <~
        ASCIIBase85StringClose,         // ~>
        Comment,                        // %
        LiteralTextString,              // 
        HexadecimalString,              // < >
        NumberOrExecutableName,         // 
        LiteralName,                    // /
        ImmediatelyEvaluatedName        // //
    }

    #endregion

    public class PSToken
    {
        #region Common static tokens

        public static PSToken ArrayOpen = new PSToken(PSTokenType.ArrayOpen, "[");
        public static PSToken ArrayClose = new PSToken(PSTokenType.ArrayClose, "]");
        public static PSToken DictionaryOpen = new PSToken(PSTokenType.DictionaryOpen, "<<");
        public static PSToken DictionaryClose = new PSToken(PSTokenType.DictionaryClose, ">>");
        public static PSToken ProcedureOpen = new PSToken(PSTokenType.ProcedureOpen, "{");
        public static PSToken ProcedureClose = new PSToken(PSTokenType.ProcedureClose, "}");
        public static PSToken ASCIIBase85StringOpen = new PSToken(PSTokenType.ASCIIBase85StringOpen, "<~");
        public static PSToken ASCIIBase85StringClose = new PSToken(PSTokenType.ASCIIBase85StringClose, "~>");
        public static PSToken Comment = new PSToken(PSTokenType.Comment);
        public static PSToken NumberOrExecutableName = new PSToken(PSTokenType.NumberOrExecutableName);
        public static PSToken LiteralTextString = new PSToken(PSTokenType.LiteralTextString);
        public static PSToken LiteralName = new PSToken(PSTokenType.LiteralName);
        public static PSToken ImmediatelyEvaluatedName = new PSToken(PSTokenType.ImmediatelyEvaluatedName);

        #endregion

        #region Private variables

        private PSTokenType _type = PSTokenType.None;
        private string _value = string.Empty;
        private int _startPosition;
        private int _endPosition;

        #endregion

        #region Constructor - type

        public PSToken(PSTokenType type)
        {
            _type = type;
        }

        #endregion

        #region Constructor - type, value

        public PSToken(PSTokenType type, string value)
        {
            _type = type;
            _value = value;
        }

        #endregion

        #region Constructor - type, value

        public PSToken(PSTokenType type, string value, int startPosition, int endPosition)
        {
            _type = type;
            _value = value;
            _startPosition = startPosition;
            _endPosition = endPosition;
        }

        #endregion

        #region Type

        public PSTokenType Type
        {
            get { return _type; }
        }

        #endregion

        #region Value

        public string Value
        {
            get { return _value; }
        }

        #endregion

        #region StartPosition

        public int StartPosition
        {
            get { return _startPosition; }
        }

        #endregion

        #region EndPosition

        public int EndPosition
        {
            get { return _endPosition; }
        }

        #endregion

        #region Equals

        public override bool Equals(object obj)
        {
            PSToken token = obj as PSToken;

            if (token == null)
            {
                return false;
            }

            if (token._type == _type)
            {
                if (token.Value == _value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region GetHashCode

        public override int GetHashCode()
        {
            return _type.GetHashCode() ^ _value.GetHashCode();
        }

        #endregion

        #region == operator

        public static bool operator == (PSToken left, PSToken right)
        {
            if (Object.ReferenceEquals(left, right))
            {
                return true;
            }

            if (right == null)
            {
                return false;
            }

            return left._type == right._type;
        }

        #endregion

        #region != operator

        public static bool operator != (PSToken left, PSToken right)
        {
            return !(left == right);
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return _type.ToString() + ": " + _value;
        }

        #endregion

    }
}
