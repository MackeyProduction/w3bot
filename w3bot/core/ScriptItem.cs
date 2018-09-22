using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.interfaces;
using w3bot.listener;

namespace w3bot.core
{
    public class ScriptItem : ListViewItem
    {
        internal IScript script;
        internal ScriptManifest manifest;
    }
}
