using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Event
{
    /// <summary>
    /// w3bot interface for event handling.
    /// </summary>
    public interface IEventListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        void Update(IEventManager manager);
    }
}
