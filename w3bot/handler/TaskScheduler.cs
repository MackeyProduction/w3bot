using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using w3bot.bot;
using w3bot.core;
using w3bot.interfaces;

namespace w3bot.handler
{
    internal class TaskScheduler : ITaskScheduler
    {
        private Bot _bot;
        private List<BotStub> _botStubList;
        private List<Thread> _threads;
        private static TaskScheduler _instance;
        private static readonly object padlock = new object();

        internal TaskScheduler(Bot bot)
        {
            _bot = bot;

            if (_botStubList == null)
            {
                _botStubList = new List<BotStub>();
                _threads = new List<Thread>();
            }
        }

        internal static TaskScheduler Create
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
