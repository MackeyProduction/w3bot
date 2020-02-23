using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Listener;
using w3bot.Script;

namespace w3bot.Event
{
    public class KeyboardEvent : IKeyboardEvent
    {
        public KeyPressEventHandler KeyPress { get; set; }

        public KeyboardEvent()
        {
        }

        protected virtual void OnKeyPress(char keyChar)
        {
            KeyPress?.Invoke(this, new KeyPressEventArgs(keyChar));
        }
    }
}
