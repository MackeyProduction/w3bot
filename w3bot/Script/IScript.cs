using System.Threading;
using w3bot.Util;

namespace w3bot.Script
{
    /// <summary>
    /// w3bot interface for scripts.
    /// </summary>
    [ScriptManifest]
    public interface IScript
    {
        /// <summary>
        /// Gets the current state of the script.
        /// </summary>
        ScriptUtils.State CurrentState { get; set; }

        /// <summary>
        /// Gets the script manifest.
        /// </summary>
        ScriptManifest Manifest { get; set; }

        /// <summary>
        /// Executes the thread with state.
        /// </summary>
        /// <param name="state">The state of the script.</param>
        /// <returns>Returns the thread of the running script.</returns>
        Thread GetExecutable(ScriptUtils.State state);
    }
}
