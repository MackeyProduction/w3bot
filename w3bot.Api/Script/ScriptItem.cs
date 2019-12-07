using System.Windows.Forms;
using w3bot.Bot;
using w3bot.Script;

namespace w3bot.Script
{
    public class ScriptItem : ListViewItem
    {
        internal IScript script;
        internal ScriptManifest manifest;
    }
}
