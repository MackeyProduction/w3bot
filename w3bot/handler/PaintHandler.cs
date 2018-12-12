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
