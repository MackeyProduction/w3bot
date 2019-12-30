using System;
using System.Collections.Generic;
using System.Threading;
using w3bot.Script;
using w3bot.Util;

namespace w3bot.Event
{
    internal class ScriptExecutor : IExecutable
    {
        private IList<IScript> _scripts;

        // TODO: maybe create a service for this? 
        internal ScriptExecutor(IList<IScript> scripts)
        {
            _scripts = scripts;
        }

        public void Bind<T>(T name)
        {
            _scripts.Add((IScript)name);
        }

        // TODO: Change parameter to script state?
        public void Execute(int id)
        {
            if (id != -1 && id < _scripts.Count)
            {
                var currentScript = _scripts[id];
                
                if (!(currentScript.CurrentState == ScriptUtils.State.START))
                {
                    var thread = currentScript.GetExecutable(ScriptUtils.State.START);

                    thread.Start();
                }
            }
        }

        public void Destroy()
        {
            _scripts = null;
        }

        public List<T> GetExecutables<T>()
        {
            return (List<T>)Convert.ChangeType(_scripts, typeof(List<IScript>));
        }
    }
}
