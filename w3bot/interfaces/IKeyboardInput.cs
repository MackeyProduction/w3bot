using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.interfaces
{
    /// <summary>
    /// w3bot interface for keyboard manipulation.
    /// </summary>
    interface IKeyboardInput
    {
        /// <summary>
        /// Execute keyboard key event.
        /// </summary>
        /// <param name="c">Keyboard key code.</param>
        void KeyEvent(char c);
    }
}
