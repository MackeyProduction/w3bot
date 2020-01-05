using System;
using System.Drawing;
using System.Windows.Forms;
using w3bot.Core.Utilities;
using w3bot.Listener;
using w3bot.Wrapper;

namespace w3bot.Core.Processor
{
    internal class WebProcessor : Panel, IProcessor
    {
        private IBotBrowser _botBrowser;
        private bool _input;
        private Timer _timer;
        private Point _mouse;

        public Bitmap Frame
        {
            get
            {
                return _botBrowser.Frame;
            }
        }

        public Point MousePos
        {
            get
            {
                return _mouse;
            }

            set
            {
                _mouse = value;
            }
        }

        public Panel Panel
        {
            get
            {
                return this;
            }
        }

        public WebProcessor(IBotBrowser botBrowser)
        {
            DoubleBuffered = true;
            Size = new Size(994, 582);
            _botBrowser = botBrowser;
            _input = false;
            _timer = new Timer();
            _timer.Interval = 25;
            _timer.Tick += Timer_Tick;
            _mouse = new Point(0, 0);
        }

        public void Activate()
        {
            Paint += WebProcessor_Paint;
            _timer.Start();
        }

        private void WebProcessor_Paint(object sender, PaintEventArgs e)
        {
            if (_botBrowser.Frame == null) return;

            Pen greenPen = new Pen(Color.Green);

            var g = e.Graphics;
            g.DrawImage(_botBrowser.Frame, 0, 0);

            // draw mouse
            Point m = _mouse;
            e.Graphics.DrawLine(greenPen, new Point(m.X - 5, m.Y - 5), new Point(m.X + 5, m.Y + 5));
            e.Graphics.DrawLine(greenPen, new Point(m.X - 5, m.Y + 5), new Point(m.X + 5, m.Y - 5));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        public void AllowInput()
        {
            if (!_input)
            {
                this.MouseMove += _panel_MouseMove;
                this.MouseUp += _panel_MouseUp;
                this.MouseDown += _panel_MouseDown;
                this.MouseWheel += _panel_MouseWheel;
                w3bot.Script.Bot._form.KeyPress += _form_KeyPress;
                _input = true;
            }
        }

        private void _form_KeyPress(object sender, KeyPressEventArgs e)
        {
            _botBrowser.GetKeyboard().KeyEvent(e.KeyChar);
        }

        private void _panel_MouseWheel(object sender, MouseEventArgs e)
        {
            int deltaY = e.Delta;
            if (deltaY > 0)
            {
                _botBrowser.GetMouse().Wheel(Util.Keys.Wheel.UP, 120);
            }
            else
            {
                _botBrowser.GetMouse().Wheel(Util.Keys.Wheel.DOWN, 120);
            }
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
            _mouse = new Point(e.X, e.Y);
            _botBrowser.GetMouse().Move(e.X, e.Y);
        }

        public void BlockInput()
        {
            if (_input)
            {
                this.MouseMove -= _panel_MouseMove;
                this.MouseUp -= _panel_MouseUp;
                this.MouseDown -= _panel_MouseDown;
                this.MouseWheel -= _panel_MouseWheel;
                w3bot.Script.Bot._form.KeyPress -= _form_KeyPress;
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
            this.Focus();
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
    }
}
