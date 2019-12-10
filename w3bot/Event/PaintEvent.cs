using w3bot.Api;
using w3bot.Listener;
using w3bot.Api;

namespace w3bot.Event
{
    public class PaintEvent : IEventListener
    {
        private Api.Bot _bot;
        private IScript _script;

        public PaintEvent(Api.Bot bot, IScript script)
        {
            _bot = bot;
            _script = script;
        }

        public void Apply()
        {
            if (_script is IPaintListener)
            {
                Api.Bot.paintings += ((IPaintListener)_script).OnPaint;
            }
        }

        public void Destroy()
        {
            if (_script is IPaintListener)
            {
                Api.Bot.paintings -= ((IPaintListener)_script).OnPaint;
            }
        }
    }
}
