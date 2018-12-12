using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Enumeration
{
    public class Keys
    {
        public enum Button : int
        {
            NOBUTTON = 0,
            LEFT = 1,
            MIDDLE = 2,
            RIGHT = 3
        }

        public enum Event : int
        {
            NULL = -1,
            DOWN = 0,
            UP = 1,
            DOWNUP = 2,
        }

        public enum Wheel : int
        {
            UP = 0,
            DOWN = 1,
            LEFT = 2,
            RIGHT = 3
        }
    }
}
