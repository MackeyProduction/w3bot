using System;
using w3bot.Wrapper;

namespace w3bot.Listener
{
    public class DocumentLoadEventArgs : EventArgs
    {
        private IBrowser _browser;
        private string _url;

        public DocumentLoadEventArgs(IBrowser browser, string url)
        {
            _browser = browser;
            _url = url;
        }

        public IBrowser Browser { get { return _browser; } }
        public string Url { get { return _url; } }
    }
}
