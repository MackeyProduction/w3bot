using System;
using System.Drawing;
using System.Windows.Forms;
using CefSharp;
using w3bot.Core;
using System.Globalization;
using w3bot.Input;
using System.Threading;
using System.Diagnostics;
using w3bot.Service;
using w3bot.Core.Bot;
using w3bot.Core.Database;

namespace w3bot.GUI
{
    internal partial class Main : Core.Core
    {
        string title = "w3bot.org " + CoreInformation.programVersion.ToString("0.0", CultureInfo.InvariantCulture);
        private bool nextKill = false;  // flag to tell the next time the script will be killed without question
        private BotWindow botMain;

        public Main()
        {
            InitializeComponent();
            
            this.Text = title + " - Idle...";
            Initialize(this, new Bot.Bot(), new FormControl(this, textBoxLog, tabControlMain));

            Initialize(this);
            BotDirectories.CreateDirs();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            var serviceManager = new ServiceManager();
            serviceManager.Set("databaseService", new DatabaseService());

            Login login = new Login(serviceManager);
            login.ShowDialog();

            if (!login.StatusOk)
            {
                this.Close();
                Application.Exit();
                return;
            }

            Status.Log("Welcome to " + title);
            botMain = bot.CreateBrowserWindow("View", "google.com");
            bot.Initialize(botMain);
            botMain.Open();

            Bot.Bot.AddConfiguration(this);
            blockToolStripMenuItem.PerformClick();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (runningScript != null && runningScript._running)
            {
                if (MessageBox.Show("Do you want to close w3bot? A script is still running.", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cef.Shutdown();
                    runningScript.onFinish();
                    runningScript.onKill();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                Cef.Shutdown();
            }
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
            new Thread(new ThreadStart(delegate
            {
                Tests.TestScript testScript = new Tests.TestScript();
                BotStub botStub = new BotStub(bot, testScript, Script_stopped);
                botStub.onStart();
            })).Start();
            new About().ShowDialog();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Account().ShowDialog();
        }

        private void sourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Source(bot.botWindow._sourceCode, bot.botWindow._url).ShowDialog();
        }

        private void allowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botMain._processor.AllowInput();

            allowToolStripMenuItem.Checked = true;
            blockToolStripMenuItem.Checked = false;
            inputToolStripMenuItem.Image = Resource1.keyboard;
        }

        private void blockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botMain._processor.BlockInput();
            botMain._processor.GetFocus();

            blockToolStripMenuItem.Checked = true;
            allowToolStripMenuItem.Checked = false;
            inputToolStripMenuItem.Image = Resource1.keyboard_delete;
        }

        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (runningScript == null)
            {
                new Scriptmanager(bot, Script_started, Script_stopped).ShowDialog();
            }
            else
            {
                if (runningScript._running)
                {
                    if (runningScript._pausing)
                    {
                        runningScript.onResume();
                        this.Text = title + " - Script running...";
                        startToolStripMenuItem1.Text = "Pause";
                    }
                    else
                    {
                        runningScript.onPause();
                        this.Text = title + " - Script paused...";
                        startToolStripMenuItem1.Text = "Resume";
                    }
                }
            }
        }

        private void Script_started()
        {
            startToolStripMenuItem1.Text = "Pause";
            this.Text = title + " - Script running...";
            stopToolStripMenuItem.Enabled = true;
            blockToolStripMenuItem.PerformClick();
            botMain._processor.GetFocus(); //make sure botting is possible by focusing the view
        }

        private void Script_stopped()
        {
            nextKill = false;
            startToolStripMenuItem1.Text = "Start";
            stopToolStripMenuItem.Text = "Stop";
            this.Text = title + " - Idle...";
            stopToolStripMenuItem.Enabled = false;
            runningScript = null;
        }

        

        private void mousePositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mousePositionToolStripMenuItem.Checked = Core.Debug.toggle(Core.Debug.MousePosition);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CompileScript().ShowDialog();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (runningScript != null)
            {
                if (nextKill)
                {
                    runningScript.onKill();
                    Status.Warning("Script has been terminated");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to stop the running script?", "Stop Script?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    runningScript.onFinish();
                    runningScript.onResume(); //resume script to make sure it doest stuck in the sleep loop
                    nextKill = true;
                    runningScriptList.Remove((int)bot.botTab.SelectedIndex);
                    stopToolStripMenuItem.Text = "Stopping...";
                    this.Text = title + " - Script stopping...";
                }
            }
        }

        private void visitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://w3bot.org");
        }

        private void pixelColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pixelColorToolStripMenuItem.Checked = Core.Debug.toggle(Core.Debug.PixelColor);
        }

        private void mouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mouseToolStripMenuItem.Checked = Core.Debug.toggle(Core.Debug.Mouse);
        }

        private void edgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cannyToolStripMenuItem.Checked = Core.Debug.toggle(Core.Debug.CannyEdges);
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sobelToolStripMenuItem.Checked = Core.Debug.toggle(Core.Debug.SobelEdges);
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            laplacianToolStripMenuItem.Checked = Core.Debug.toggle(Core.Debug.LaplacianEdges);
        }

        private void devToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bot.botWindow._chromiumBrowser.ShowDevTools();
        }

        private void magnifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            magnifierToolStripMenuItem.Checked = Core.Debug.toggle(Core.Debug.Magnifier);
        }

        private void updatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bot.botWindow._doubleBuffered = false;
            Bot.Bot.AddConfiguration(this);
            updatesToolStripMenuItem.Checked = Core.Debug.toggle(Core.Debug.NoDoubleBuffer);
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (runningScriptList != null)
                {
                    if (bot.botTab.SelectedIndex < runningScriptList.GetItems().Count && bot.botTab.SelectedIndex != -1)
                    {
                        runningScriptList.Execute((int)bot.botTab.SelectedIndex);
                        runningScript = runningScriptList.GetItems()[bot.botTab.SelectedIndex];
                        bot.botTab.Focus();
                        Script_started();
                    }
                    else
                    {
                        Script_stopped();
                    }
                }
            }
            catch (Exception) { }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
        }
    }
}
