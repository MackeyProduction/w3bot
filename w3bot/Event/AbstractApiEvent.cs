using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Script;

namespace w3bot.Event
{
    public abstract class AbstractApiEvent
    {
        private List<IApiEventListener> _apiEventListeners;
        public MethodProvider MethodProvider { get; set; }

        public AbstractApiEvent()
        {
            _apiEventListeners = new List<IApiEventListener>();
            MethodProvider = new MethodProvider();
        }

        public void Attach(IApiEventListener apiEventListener)
        {
            _apiEventListeners.Add(apiEventListener);
        }

        public void Detach(IApiEventListener apiEventListener)
        {
            _apiEventListeners.Remove(apiEventListener);
        }

        public void Notify()
        {
            foreach (IApiEventListener apiEventListener in _apiEventListeners)
            {
                MethodProvider = apiEventListener.Update<MethodProvider>(this);
            }
        }
    }
}
