using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.bot;
using w3bot.core;
using w3bot.enumeration;
using w3bot.interfaces;

namespace w3bot.wrapper
{
    internal class MouseAdapter : IMouseInput
    {
        internal Bot _bot;
        internal MouseAdapter _mouseAdapter;
        internal BotWindow _botWindow;

        internal MouseAdapter(Bot bot)
        {
            _bot = bot;
        }

        public void Click(Keys.Button button, Keys.Event evt)
        {
            
        }

        public void Move(int x, int y)
        {
            
        }

        public void Wheel(Keys.Wheel wheel, int amount)
        {
            
        }
    }
}
