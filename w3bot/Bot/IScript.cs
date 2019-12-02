using w3bot.Evt.Listener;

namespace w3bot.Bot
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
