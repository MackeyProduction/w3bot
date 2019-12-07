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
            _browser.GetHost().SendKeyEvent(new CefSharp.KeyEvent());
        }
    }
}
