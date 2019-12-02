using System.Windows.Forms;
using w3bot.Bot;
using w3bot.Evt.Listener;

namespace w3bot.Core.Script
{
    public class ScriptItem : ListViewItem
    {
        internal IScript script;
        internal ScriptManifest manifest;
    }
}
