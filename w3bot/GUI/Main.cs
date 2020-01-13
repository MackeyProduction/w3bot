﻿using System;
using System.Drawing;
using System.Windows.Forms;
using CefSharp;
using w3bot.Core;
using System.Globalization;
using w3bot.Input;
using System.Threading;
using System.Diagnostics;
using w3bot.Core.Bot;
using w3bot.Script;
using w3bot.Event;
using System.Collections.Generic;

namespace w3bot.GUI
{
    public partial class Main : Form
    {
        string title = "w3bot.org " + CoreInformation.programVersion.ToString("0.0", CultureInfo.InvariantCulture);
        private bool nextKill = false;  // flag to tell the next time the script will be killed without question
        private BotWindow botMain;
        private IExecutable _executable;
        private IScript runningScript;
        private Bot _bot;

        public Main(Bot bot)
        {
            InitializeComponent();
            
            this.Text = title + " - Idle...";

            _bot = bot;
            _executable = bot.GetDaemons();
            Bot._form = this;
            Status.AddConfiguration(bot.GetFormService());
            BotDirectories.CreateDirs();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //_login.ShowDialog();

            //if (!_login.StatusOk)
            //{
            //    this.Close();
            //    Application.Exit();
            //    return;
            //}
            
            Status.Log("Welcome to " + title);
            botMain = (BotWindow)_bot.CreateBrowserWindow("View");
            botMain.Open();

            blockToolStripMenuItem.PerformClick();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (runningScript != null && runningScript.CurrentState == Util.ScriptUtils.State.START)
            {
                if (MessageBox.Show("Do you want to close w3bot? A script is still running.", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cef.Shutdown();
                    runningScript.CurrentState = Util.ScriptUtils.State.STOP;
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
            new About().ShowDialog();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Account().ShowDialog();
        }

        private void sourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new Source(bot.botWindow._sourceCode, bot.botWindow._url).ShowDialog();
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
                var scriptManager = new Scriptmanager(new ScriptExecutor(new List<IScript>()), Script_started, Script_stopped);
                scriptManager.ShowDialog();
                //runningScript = _executable.GetExecutables<IScript>()[scriptManager.GetRunningExecutable()];
            }
            else
            {
                if (runningScript.CurrentState == Util.ScriptUtils.State.START)
                {
                    if (runningScript.CurrentState == Util.ScriptUtils.State.PAUSING)
                    {
                        runningScript.CurrentState = Util.ScriptUtils.State.RESUME;
                        this.Text = title + " - Script running...";
                        startToolStripMenuItem1.Text = "Pause";
                    }
                    else
                    {
                        runningScript.CurrentState = Util.ScriptUtils.State.PAUSING;
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
                    runningScript.CurrentState = Util.ScriptUtils.State.STOP;
                    Status.Warning("Script has been terminated");
                    return;
                }

                //if (MessageBox.Show("Are you sure you want to stop the running script?", "Stop Script?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    runningScript.onFinish();
                //    runningScript.onResume(); //resume script to make sure it doest stuck in the sleep loop
                //    nextKill = true;
                //    runningScriptList.Remove((int)bot.botTab.SelectedIndex);
                //    stopToolStripMenuItem.Text = "Stopping...";
                //    this.Text = title + " - Script stopping...";
                //}
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
            //bot.botWindow._chromiumBrowser.ShowDevTools();
        }

        private void magnifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            magnifierToolStripMenuItem.Checked = Core.Debug.toggle(Core.Debug.Magnifier);
        }

        private void updatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bot.botWindow._doubleBuffered = false;
            updatesToolStripMenuItem.Checked = Core.Debug.toggle(Core.Debug.NoDoubleBuffer);
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_executable.GetExecutables<IScript>() != null)
                {
                    if (tabControlMain.SelectedIndex < _executable.GetExecutables<IScript>().Count && tabControlMain.SelectedIndex != -1)
                    {
                        //runningScriptList.Execute((int)bot.botTab.SelectedIndex);
                        //runningScript = runningScriptList.GetItems()[bot.botTab.SelectedIndex];
                        //bot.botTab.Focus();
                        var tabId = tabControlMain.SelectedIndex;
                        runningScript = _executable.GetExecutables<IScript>()[tabId];
                        Script_started();
                    }
                    else
                    {
                        Script_stopped();
                    }
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
        }
    }
}
