using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Bot;
using w3bot.Interfaces;
using w3bot.Listener;

namespace w3bot.Handler
{
    public class InputHandler : IEventHandler
    {
        private Bot.Bot _bot;
        private IScript _script;

        public InputHandler(Bot.Bot bot, IScript script)
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

        public void Destroy()
        {
            
        }
    }
}
