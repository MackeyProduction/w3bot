using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Bot;
using w3bot.Interfaces;
using w3bot.Listener;

namespace SecondTestScript
{
    [ScriptManifest("SecondTestScript", "Browser", "An another test script to test the scriptloader.", "NoChoice", 1.0)]
    public class SecondTestScript : Bot, IScript
    {
        public void onFinish()
        {
            //Status.Log("A second script test to test the scriptloader.");
        }

        public bool onStart()
        {
            //Status.Log("Script has been started.");

            var botWindow = CreateBrowserWindow();
            Initialize(botWindow);
            botWindow.Open();

            Browser.Navigate("github.com");

            return true;
        }

        public int onUpdate()
        {
            return 100;
        }
    }
}
