using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Script;

namespace w3bot.Event
{
    public interface IApiEventListener
    {
        /// <summary>
        /// The update method for observe.
        /// </summary>
        /// <param name="api">The api.</param>
        T Update<T>(AbstractApiEvent api);
    }
}
