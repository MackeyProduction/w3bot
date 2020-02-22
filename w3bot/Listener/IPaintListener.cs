using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using System.Windows.Forms;
using System.Drawing;

namespace w3bot.Listener
{
    public interface IPaintListener
    {
        /// <summary>
        /// Called each time the bot needs to redraw.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="g">Used to draw on.</param>
        void OnPaint(object sender, Graphics g);
    }
}
