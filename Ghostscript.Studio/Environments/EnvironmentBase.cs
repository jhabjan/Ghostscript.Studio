﻿#region This file is part of Ghostscript.Studio application
//
// EnvironmentBase.cs
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
using Ghostscript.Studio.Commands;

namespace Ghostscript.Studio.Environments
{
    public abstract class EnvironmentBase
    {
        #region Private variables

        private Dictionary<Command, CommandEventHandler> _subscribedCommands = new Dictionary<Command, CommandEventHandler>();

        #endregion

        #region SubscribeToCommand

        public void SubscribeToCommand(Command command, CommandEventHandler dispatchTo)
        {
            _subscribedCommands.Add(command, dispatchTo);
        }

        #endregion

        #region SubscribedCommands

        public Dictionary<Command, CommandEventHandler> SubscribedCommands
        {
            get { return _subscribedCommands; }
        }

        #endregion

    }
}
