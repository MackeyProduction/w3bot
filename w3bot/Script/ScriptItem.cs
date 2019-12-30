using System.Windows.Forms;

namespace w3bot.Script
{
    public class ScriptItem : ListViewItem
    {
        internal IScript script;
        internal ScriptManifest manifest;
    }
}
