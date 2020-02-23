using System;
using System.Windows.Forms;
using w3bot.Listener;
using w3bot.Script;

namespace w3bot.Event
{
    public class MouseEvent : IMouseEvent
    {
        public EventHandler MouseEnter { get; set; }
        public EventHandler MouseLeave { get; set; }
        public MouseEventHandler MouseClick { get; set; }
        public MouseEventHandler MouseMove { get; set; }

        public MouseEvent()
        {
        }

        protected virtual void OnMouseMove(object sender, MouseEventArgs e)
        {
            MouseMove?.Invoke(sender, e);
        }

        protected virtual void OnMouseClick(object sender, MouseEventArgs e)
        {
            MouseClick?.Invoke(sender, e);
        }

        protected virtual void OnMouseEnter(object sender, EventArgs e)
        {
            MouseEnter?.Invoke(sender, e);
        }

        protected virtual void OnMouseLeave(object sender, EventArgs e)
        {
            MouseLeave?.Invoke(sender, e);
        }
    }
}
