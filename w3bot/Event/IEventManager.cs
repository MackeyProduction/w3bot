using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Event
{
    /// <summary>
    /// Observable for events.
    /// </summary>
    public interface IEventManager
    {
        /// <summary>
        /// Attach an event listener to the event manager.
        /// </summary>
        /// <param name="listener">The instance of the event listener.</param>
        void Attach(IEventListener listener);

        /// <summary>
        /// Detach an event listener from the event manager.
        /// </summary>
        /// <param name="listener">The instance of the event listener.</param>
        void Detach(IEventListener listener);

        /// <summary>
        /// Notifies all attached observers.
        /// </summary>
        void Notify();
    }
}
