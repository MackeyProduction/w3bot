using w3bot.Bot;
using w3bot.Listener;
using w3bot.Script;

namespace w3bot.Evt.Handler
{
    public class PaintHandler : IEventHandler
    {
        private Bot.Bot _bot;
        private IScript _script;

        public PaintHandler(Bot.Bot bot, IScript script)
        {
            _bot = bot;
            _script = script;
        }

        public void Apply()
        {
            if (_script is IPaintListener)
            {
                Bot.Bot.paintings += ((IPaintListener)_script).OnPaint;
            }
        }

        public void Destroy()
        {
            if (_script is IPaintListener)
            {
                Bot.Bot.paintings -= ((IPaintListener)_script).OnPaint;
            }
        }
    }
}
