using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Linq;
using System.Windows.Forms;
using w3bot.Core.Processor;
using w3bot.Wrapper;

namespace w3bot.Script
{
    public class BotWindow : TabPage, IBotWindow
    {
        internal string _name;
        internal bool doubleBuffered = true;
        internal bool _doubleBuffered { get { return doubleBuffered; } set { doubleBuffered = false; } }
        internal bool isVanished = false, isClosed = false;
        internal IProcessor _processor;

        /// <summary>
        /// Creates a new BotWindow instance.
        /// </summary>
        /// <param name="name">The name of the bot window.</param>
        /// <param name="processor">The current processor instance.</param>
        internal BotWindow(string name, IProcessor processor)
        {
            DoubleBuffered = _doubleBuffered;
            _name = name;
            _processor = processor;
            Activate();
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
                //_bot.botTab.TabPages.Add(this);
                //_bot.botTab.SelectedTab = this;
                //_bot.botTab.SelectedTab.Text = _name;
            });
        }

        /// <summary>
        /// Hides the bot window but keeps it open. No input can be sent to this window.
        /// </summary>
        public void Vanish()
        {
            if (isClosed) throw new InvalidOperationException("The Botwindow is already destroyed. It can't be vanished.");
            if (isVanished) return;
            //Bot.ExeThreadSafe(delegate
            //{
                //_bot.botTab.TabPages.Remove(this);
                //int bots = _bot.botTab.TabPages.Count;
                //if (bots > 0) ((BotWindow)_bot.botTab.TabPages[bots - 1]).Activate();
                //isVanished = true;
            //});
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
                //_bot.botTab.SelectedTab = this;
                _processor.Activate();
            });
        }
    }
}
