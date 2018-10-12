using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using w3bot.bot;
using w3bot.evt;
using w3bot.interfaces;
using w3bot.listener;

namespace w3bot.test
{
    [ScriptManifest("TestScript", "YouTube", "Test the bot functionality.", "NoChoice", 1.0)]
    public class TestScript : Bot, IScript, IDocumentReadyListener, IAddressChangedListener
    {
        public void onFinish()
        {
            Status.Log("Thank you for using my script.");
        }

        public bool onStart()
        {
            Status.Log("Test Script has been started.");

            var browserWindow = CreateBrowserWindow();
            Initialize(browserWindow);
            browserWindow.Open();

            Browser.Navigate("github.com");

            return true;
        }

        public int onUpdate()
        {
            return 100;
        }

        public void DocumentReady(object sender, ChromiumBrowserEventArgs e)
        {
            Status.Log("Document is ready.");
        }

        public void AddressChanged(object sender, ChromiumBrowserEventArgs e)
        {
            Status.Log("Meh.");
        }
    }
}
