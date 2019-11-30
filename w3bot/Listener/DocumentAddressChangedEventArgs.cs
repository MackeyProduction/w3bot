using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Interfaces;

namespace w3bot.Listener
{
    public class DocumentAddressChangedEventArgs : EventArgs
    {
        private IBrowser _browser;
        private string _address;

        public DocumentAddressChangedEventArgs(IBrowser browser, string address)
        {
            _browser = browser;
            _address = address;
        }

        public string Address { get { return _address; } }
        public IBrowser Browser { get { return _browser; } }
    }
}
