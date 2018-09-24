using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.bot;
using w3bot.evt;
using w3bot.interfaces;

namespace w3bot.core
{
    internal class BotStub
    {
        private Action _scriptStopped;
        private static BotStub _botStub;
        internal IScript _script;
        internal Thread _scriptThread, _drawThread;
        internal bool _running, _pausing;
        private Bot _bot;

        internal BotStub(Bot bot, IScript script, Action scriptStoppedCallback)
        {
            _bot = bot;
            _botStub = this;
            _script = script;
            _scriptStopped = scriptStoppedCallback;

            // Process
            try
            {
                _botStub.onStart();
                _botStub.onUpdate();
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

            // script thread
            _scriptThread = new Thread(new ThreadStart(delegate
            {
                if (_script.onStart())
                {
                    while (_running)
                    {
                        delay = _script.onUpdate();

                        while (_pausing)
                            Thread.Sleep(100);

                        if (delay < 1)
                            _botStub.onFinish();

                        Thread.Sleep(delay);
                    }
                }
                _bot.core.mainWindow.Invoke((MethodInvoker)delegate { _scriptStopped(); }); //let upper instances know that the script is now stopped
            }));

            // paint thread
            _drawThread = new Thread(new ThreadStart(delegate
            {
                while (_running)
                {
                    //_bot.core.Invalidate(); // main processor have to repaint the paint
                    Thread.Sleep(65);
                }
            }));

            // start threads
            _scriptThread.Start();
            _drawThread.Start();
        }

        internal void onPause()
        {
            _pausing = true;
        }

        internal void onResume()
        {
            _pausing = false;
        }

        internal void onKill()
        {
            _scriptThread.Abort();
            _drawThread.Abort();
        }
    }
}
