using CefSharp;

namespace w3bot.Wrapper.Input
{
    class ChromiumKeyboard : IKeyboardInput
    {
        private CefSharp.IBrowser _browser;

        internal ChromiumKeyboard(CefSharp.IBrowser browser)
        {
            _browser = browser;
        }

        public void KeyEvent(char c)
        {
            KeyEvent keyEvent = new KeyEvent();
            keyEvent.Type = KeyEventType.Char;
            keyEvent.WindowsKeyCode = c;
            _browser.GetHost().SendKeyEvent(keyEvent);
        }
    }
}
