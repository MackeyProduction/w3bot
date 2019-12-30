using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace w3bot.Event
{
    /// <summary>
    /// w3bot interface for task scheduler.
    /// </summary>
    public interface IExecutable
    {
        /// <summary>
        /// Gets a list of executables.
        /// </summary>
        /// <typeparam name="T">The type of the executable list.</typeparam>
        /// <returns>Returns a list of executables.</returns>
        List<T> GetExecutables<T>();

        /// <summary>
        /// Binds an executable to the exec stack.
        /// </summary>
        /// <typeparam name="T">The type of the executable.</typeparam>
        /// <param name="name">The name of the executable.</param>
        void Bind<T>(T name);

        /// <summary>
        /// Executes event.
        /// </summary>
        void Execute(int id);

        /// <summary>
        /// Destroys an event.
        /// </summary>
        void Destroy();
    }
}
