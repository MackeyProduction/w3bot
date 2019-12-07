using System;
using w3bot.Wrapper;

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
