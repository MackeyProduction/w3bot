using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.interfaces;

namespace w3bot.Listener
{
    public class DocumentReadyEventArgs
    {
        public IBrowser Browser { get; }
        public int HttpStatusCode { get; set; }
        public string Url { get; }
    }
}
