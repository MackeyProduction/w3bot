using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Bot;
using w3bot.Evt;
using w3bot.Interfaces;
using w3bot.Listener;
using System.Windows.Forms;
using CefSharp;
using CefSharp.OffScreen;
using System.Drawing;
using w3bot.Util;

namespace TestScript
{
    [ScriptManifest("TestScript", "YouTube", "Test the bot functionality.", "NoChoice", 1.0)]
    public class Class1 : Bot, IScript, IDocumentReadyListener, IPaintListener
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

            Browser.Navigate("google.com");

            return true;
        }

        public int onUpdate()
        {
            if (Browser.IsReady)
            {
                Mouse.Move(414, 402);
                Mouse.LeftClick(414, 402);
                var point = Frame.FindPixel(66, 133, 244, 255);
                var imagePoint = Frame.FindImage(new Bitmap("Unbenannt.bmp"));
                Status.Log($"X: {point.X}, Y: {point.Y}.");
                Status.Log($"X: {imagePoint.X}, Y: {imagePoint.Y}.");
                Status.Log("Executed.");
                //return 0;
            }

            return 1000;
        }

        public void DocumentReady(object sender, ChromiumBrowserEventArgs e)
        {
            Status.Log("Finished loading.");
        }

        public void OnPaint(Graphics g)
        {
            g.DrawString("Hello World", new Font("Arial", 12, FontStyle.Regular), Brushes.Green, 100, 100);
        }

        public void DocumentReady(object sender, FrameLoadEndEventArgs e)
        {
            Status.Log("Document is ready.");
        }
    }
}
