using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Evt;
using w3bot.Interfaces;

namespace w3bot.Handler
{
    public class EventHandler : IEventHandler
    {
        private static List<IEventHandler> _eventHandlers;

        public EventHandler()
        {
            _eventHandlers = new List<IEventHandler>();
        }

        /// <summary>
        /// Binds an event to event handler. All events stored in a list and can be executed with Verify() method.
        /// </summary>
        /// <param name="eventHandler"></param>
        public void Bind(IEventHandler eventHandler)
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
                if (handler is IEventHandler)
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
                if (handler is IEventHandler)
                {
                    handler.Destroy();
                }
            }
        }
    }
}
