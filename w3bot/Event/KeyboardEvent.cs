using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Listener;
using w3bot.Script;

namespace w3bot.Event
{
    public class KeyboardEvent : IEventListener
    {
        private IScript _script;

        public KeyboardEvent(IScript script)
        {
            _script = script;
        }

        public void Apply()
        {
            if (_script is IKeyPressListener)
            {

            }
        }

        public void Destroy()
        {
            if (_script is IKeyPressListener)
            {

            }
        }
    }
}
