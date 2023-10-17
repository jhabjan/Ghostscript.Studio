using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ghostscript.Studio.Helpers
{
    internal class BufferHelper
    {
        public static string ToHex(byte[] buffer)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in buffer)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
