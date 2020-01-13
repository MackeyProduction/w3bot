using w3bot.Listener;
using w3bot.Script;

namespace w3bot.Event
{
    public class PaintEvent : IEventListener
    {
        private IScript _script;

        public PaintEvent(IScript script)
        {
            _script = script;
        }

        public void Update(IEventManager manager)
        {
            if (_script is IPaintListener)
            {
                Bot.paintings += ((IPaintListener)_script).OnPaint;
            }
        }
    }
}
