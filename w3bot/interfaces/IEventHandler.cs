using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.interfaces
{
    /// <summary>
    /// w3bot interface for event handling.
    /// </summary>
    public interface IEventHandler
    {
        /// <summary>
        /// Executes event.
        /// </summary>
        void Apply();
    }
}
