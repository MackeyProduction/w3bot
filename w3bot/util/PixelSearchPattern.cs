using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.util
{
    public struct PixelSearchPattern
    {
        internal PixelSearchPattern(byte r = 0, byte g = 0, byte b = 0, byte tolerance = 255)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.tolerance = tolerance;
        }
        public byte R, G, B;
        public byte tolerance;
    }
}
