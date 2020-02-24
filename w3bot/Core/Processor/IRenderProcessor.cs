using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace w3bot.Core.Processor
{
    interface IRenderProcessor
    {
        void OnRender(EventHandler<Graphics> handler);
        void OnKeyPress(object sender, KeyPressEventArgs e);
    }
}
