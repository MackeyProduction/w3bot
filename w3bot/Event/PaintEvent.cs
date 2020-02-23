using System;
using System.Drawing;
using w3bot.Listener;
using w3bot.Script;

namespace w3bot.Event
{
    public class PaintEvent : IPaintEvent
    {
        public EventHandler<Graphics> Paint { get; set; }

        public PaintEvent()
        {
        }

        protected virtual void OnPaint(object sender, Graphics g)
        {
            Paint?.Invoke(sender, g);
        }
    }
}
