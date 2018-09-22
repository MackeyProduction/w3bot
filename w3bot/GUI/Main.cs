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
using System.Globalization;
using w3bot.evt;

namespace w3bot.GUI
{
    internal partial class Main : Core
    {
        string title = "w3bot.org " + CoreInformation.programVersion.ToString("0.0", CultureInfo.InvariantCulture);

        public Main()
        {
            InitializeComponent();
            
            mainWindow = this;
            tabs = tabControlMain;
            logbox = textBoxLog;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Status.Log("Welcome to " + title);
            var botMain = bot.CreateBrowserWindow("View", "google.com");
            bot.Initialize(botMain);
            botMain.Open();
            Mouse.Move(200, 200);
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

        private void allowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allowToolStripMenuItem.Checked = true;
            blockToolStripMenuItem.Checked = false;
            inputToolStripMenuItem.Image = Resource1.keyboard;
        }

        private void blockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blockToolStripMenuItem.Checked = true;
            allowToolStripMenuItem.Checked = false;
            inputToolStripMenuItem.Image = Resource1.keyboard_delete;
        }

        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Scriptmanager(Script_started, Script_stopped).ShowDialog();
        }

        private void Script_started()
        {
            startToolStripMenuItem1.Text = "Pause";
            this.Text = title + " - Script running...";
            stopToolStripMenuItem.Enabled = true;
            blockToolStripMenuItem.PerformClick();
            //Core.bot.GetFocus(); //make sure botting is possible by focusing the view
        }

        private void Script_stopped()
        {
            //nextKill = false;
            startToolStripMenuItem1.Text = "Start";
            stopToolStripMenuItem.Text = "Stop";
            this.Text = title + " - Idle...";
            stopToolStripMenuItem.Enabled = false;
            //Core.runningScript = null;
        }

        private void mousePositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mousePositionToolStripMenuItem.Checked = core.Debug.toggle(core.Debug.MousePosition);
        }
    }
}
