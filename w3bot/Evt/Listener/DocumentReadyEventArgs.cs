using System;
using w3bot.Wrapper;

namespace w3bot.Evt.Listener
{
    public class DocumentReadyEventArgs : EventArgs
    {
        private IBrowser _browser;
        private int _httpStatusCode;
        private string _url;

        public DocumentReadyEventArgs(IBrowser browser, int httpStatusCode, string url)
        {
            _browser = browser;
            _httpStatusCode = httpStatusCode;
            _url = url;
        }

        public IBrowser Browser { get { return _browser; } }
        public int HttpStatusCode { get { return _httpStatusCode; } set { _httpStatusCode = value; } }
        public string Url { get { return _url; } }
    }
}
