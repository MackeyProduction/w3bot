using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Wrapper
{
    class BotBrowserService
    {
        private IBotBrowser _botBrowser;

        public BotBrowserService(IBotBrowser botBrowser)
        {
            _botBrowser = botBrowser;
        }

        public IBotBrowser GetBotBrowser()
        {
            return _botBrowser;
        }
    }
}
