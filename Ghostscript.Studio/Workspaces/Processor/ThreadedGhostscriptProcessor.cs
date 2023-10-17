#region This file is part of Ghostscript.Studio application
//
// ThreadedGhostscriptProcessor.cs
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
using System.Threading;
using Artifex.Ghostscript.NET;
using Artifex.Ghostscript.NET.Processor;

namespace Ghostscript.Studio.Workspaces.Processor
{
    public class ThreadedGhostscriptProcessor
    {
        #region Private variables

        private string[] _parameters;
        private Thread _thread;
        private GhostscriptProcessor _processor;
        private ProcessorStdIOHandler _stdIoHandler;
        private bool _isRunning = false;
        private bool _isTerminated = false;

        #endregion

        #region Public events

        public event EventHandler ProcessingStarted;
        public event EventHandler ProcessingEnded;
        public event GhostscriptProcessorProcessingEventHandler Processing;
        public event GhostscriptProcessorErrorEventHandler Error;

        #endregion

        #region StartProcessing

        public void StartProcessing(string[] parameters, ProcessorStdIOHandler stdIoHandler)
        {
            if (_processor == null)
            {
                _isTerminated = false;
                _parameters = parameters;
                _stdIoHandler = stdIoHandler;
                _thread = new Thread(new ThreadStart(Process));
                _thread.Start();
            }
        }

        #endregion

        #region StopProcessing

        public void StopProcessing()
        {
            if (_processor != null)
            {
                _isTerminated = true;
                _processor.StopProcessing();
            }
        }

        #endregion

        #region Process

        private void Process()
        {
            try
            {
                _isRunning = true;

                if (ProcessingStarted != null)
                {
                    ProcessingStarted(this, new EventArgs());
                }

                _processor = new GhostscriptProcessor(UIHelper.GetGhostscriptVersionInfoFromOptions(), true);

                if (Processing != null)
                {
                    _processor.Processing += Processing;
                }

                if (Error != null)
                {
                    _processor.Error += Error;
                }

                _processor.StartProcessing(_parameters, _stdIoHandler);
            }
            catch(Exception ex)
            {
                Error(this, new GhostscriptProcessorErrorEventArgs(ex.Message));
            }
            finally
            {
                _isRunning = false;

                if (ProcessingEnded != null)
                {
                    ProcessingEnded(this, new EventArgs());
                }

                _processor = null;
            }
        }

        #endregion

        #region IsRunning

        public bool IsRunning
        {
            get { return _isRunning; }
        }

        #endregion

        #region IsStopping

        public bool IsStopping
        {
            get { return _processor.IsStopping; }
        }

        #endregion

        #region IsTerminated

        public bool IsTerminated
        {
            get
            {
                return _isTerminated;
            }
        }

        #endregion
    }

    #region class ProcessorStdIOHandler

    public class ProcessorStdIOHandler : GhostscriptStdIO
    {
        #region Private variables

        private StdInputEventHandler _input;
        private StdOutputEventHandler _output;
        private StdErrorEventHandler _error;

        #endregion

        #region Constructor

        public ProcessorStdIOHandler(StdInputEventHandler input, StdOutputEventHandler output, StdErrorEventHandler error)
            : base(true, true, true)
        {
            _input = input;
            _output = output;
            _error = error;
        }

        #endregion

        #region StdIn

        public override void StdIn(out string input, int count)
        {
            _input(out input, count);
        }

        #endregion

        #region StdOut

        public override void StdOut(string output)
        {
            _output(output);
        }

        #endregion

        #region StdError

        public override void StdError(string error)
        {
            _error(error);
        }

        #endregion
    }

    #endregion

    #region Public delegates

    public delegate void StdInputEventHandler(out string input, int count);
    public delegate void StdOutputEventHandler(string output);
    public delegate void StdErrorEventHandler(string error);

    #endregion

}
