using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Interfaces;

namespace w3bot.Listener
{
    public class AddressChangedEventArgs
    {
        public string Address { get; }
        public IBrowser Browser { get; }
    }
}
