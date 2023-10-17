using System;
using System.IO;

namespace Ghostscript.Studio.IO
{
    public class StreamScanner
    {
        private Stream _stream;

        public StreamScanner(Stream stream)
        {
            _stream = stream;
        }

        public int Read()
        {
            return _stream.ReadByte();
        }

        public int ReadIfNext(int c)
        {
            if (this.PeekNext(1) == c)
            {
                return this.Read();
            }
            else
            {
                return -1;
            }
        }

        public void GoForward(int offset)
        {
            _stream.Seek(offset, SeekOrigin.Current);
        }

        public void GoBack(int offset)
        {
            _stream.Seek(-offset, SeekOrigin.Current);
        }

        public int PeekNext(int offset)
        {
            int c = _stream.ReadByte();
            _stream.Seek(offset, SeekOrigin.Current);
            return c;
        }

        public int PeekPrevious(int offset)
        {
            _stream.Seek(-offset, SeekOrigin.Current);
            return _stream.ReadByte();
        }

        public int Position
        {
            get { return (int)_stream.Position; }
        }
    }
}
