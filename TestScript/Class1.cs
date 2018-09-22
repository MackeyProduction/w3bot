using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.bot;
using w3bot.evt;
using w3bot.interfaces;
using w3bot.listener;

namespace TestScript
{
    [ScriptManifest("TestScript", "YouTube", "Test the bot functionality.", "NoChoice", 1.0)]
    public class Class1 : Bot, IScript
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

            Browser.Navigate("youtube.com");

            return true;
        }

        public int onUpdate()
        {
            return 100;
        }
    }
}
