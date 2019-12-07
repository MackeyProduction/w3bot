using w3bot.Bot;
using w3bot.Listener;
using w3bot.Script;

namespace w3bot.Event
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
