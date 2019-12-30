using System.Collections.Generic;

namespace w3bot.Event
{
    public abstract class AbstractEvent : IEventListener
    {
        private static List<IEventListener> _eventHandlers;

        public AbstractEvent()
        {
            _eventHandlers = new List<IEventListener>();
        }

        /// <summary>
        /// Binds an event to event handler. All events stored in a list and can be executed with Verify() method.
        /// </summary>
        /// <param name="eventHandler"></param>
        public void Bind(IEventListener eventHandler)
        {
            _eventHandlers.Add(eventHandler);
        }

        /// <summary>
        /// Removes an item from event handler list.
        /// </summary>
        /// <param name="position">The position of list item.</param>
        public void Remove(int position)
        {
            _eventHandlers.RemoveAt(position);
        }

        /// <summary>
        /// In Bind() method stored events will be executed.
        /// </summary>
        public void Apply()
        {
            foreach (var handler in _eventHandlers)
            {
                if (handler is IEventListener)
                {
                    handler.Apply();
                }
            }
        }

        /// <summary>
        /// Destroys all binded events.
        /// </summary>
        public void Destroy()
        {
            foreach (var handler in _eventHandlers)
            {
                if (handler is IEventListener)
                {
                    handler.Destroy();
                }
            }
        }
    }
}
