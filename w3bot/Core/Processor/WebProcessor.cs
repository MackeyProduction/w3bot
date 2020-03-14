using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using w3bot.Api;
using w3bot.Core.Utilities;
using w3bot.Event;
using w3bot.Input;
using w3bot.Listener;
using w3bot.Script;
using w3bot.Wrapper;

namespace w3bot.Core.Processor
{
    internal class WebProcessor : Panel, IProcessor
    {
        private IBotBrowser _botBrowser;
        private bool _input;
        private Timer _timer;
        private Point _mouse;
        public event EventHandler<Graphics> Draw;
        public event KeyPressEventHandler KeyPressed;

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

        public IMouseEvent MouseHandler { get; set; }
        public IKeyboardEvent KeyboardHandler { get; set; }
        public IPaintEvent PaintHandler { get; set; }
        public string SourceCode { get; set; }
        public string Url { get; set; }

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
            this.Paint += WebProcessor_Paint;

            // initialize browser, mouse and keyboard
            Browser.AddConfiguration(_botBrowser);
            Mouse.AddConfiguration(_botBrowser.GetMouse());
            Keyboard.AddConfiguration(_botBrowser.GetKeyboard());

            _timer.Start();
        }

        private void WebProcessor_MouseLeave(object sender, EventArgs e)
        {
            MouseHandler.MouseLeave?.Invoke(sender, e);
        }

        private void WebProcessor_MouseEnter(object sender, EventArgs e)
        {
            MouseHandler.MouseEnter?.Invoke(sender, e);
        }

        private void WebProcessor_MouseClick(object sender, MouseEventArgs e)
        {
            MouseHandler.MouseClick?.Invoke(sender, e);
        }

        private void WebProcessor_Paint(object sender, PaintEventArgs e)
        {
            //if (_browser == null) return;
            if (!IsFrameValid(Frame))
                return;

            var g = e.Graphics;
            g.DrawImage(Frame, 0, 0);
            
            OnPaint(g);
            PaintHandler.Paint?.Invoke(sender, e.Graphics);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SourceCode = _botBrowser.SourceCode;
            Url = _botBrowser.Url;

            this.Invalidate();
        }

        public void AllowInput()
        {
            if (!_input)
            {
                this.MouseMove += WebProcessor_MouseMove;
                this.MouseUp += WebProcessor_MouseUp;
                this.MouseDown += WebProcessor_MouseDown;
                this.MouseWheel += WebProcessor_MouseWheel;
                this.MouseClick += WebProcessor_MouseClick;
                this.MouseEnter += WebProcessor_MouseEnter;
                this.MouseLeave += WebProcessor_MouseLeave;
                this.KeyPressed += _form_KeyPress;
                _input = true;
            }
        }

        private void _form_KeyPress(object sender, KeyPressEventArgs e)
        {
            _botBrowser.GetKeyboard().KeyEvent(e.KeyChar);
        }

        private void WebProcessor_MouseWheel(object sender, MouseEventArgs e)
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

        private void WebProcessor_MouseDown(object sender, MouseEventArgs e)
        {
            _botBrowser.GetMouse().Click(MouseEvent(e), Util.Keys.Event.DOWN);
        }

        private void WebProcessor_MouseUp(object sender, MouseEventArgs e)
        {
            _botBrowser.GetMouse().Click(MouseEvent(e), Util.Keys.Event.UP);
        }

        private void WebProcessor_MouseMove(object sender, MouseEventArgs e)
        {
            _mouse = new Point(e.X, e.Y);
            _botBrowser.GetMouse().Move(e.X, e.Y);
            MouseHandler.MouseMove?.Invoke(sender, e);
        }

        public void BlockInput()
        {
            if (_input)
            {
                this.MouseMove -= WebProcessor_MouseMove;
                this.MouseUp -= WebProcessor_MouseUp;
                this.MouseDown -= WebProcessor_MouseDown;
                this.MouseWheel -= WebProcessor_MouseWheel;
                this.MouseClick -= WebProcessor_MouseClick;
                this.MouseEnter -= WebProcessor_MouseEnter;
                this.MouseLeave -= WebProcessor_MouseLeave;
                this.KeyPressed -= _form_KeyPress;
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
                this.Focus();
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

        public void OnPaint(Graphics g)
        {
            Draw?.Invoke(this, g);
        }

        public void OnRender(EventHandler<Graphics> handler)
        {
            Draw = handler;
        }

        public virtual void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressed?.Invoke(sender, e);
        }

        public void ShowDevTools()
        {
            _botBrowser.ShowDevTools();
        }

        public virtual void OnAddressChanged(object sender, DocumentAddressChangedEventArgs e)
        {

        }

        public virtual void OnDocumentLoad(object sender, DocumentLoadEventArgs e)
        {

        }

        public virtual void OnDocumentReady(object sender, DocumentReadyEventArgs e)
        {

        }
    }
}
