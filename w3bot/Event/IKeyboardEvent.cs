using System.Windows.Forms;

namespace w3bot.Event
{
    public interface IKeyboardEvent
    {
        KeyPressEventHandler KeyPress { get; set; }
    }
}