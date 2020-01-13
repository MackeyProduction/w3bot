using System.Collections.Generic;

namespace w3bot.Event
{
    public abstract class AbstractEvent : IEventManager
    {
        private static List<IEventListener> _eventHandlers;

        public AbstractEvent()
        {
            _eventHandlers = new List<IEventListener>();
        }

        /// <summary>
        /// Attachs an event to event handler. All events stored in a list and can be executed with Notify() method.
        /// </summary>
        /// <param name="listener">The instance of event listener which will be added to the event manager.</param>
        public void Attach(IEventListener listener)
        {
            _eventHandlers.Add(listener);
        }

        /// <summary>
        /// Removes an listener from event handler list.
        /// </summary>
        /// <param name="listener">The instance of event listener which will be removed.</param>
        public void Detach(IEventListener listener)
        {
            _eventHandlers.Remove(listener);
        }

        /// <summary>
        /// Notifies all observers.
        /// </summary>
        public void Notify()
        {
            foreach (var handler in _eventHandlers)
            {
                if (handler is IEventListener)
                {
                    handler.Update(this);
                }
            }
        }
    }
}
