using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Interfaces;
using w3bot.Listener;

namespace w3bot.Core
{
    public class ScriptItem : ListViewItem
    {
        internal IScript script;
        internal ScriptManifest manifest;
    }
}
