using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Wrapper;

namespace w3bot.Core.Bot
{
    internal struct BotSettings
    {
        internal BrowserAdapter browserAdapter { get; set; }
        internal InputAdapter inputAdapter { get; set; }

        internal BotSettings(BrowserAdapter browserAdapter, InputAdapter inputAdapter)
        {
            this.browserAdapter = browserAdapter;
            this.inputAdapter = inputAdapter;
        }
    }
}
