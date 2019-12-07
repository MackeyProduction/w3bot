using System;
using System.Threading;
using System.Windows.Forms;
using w3bot.Bot;
using w3bot.Event;
using w3bot.Input;
using w3bot.Script;
using w3bot.Wrapper;

namespace w3bot.Core.Bot
{
    internal class BotStub
    {
        private Action _scriptStopped;
        private static BotStub _botStub;
        internal IScript _script;
        internal Thread _scriptThread, _drawThread;
        internal bool _running, _pausing;
        private w3bot.Bot.Bot _bot;
        private Event.EventHandler eventHandler;

        internal BotStub(w3bot.Bot.Bot bot, IScript script, Action scriptStoppedCallback)
        {
            _bot = bot;
            _botStub = this;
            _script = script;
            _scriptStopped = scriptStoppedCallback;
        }

        internal void onFinish()
        {
            _running = false;
            _script.onFinish();
            DestroyEvents();
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

        internal void ExecuteScript()
        {
            // Process
            try
            {
                ExecuteEvents();
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

        internal void ExecuteEvents()
        {
            eventHandler = new Event.EventHandler();

            // quickfix. TODO: remove this dependency
            var browser = new ChromiumBrowserAdapter(new CefSharp.OffScreen.ChromiumWebBrowser());
            eventHandler.Bind(new BrowserHandler(browser, _script));
            eventHandler.Bind(new InputHandler(_bot, _script));
            eventHandler.Bind(new PaintHandler(_bot, _script));

            eventHandler.Apply();
        }

        internal void DestroyEvents()
        {
            eventHandler.Destroy();
        }
    }
}
