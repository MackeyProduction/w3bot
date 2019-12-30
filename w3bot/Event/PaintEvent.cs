using w3bot.Listener;
using w3bot.Script;

namespace w3bot.Event
{
    public class PaintEvent : IEventListener
    {
        private Bot _bot;
        private IScript _script;

        public PaintEvent(Bot bot, IScript script)
        {
            _bot = bot;
            _script = script;
        }

        public void Apply()
        {
            if (_script is IPaintListener)
            {
                Bot.paintings += ((IPaintListener)_script).OnPaint;
            }
        }

        public void Destroy()
        {
            if (_script is IPaintListener)
            {
                Bot.paintings -= ((IPaintListener)_script).OnPaint;
            }
        }
    }
}
