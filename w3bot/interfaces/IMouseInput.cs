using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.enumeration;

namespace w3bot.interfaces
{
    /// <summary>
    /// w3bot interface for mouse manipulation.
    /// </summary>
    interface IMouseInput
    {
        /// <summary>
        /// Execute mouse click.
        /// </summary>
        /// <param name="button">Button key.</param>
        /// <param name="evt">Event key.</param>
        void Click(Keys.Button button, Keys.Event evt);

        /// <summary>
        /// Execute mouse move.
        /// </summary>
        /// <param name="x">Coordinate x from mouse.</param>
        /// <param name="y">Coordinate y from mouse.</param>
        void Move(int x, int y);
        
        /// <summary>
        /// Execute mouse wheel.
        /// </summary>
        /// <param name="wheel">Wheel key.</param>
        /// <param name="amount">Amount of wheel.</param>
        void Wheel(Keys.Wheel wheel, int amount);
    }
}
