﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace w3bot.listener
{
    public interface IDocumentReadyListener
    {
        void DocumentReady(object sender, ChromiumBrowserEventArgs e);
    }
}
