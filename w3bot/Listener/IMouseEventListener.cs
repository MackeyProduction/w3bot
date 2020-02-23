using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace w3bot.Listener
{
    public interface IMouseEventListener
    {
        void OnMouseClick(object sender, MouseEventArgs e);
        void OnMouseMove(object sender, MouseEventArgs e);
        void OnMouseEnter(object sender, EventArgs e);
        void OnMouseLeave(object sender, EventArgs e);
    }
}
