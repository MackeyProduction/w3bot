using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using w3bot.core;

namespace w3bot.GUI
{
    internal partial class Main : Core
    {
        public ChromiumWebBrowser chromeBrowser;

        public Main()
        {
            InitializeComponent();

            mainWindow = this;
            tabs = tabControlMain;
            logbox = textBoxLog;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            bot.CreateBrowserWindow("View", "google.com");
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void logboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logboxToolStripMenuItem.Checked = !logboxToolStripMenuItem.Checked;
            tabControlMain.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            if (!textBoxLog.Visible)
            {
                this.Size = new Size(this.Width, this.Height + textBoxLog.Height);
                textBoxLog.Show();
            }
            else
            {
                this.Size = new Size(this.Width, this.Height - textBoxLog.Height);
                textBoxLog.Hide();
            }

            tabControlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Account().ShowDialog();
        }

        private void sourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Source().ShowDialog();
        }
    }
}
