using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace w3bot.Listener
{
    public interface IDocumentLoadListener
    {
        void DocumentLoad(object sender, FrameLoadStartEventArgs e);
    }
}
