using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.interfaces;

namespace w3bot.Listener
{
    public class DocumentLoadEventArgs
    {
        public IBrowser Browser { get; }
        public string Url { get; }
    }
}
