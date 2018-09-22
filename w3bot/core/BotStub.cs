using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using w3bot.bot;
using w3bot.evt;
using w3bot.interfaces;

namespace w3bot.core
{
    internal class BotStub
    {
        private static BotStub _botStub;
        private static IScript _script;
        private static Thread _scriptThread;
        private static bool _running;
        private static Bot _bot;

        internal BotStub(Bot bot, IScript script)
        {
            _botStub = this;
            _script = script;

            // Process
            try
            {
                _botStub.onStart();
                _botStub.onUpdate();
                _botStub.onFinish();
            }
            catch (ThreadAbortException)
            { }
            catch (Exception e)
            {
                Status.Warning(e.ToString());
                _botStub.onFinish();
            }
        }

        internal void onFinish()
        {
            _running = false;
        }

        internal void onStart()
        {
            _running = true;
        }

        internal void onUpdate()
        {
            int delay = 100;

            _scriptThread = new Thread(new ThreadStart(delegate
            {
                if (_script.onStart())
                {
                    delay = _script.onUpdate();

                    while (_running)
                    {
                        if (delay < 1)
                            _botStub.onFinish();

                        Thread.Sleep(delay);
                    }
                }
            }));
        }

        internal void onPause()
        {

        }

        internal void onResume()
        {

        }

        internal void onKill()
        {
            _scriptThread.Abort();
        }
    }
}
