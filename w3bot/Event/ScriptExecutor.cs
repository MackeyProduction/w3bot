using System.Collections.Generic;
using System.Threading;
using w3bot.Core.Bot;
using w3bot.Script;
using w3bot.Util;

namespace w3bot.Event
{
    internal class ScriptExecutor : IExecutable
    {
        private IList<IScript> _scripts;
        private IList<Thread> _threads;
        private static ScriptExecutor _instance;
        private static readonly object padlock = new object();

        internal ScriptExecutor(IList<IScript> scripts, IList<Thread> threads)
        {
            _scripts = scripts;
            _threads = threads;
        }

        internal static ScriptExecutor Create
        {
            get
            {
                return _instance;
            }
            set
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = value;
                    }
                }
            }
        }

        public IList<IScript> GetScripts()
        {
            return _scripts;
        }

        public void Bind(IScript script)
        {
            _scripts.Add(script);
        }

        public void Remove(int tabId)
        {
            _scripts.RemoveAt(tabId);
            _threads[tabId].Abort();
        }

        public void Execute(int tabId)
        {
            if (tabId != -1 && tabId < _scripts.Count)
            {
                var currentScript = _scripts[tabId];
                
                if (!(currentScript.CurrentState == ScriptUtils.State.START))
                {
                    var thread = currentScript.Execute(ScriptUtils.State.START);
                    _threads.Add(thread);

                    _threads[tabId].Start();
                }
            }
        }

        public void Destroy()
        {
            _scripts = null;
        }
    }
}
