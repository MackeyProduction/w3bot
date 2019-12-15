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

        internal ScriptExecutor(IList<IScript> scripts, IList<Thread> threads)
        {
            _scripts = scripts;
            _threads = threads;
        }

        public void Execute(int id)
        {
            if (id != -1 && id < _scripts.Count)
            {
                var currentScript = _scripts[id];
                
                if (!(currentScript.CurrentState == ScriptUtils.State.START))
                {
                    var thread = currentScript.Execute(ScriptUtils.State.START);
                    _threads.Add(thread);

                    _threads[id].Start();
                }
            }
        }

        public void Destroy()
        {
            _scripts = null;
            _threads = null;
        }
    }
}
