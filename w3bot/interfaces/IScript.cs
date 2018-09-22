using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.listener;

namespace w3bot.interfaces
{
    /// <summary>
    /// w3bot interface for scripts.
    /// </summary>
    [ScriptManifest]
    public interface IScript
    {
        /// <summary>
        /// Initializes the running script.
        /// </summary>
        /// <returns>Returns true if the script is initialized.</returns>
        bool onStart();

        /// <summary>
        /// Starts the running script.
        /// </summary>
        /// <returns>Returns the current script tick rate.</returns>
        int onUpdate();

        /// <summary>
        /// Destroys the running script.
        /// </summary>
        void onFinish();
    }
}
