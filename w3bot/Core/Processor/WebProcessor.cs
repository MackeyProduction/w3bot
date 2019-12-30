using System;
using System.Drawing;
using System.Windows.Forms;
using w3bot.Core.Utilities;
using w3bot.Listener;
using w3bot.Wrapper;

namespace w3bot.Core.Processor
{
    internal class WebProcessor : IProcessor
    {
        private Panel _panel;
        private IBotBrowser _botBrowser;
        private bool _input;

        public Bitmap Frame => throw new NotImplementedException();

        public Point MousePos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public WebProcessor(IBotBrowser botBrowser)
        {
            _botBrowser = botBrowser;
            //_panel = panel;
            _input = false;
        }

        public void Activate()
        {
            _botBrowser.DocumentReady += _botBrowser_DocumentReady;
        }

        private void _botBrowser_DocumentReady(object sender, DocumentReadyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void AllowInput()
        {
            if (!_input)
            {
                _panel.MouseMove += _panel_MouseMove;
                _panel.MouseUp += _panel_MouseUp;
                _panel.MouseDown += _panel_MouseDown;
                //_bot.core.mainWindow.KeyPress += MainWindow_KeyPress;
                _panel.MouseWheel += _panel_MouseWheel;
                _input = true;
            }
        }

        private void _panel_MouseWheel(object sender, MouseEventArgs e)
        {
            _botBrowser.GetMouse().Click(MouseEvent(e), Util.Keys.Event.DOWNUP);
        }

        private void _panel_MouseDown(object sender, MouseEventArgs e)
        {
            _botBrowser.GetMouse().Click(MouseEvent(e), Util.Keys.Event.DOWN);
        }

        private void _panel_MouseUp(object sender, MouseEventArgs e)
        {
            _botBrowser.GetMouse().Click(MouseEvent(e), Util.Keys.Event.UP);
        }

        private void _panel_MouseMove(object sender, MouseEventArgs e)
        {
            _botBrowser.GetMouse().Move(e.X, e.Y);
        }

        public void BlockInput()
        {
            if (_input)
            {
                _panel.MouseMove -= _panel_MouseMove;
                _panel.MouseUp -= _panel_MouseUp;
                _panel.MouseDown -= _panel_MouseDown;
                _panel.MouseWheel -= _panel_MouseWheel;
                _input = false;
            }
        }

        public void Destroy()
        {
            _botBrowser.Dispose();
        }

        public void DropFocus()
        {
            throw new NotImplementedException();
        }

        public void GetFocus()
        {
            _panel.Focus();
        }

        private Util.Keys.Button MouseEvent(MouseEventArgs e)
        {
            Util.Keys.Button mType;
            switch (e.Button)
            {
                case MouseButtons.Right:
                    mType = Util.Keys.Button.RIGHT;
                    break;
                case MouseButtons.Middle:
                    mType = Util.Keys.Button.MIDDLE;
                    break;
                default:
                    mType = Util.Keys.Button.LEFT;
                    break;
            }

            return mType;
        }

        public bool IsValidProcessor(ProcessorType type)
        {
            return type == ProcessorType.BrowserProcessor;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
