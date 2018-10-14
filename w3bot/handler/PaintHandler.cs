using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.bot;
using w3bot.interfaces;
using w3bot.listener;

namespace w3bot.handler
{
    public class PaintHandler : IEventHandler
    {
        private Bot _bot;
        private IScript _script;

        public PaintHandler(Bot bot, IScript script)
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
