using System;
using System.Collections.Generic;
using System.Threading;
using w3bot.Core.Processor;
using w3bot.Listener;
using w3bot.Script;
using w3bot.Util;

namespace w3bot.Event
{
    internal class ScriptExecutor : IExecutable
    {
        private IList<IScript> _scripts;
        private IProcessorService _processorService;
        private IProcessor _processor;
        public IScript RunningScript { get; private set; }

        // TODO: maybe create a service for this? 
        internal ScriptExecutor(IList<IScript> scripts, IProcessorService processorService)
        {
            _scripts = scripts;
            _processorService = processorService;
        }

        public void Bind<T>(T name)
        {
            _scripts.Add((IScript)name);
        }

        // TODO: Change parameter to script state?
        public void Execute(int id)
        {
            try
            {
                if (id != -1 && id <= _scripts.Count)
                {
                    var currentScript = _scripts[id - 1];

                    if (currentScript.CurrentState == ScriptUtils.State.START)
                    {
                        var thread = currentScript.GetExecutable(ScriptUtils.State.START);

                        thread.Start();
                        RunningScript = currentScript;

                        _processor = _processorService.GetById(id - 1);

                        if (_processor == null)
                            return;

                        // execute events
                        Draw(currentScript, _processor);
                        MouseEvent(currentScript, _processor);
                    }
                }
            } 
            catch (Exception e)
            {
                throw e;
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

        private void Draw(IScript script, IProcessor processor)
        {
            if (script is IPaintListener)
            {
                processor.PaintHandler.Paint += ((IPaintListener)script).OnPaint;
            }
        }

        private void MouseEvent(IScript script, IProcessor processor)
        {
            if (script is IMouseEventListener)
            {
                processor.MouseHandler.MouseClick += ((IMouseEventListener)script).OnMouseClick;
                processor.MouseHandler.MouseMove += ((IMouseEventListener)script).OnMouseMove;
                processor.MouseHandler.MouseEnter += ((IMouseEventListener)script).OnMouseEnter;
                processor.MouseHandler.MouseLeave += ((IMouseEventListener)script).OnMouseLeave;
            }
        }
    }
}
