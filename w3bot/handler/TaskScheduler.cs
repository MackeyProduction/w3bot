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

        internal TaskScheduler(Bot bot)
        {
            _bot = bot;

            if (_botStubList == null)
            {
                _botStubList = new List<BotStub>();
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

        public void Execute(int tabId)
        {
            var thread = new Thread(new ThreadStart(delegate
            {
                if (tabId != -1 && tabId < _botStubList.Count)
                {
                    var currentBotStub = _botStubList[tabId];

                    if (!currentBotStub._running)
                        currentBotStub.ExecuteScript();

                    _bot.core.runningScript = currentBotStub;
                    Bot.AddConfiguration(_bot.core);
                }
            }));

            thread.Start();
        }

        public void Destroy()
        {
            _botStubList = null;
        }
    }
}
