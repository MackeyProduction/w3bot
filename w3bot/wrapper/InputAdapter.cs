using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.wrapper
{
    internal struct InputAdapter
    {
        internal MouseAdapter mouseAdapter;
        internal KeyboardAdapter keyboardAdapter;

        internal InputAdapter(MouseAdapter mouseAdapter, KeyboardAdapter keyboardAdapter)
        {
            this.mouseAdapter = mouseAdapter;
            this.keyboardAdapter = keyboardAdapter;
        }
    }
}
