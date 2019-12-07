using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Wrapper
{
    internal struct InputAdapter
    {
        internal MouseAdapter mouseAdapter;
        internal KeyboardAdapter keyboardAdapter;

        [Obsolete("The class will soon be deprecated. Use the input classes instead.")]
        internal InputAdapter(MouseAdapter mouseAdapter, KeyboardAdapter keyboardAdapter)
        {
            this.mouseAdapter = mouseAdapter;
            this.keyboardAdapter = keyboardAdapter;
        }
    }
}
