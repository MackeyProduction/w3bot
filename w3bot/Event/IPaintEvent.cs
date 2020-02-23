using System;
using System.Drawing;

namespace w3bot.Event
{
    public interface IPaintEvent
    {
        EventHandler<Graphics> Paint { get; set; }
    }
}