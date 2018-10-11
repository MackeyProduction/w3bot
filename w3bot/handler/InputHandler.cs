using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.bot;
using w3bot.interfaces;
using w3bot.listener;

namespace w3bot.handler
{
    public class InputHandler : IEventHandler
    {
        private Bot _bot;
        private IScript _script;

        public InputHandler(Bot bot, IScript script)
        {
            _bot = bot;
            _script = script;
        }

        public void Apply()
        {
            if (_script is IMouseEventListener)
            {
                // TODO
            }

            if (_script is IKeyPressListener)
            {
                // TODO
            }
        }
    }
}
