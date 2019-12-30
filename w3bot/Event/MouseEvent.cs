using w3bot.Listener;
using w3bot.Script;

namespace w3bot.Event
{
    public class MouseEvent : IEventListener
    {
        private IScript _script;

        public MouseEvent(IScript script)
        {
            _script = script;
        }

        public void Apply()
        {
            if (_script is IMouseEventListener)
            {
                
            }
        }

        public void Destroy()
        {
            if (_script is IMouseEventListener)
            {

            }
        }
    }
}
