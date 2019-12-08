using w3bot.Bot;
using w3bot.Input;
using w3bot.Listener;
using w3bot.Script;

namespace w3bot.Tests
{
    [ScriptManifest("TestScript", "YouTube", "Test the bot functionality.", "NoChoice", 1.0)]
    public class TestScript : AbstractScript, IScript, IDocumentReadyListener, IAddressChangedListener
    {
        public void onFinish()
        {
            Status.Log("Thank you for using my script.");
        }

        public bool onStart()
        {
            Status.Log("Test Script has been started.");

            //var browserWindow = CreateBrowserWindow();
            //Initialize(browserWindow);
            //browserWindow.Open();

            Browser.Navigate("github.com");

            return true;
        }

        public int onUpdate()
        {
            return 100;
        }

        public void DocumentReady(object sender, DocumentReadyEventArgs e)
        {
            Status.Log("Document is ready.");
        }

        public void AddressChanged(object sender, DocumentAddressChangedEventArgs e)
        {
            Status.Log("Meh.");
        }
    }
}
