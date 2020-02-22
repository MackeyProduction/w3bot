using System;
using System.Windows.Forms;

namespace w3bot.Event
{
    public interface IMouseEvent
    {
        EventHandler MouseEnter { get; set; }
        EventHandler MouseLeave { get; set; }
        MouseEventHandler MouseClick { get; set; }
        MouseEventHandler MouseMove { get; set; }

    }
}