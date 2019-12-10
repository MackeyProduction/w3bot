using System.Collections.Generic;
using System.Threading;
using w3bot.Core.Bot;
using w3bot.Script;

namespace w3bot.Event
{
    internal class ScriptExecutor : IExecutable
    {
        private Bot _bot;
        private List<BotStub> _botStubList;
        private List<Thread> _threads;
        private static ScriptExecutor _instance;
        private static readonly object padlock = new object();

        internal ScriptExecutor(Bot bot)
        {
            _bot = bot;

            if (_botStubList == null)
            {
                _botStubList = new List<BotStub>();
                _threads = new List<Thread>();
            }
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

        public List<BotStub> GetItems()
        {
            return _botStubList;
        }

        public void Bind(BotStub botStub)
        {
            _botStubList.Add(botStub);
            _bot.core.runningScriptList = this;
            Bot.AddConfiguration(_bot.core);
        }

        public void Remove(int tabId)
        {
            _botStubList.RemoveAt(tabId);
            _bot.core.runningScriptList = this;
            _threads[tabId].Abort();
            Bot.AddConfiguration(_bot.core);
        }

        public void Execute(int tabId)
        {
            if (tabId != -1 && tabId < _botStubList.Count)
            {
                var currentBotStub = _botStubList[tabId];

                if (!currentBotStub._running)
                {
                    var thread = new Thread(new ThreadStart(delegate
                    {
                        currentBotStub.ExecuteScript();

                        _bot.core.runningScript = currentBotStub;
                        Bot.AddConfiguration(_bot.core);
                    }));
                    _threads.Add(thread);

                    _threads[tabId].Start();
                }
            }
        }

        public void Destroy()
        {
            _botStubList = null;
        }
    }
}
