using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.wrapper;

namespace w3bot.core
{
    internal struct CoreSettings
    {
        internal BrowserAdapter browserAdapter { get; set; }
        internal InputAdapter inputAdapter { get; set; }

        internal CoreSettings(BrowserAdapter browserAdapter, InputAdapter inputAdapter)
        {
            this.browserAdapter = browserAdapter;
            this.inputAdapter = inputAdapter;
        }
    }
}
