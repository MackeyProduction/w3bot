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
        void MouseEvent(object sender, MouseEventArgs e);
    }
}
