using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Wrapper;

namespace w3bot.Core
{
    class WebProcessor : IProcessor
    {
        private Panel _panel;
        private IBotBrowser _botBrowser;
        private bool _input;

        public WebProcessor(Panel panel, IBotBrowser botBrowser)
        {
            _botBrowser = botBrowser;
            _panel = panel;
            _input = false;
        }

        public void Activate()
        {
            _botBrowser.DocumentReady += _botBrowser_DocumentReady;
        }

        private void _botBrowser_DocumentReady(object sender, Listener.DocumentReadyEventArgs e)
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
            _botBrowser.GetMouse().Click(MouseEvent(e), Enumeration.Keys.Event.DOWNUP);
        }

        private void _panel_MouseDown(object sender, MouseEventArgs e)
        {
            _botBrowser.GetMouse().Click(MouseEvent(e), Enumeration.Keys.Event.DOWN);
        }

        private void _panel_MouseUp(object sender, MouseEventArgs e)
        {
            _botBrowser.GetMouse().Click(MouseEvent(e), Enumeration.Keys.Event.UP);
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

        private Enumeration.Keys.Button MouseEvent(MouseEventArgs e)
        {
            Enumeration.Keys.Button mType;
            switch (e.Button)
            {
                case MouseButtons.Right:
                    mType = Enumeration.Keys.Button.RIGHT;
                    break;
                case MouseButtons.Middle:
                    mType = Enumeration.Keys.Button.MIDDLE;
                    break;
                default:
                    mType = Enumeration.Keys.Button.LEFT;
                    break;
            }

            return mType;
        }
    }
}
