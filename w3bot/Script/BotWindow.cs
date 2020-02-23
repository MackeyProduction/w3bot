using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using w3bot.Core.Processor;
using w3bot.GUI.Service;

namespace w3bot.Script
{
    public class BotWindow : TabPage, IBotWindow
    {
        internal string _name;
        internal bool doubleBuffered = true;
        internal bool _doubleBuffered { get { return doubleBuffered; } set { doubleBuffered = false; } }
        internal bool isVanished = false, isClosed = false;
        internal IProcessor _processor;
        internal FormService _formService;
        internal TabControl _botTab;

        /// <summary>
        /// Creates a new BotWindow instance.
        /// </summary>
        /// <param name="name">The name of the bot window.</param>
        /// <param name="processor">The current processor instance.</param>
        internal BotWindow(string name, IProcessor processor, FormService formService)
        {
            DoubleBuffered = _doubleBuffered;
            _name = name;
            _processor = processor;
            _formService = formService;
            _botTab = (TabControl)_formService.GetFormControlByType(typeof(TabControl));
            Bot.ExeThreadSafe(delegate
            {
                this.Controls.Add(_processor.Panel);
            });
        }

        /// <summary>
        /// Loads the content in the current window. If no window is open calling this method has no effect.
        /// </summary>
        public void Load()
        {
            if (_botTab.TabCount < 2) throw new InvalidOperationException("The Botwindow isn't opened yet. Please use first the Open() method to open a new window.");
            Bot.ExeThreadSafe(delegate
            {
                _botTab.SelectedTab = _botTab.TabPages[_botTab.TabCount - 2];
                _processor.Activate();
                _botTab.Focus();
                _botTab.Invalidate();
            });
        }

        /// <summary>
        /// Reopens the window if it has been hidden before. If the window is already open calling this method has no effect.
        /// </summary>
        public void Open()
        {
            if (isClosed) throw new InvalidOperationException("The Botwindow is already destroyed. It can't be reopen.");
            Bot.ExeThreadSafe(delegate
            {
                isVanished = false;
                _botTab.TabPages.Add(this);
                _botTab.SelectedTab = this;
                _botTab.SelectedTab.Text = _name;
                _botTab.Invalidate();
                Activate();
            });
        }

        /// <summary>
        /// Hides the bot window but keeps it open. No input can be sent to this window.
        /// </summary>
        public void Vanish()
        {
            if (isClosed) throw new InvalidOperationException("The Botwindow is already destroyed. It can't be vanished.");
            if (isVanished) return;
            Bot.ExeThreadSafe(delegate
            {
                _botTab.TabPages.Remove(this);
                int bots = _botTab.TabPages.Count;
                if (bots > 0) ((BotWindow)_botTab.TabPages[bots - 1]).Activate();
                isVanished = true;
            });
        }

        /// <summary>
        /// Closes the window completely. The Window can't be reopen.
        /// </summary>
        public void Destroy()
        {
            if (isClosed) throw new InvalidOperationException("The Botwindow is already destroyed. It can't be closed.");
            Bot.ExeThreadSafe(delegate
            {
                //this.Controls.Remove(_processor);
                _processor.Destroy();
                _processor = null;
                Vanish();
                isClosed = true;
            });
        }

        /// <summary>
        /// Marks this window as the current one. All input will be sent to this window. The window will brought to the front.
        /// </summary>
        public void Activate()
        {
            if (isClosed) throw new InvalidOperationException("The Botwindow is already destroyed. It can't be reactivated.");
            Bot.ExeThreadSafe(delegate
            {
                //if (_bot.botWindow != null) _bot.botWindow._processor.BlockInput();
                _botTab.SelectedTab = this;
                _processor.Activate();
            });
        }
    }
}
