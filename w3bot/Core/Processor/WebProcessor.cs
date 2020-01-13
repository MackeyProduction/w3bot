using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using w3bot.Api;
using w3bot.Core.Utilities;
using w3bot.Event;
using w3bot.Input;
using w3bot.Script;
using w3bot.Wrapper;

namespace w3bot.Core.Processor
{
    internal class WebProcessor : AbstractEvent, IProcessor
    {
        private Panel _panel;
        private IBotBrowser _botBrowser;
        private IMouseInput _mouseInput;
        private IBrowser _browser;
        private bool _input;
        private Timer _timer;
        private Point _mouse;
        private Font font = new Font("Arial", 8);

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
                return _panel;
            }
        }

        public WebProcessor(Panel panel, IBotBrowser botBrowser)
        {
            _panel = panel;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, _panel, new object[] { true }); // activate double buffering
            _panel.Size = new Size(994, 582);
            _botBrowser = botBrowser;
            _input = false;
            _timer = new Timer();
            _timer.Interval = 25;
            _timer.Tick += Timer_Tick;
            _mouse = new Point(0, 0);
        }

        public void Activate()
        {
            _panel.Paint += WebProcessor_Paint;

            // initialize browser, mouse and keyboard
            Browser.AddConfiguration(_botBrowser);
            Mouse.AddConfiguration(_botBrowser.GetMouse());
            Keyboard.AddConfiguration(_botBrowser.GetKeyboard());

            _timer.Start();
        }

        private void WebProcessor_Paint(object sender, PaintEventArgs e)
        {
            //if (_browser == null) return;
            if (!IsFrameValid(Frame))
                return;

            Pen greenPen = new Pen(Color.Green);

            var g = e.Graphics;
            g.DrawImage(Frame, 0, 0);

            // draw mouse
            Point m = _mouse;
            e.Graphics.DrawLine(greenPen, new Point(m.X - 5, m.Y - 5), new Point(m.X + 5, m.Y + 5));
            e.Graphics.DrawLine(greenPen, new Point(m.X - 5, m.Y + 5), new Point(m.X + 5, m.Y - 5));

            g.DrawString("Mouse: " + _mouse.X + ", " + _mouse.Y, font, Brushes.Green, 5, 13);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Notify();
            _panel.Invalidate();
        }

        public void AllowInput()
        {
            if (!_input)
            {
                _panel.MouseMove += _panel_MouseMove;
                _panel.MouseUp += _panel_MouseUp;
                _panel.MouseDown += _panel_MouseDown;
                _panel.MouseWheel += _panel_MouseWheel;
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
                _botBrowser.GetMouse().Wheel(Util.Keys.Wheel.DOWN, 120);
            }
            else
            {
                _botBrowser.GetMouse().Wheel(Util.Keys.Wheel.UP, 120);
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
                _panel.MouseMove -= _panel_MouseMove;
                _panel.MouseUp -= _panel_MouseUp;
                _panel.MouseDown -= _panel_MouseDown;
                _panel.MouseWheel -= _panel_MouseWheel;
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
            
        }

        public void GetFocus()
        {
            w3bot.Script.Bot.ExeThreadSafe(delegate
            {
                _panel.Focus();
            });
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

        private bool IsFrameValid(Bitmap frame)
        {
            if (frame == null)
                return false;

            byte[] imageBytes;
            try
            {
                ImageConverter converter = new ImageConverter();
                imageBytes = (byte[])converter.ConvertTo(frame, typeof(byte[]));
            } catch (Exception e)
            {
                throw e;
            }

            if (imageBytes.Length < 1)
                return false;

            return true;
        }

        public void Dispose()
        {
            _panel.Dispose();
        }

        //public void OnMouseChange(IMouseInput mouse, Util.Keys.Type type, object[] args)
        //{
        //    switch (type)
        //    {
        //        case Util.Keys.Type.MOVE:
                    
        //            break;
        //        case Util.Keys.Type.CLICK:
        //            var mouseBtn = (Util.Keys.Button)args[0];
        //            var mouseEvt = (Util.Keys.Event)args[1];
        //            mouse.Click(mouseBtn, mouseEvt);
        //            break;
        //        case Util.Keys.Type.WHEEL:
        //            break;
        //        default:
        //            break;
        //    }
        //}

        public void OnChange(object[] arguments)
        {
            foreach (var arg in arguments)
            {
                if (arg is IBrowser)
                {
                    _browser = (IBrowser)arg;
                }
            }
        }
    }
}
