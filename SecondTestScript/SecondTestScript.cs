﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Api;
using w3bot.Input;
using w3bot.Listener;
using w3bot.Script;

namespace SecondTestScript
{
    [ScriptManifest("SecondTestScript", "Browser", "An another test script to test the scriptloader.", "NoChoice", 1.0)]
    public class SecondTestScript : AbstractScript, IDocumentReadyListener
    {
        public override void OnFinish()
        {
            Status.Log("A second script test to test the scriptloader.");
        }

        public override void OnStart()
        {
            Status.Log("Script has been started.");

            CreateBrowserWindow();

            // test script manifest
            Status.Log($"{Name} v{Version} by {Author}");
            Status.Log($"{Description}");
            Status.Log($"Target App: {TargetApp}");

            Browser.Navigate("github.com");
        }

        public override int OnUpdate()
        {
            return 100;
        }

        public void DocumentReady(object sender, DocumentReadyEventArgs e)
        {
            Status.Log("Document loaded successfully.");
        }
    }
}
