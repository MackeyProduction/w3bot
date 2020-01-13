using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Listener;
using System.Drawing;
using w3bot.Script;
using w3bot.Api;
using w3bot.Input;

namespace TestScript
{
    [ScriptManifest("TestScript", "YouTube", "Test the bot functionality.", "NoChoice", 1.0)]
    public class Class1 : AbstractScript, IDocumentReadyListener, IPaintListener
    {
        private Bitmap _bitmap;

        public override void OnFinish()
        {
            Status.Log("Thank you for using my script.");
        }

        public override void OnStart()
        {
            Status.Log("Test Script has been started.");

            var browserWindow = CreateBrowserWindow();
            browserWindow.Open();

            _bitmap = new Bitmap(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"/w3bot/compiled/Unbenannt.bmp");

            Browser.Navigate("google.com");
        }

        public override int OnUpdate()
        {
            if (Browser.IsReady)
            {
                var point = Frame.FindPixel(66, 133, 244, 255);
                var imagePoint = Frame.FindImage(_bitmap);
                Mouse.Move(imagePoint.X, imagePoint.Y);
                Mouse.LeftClick(imagePoint.X, imagePoint.Y);
                Sleep(2000);
                Keyboard.PressKeys("Hallo Welt!");
                //Mouse.ScrollDown();
                Status.Log($"X: {point.X}, Y: {point.Y}.");
                Status.Log($"X: {imagePoint.X}, Y: {imagePoint.Y}.");
                Status.Log("Executed.");
                Browser.GoBack();
                //return 0;
            }

            return 100;
        }

        public void OnPaint(Graphics g)
        {
            g.DrawString("Hello World", new Font("Arial", 12, FontStyle.Regular), Brushes.Green, 100, 100);
        }

        public void DocumentReady(object sender, DocumentReadyEventArgs e)
        {
            Status.Log("Document loaded successfully.");
        }
    }
}
