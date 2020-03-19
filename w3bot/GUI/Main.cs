using System;
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
using w3bot.Core.Processor;
using w3bot.Listener;

namespace w3bot.GUI
{
    public partial class Main : Form
    {
        string title = "w3bot.org " + CoreInformation.programVersion.ToString("0.0", CultureInfo.InvariantCulture);
        private bool nextKill = false;  // flag to tell the next time the script will be killed without question
        private BotWindow botMain;
        private IExecutable _executable;
        private IProcessor _processor;
        private IScript runningScript;
        private Core.Debug _debug;
        private Bot _bot;
        private TabPage _tabPage;
        internal delegate void Drawable(Graphics g);
        internal static event Drawable paintings = delegate { };

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
            //Login();
            NotSupportedYet();

            Status.Log("Welcome to " + title);
            botMain = (BotWindow)_bot.CreateWindow("View", Core.Utilities.ProcessorType.BrowserProcessor);
            botMain.Open();

            _tabPage = CreateEmptyTabPage("addingTabPage");
            tabControlMain.TabPages.Add(_tabPage);

            _processor = _bot.GetCoreService().GetProcessors().GetProcessor(Core.Utilities.ProcessorType.BrowserProcessor);
            LoadDebugPaint(_processor);

            KeyPress += Main_KeyPress;

            blockToolStripMenuItem.PerformClick();
        }

        private void Login()
        {
            var login = new Login(_bot.GetCoreService().GetRepositories());
            login.ShowDialog();

            if (!login.StatusOk)
            {
                this.Close();
                Application.Exit();
                return;
            }
        }

        private void NotSupportedYet()
        {
            settingsToolStripMenuItem.Visible = false;
            updatesToolStripMenuItem.Visible = false;
            magnifierToolStripMenuItem.Visible = false;
            accountToolStripMenuItem.Visible = false;
            toolStripSeparator1.Visible = false;
        }

        private void LoadDebugPaint(IProcessor processor)
        {
            _debug = new Core.Debug(processor);
        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            _processor.OnKeyPress(sender, e);
        }

        private TabPage CreateEmptyTabPage(string name)
        {
            var tabPage = new TabPage
            {
                Text = "+",
                Name = name
            };

            return tabPage;
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
            if (_processor is WebProcessor)
            {
                var webProcessor = (WebProcessor)_processor;
                new Source(webProcessor.SourceCode, webProcessor.Url).ShowDialog();
            }
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
                var scriptManager = new Scriptmanager(_executable, Script_started, Script_stopped);
                scriptManager.ShowDialog();

                var executableCount = scriptManager.GetRunningExecutable();
                if (executableCount != 0)
                    runningScript = _executable.GetExecutables<IScript>()[scriptManager.GetRunningExecutable() - 1];
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
            mousePositionToolStripMenuItem.Checked = Core.Debug.Toggle(Core.Debug.MousePosition);
            _processor.OnRender(_debug.OnDebugPaint);
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

                if (MessageBox.Show("Are you sure you want to stop the running script?", "Stop Script?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    runningScript.CurrentState = Util.ScriptUtils.State.STOP;
                    runningScript.CurrentState = Util.ScriptUtils.State.RESUME;
                    nextKill = true;
                    _executable.GetExecutables<IScript>().Remove(runningScript);
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
            pixelColorToolStripMenuItem.Checked = Core.Debug.Toggle(Core.Debug.PixelColor);
            _processor.OnRender(_debug.OnDebugPaint);
        }

        private void mouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mouseToolStripMenuItem.Checked = Core.Debug.Toggle(Core.Debug.Mouse);
            _processor.OnRender(_debug.OnDebugPaint);
        }

        private void edgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cannyToolStripMenuItem.Checked = Core.Debug.Toggle(Core.Debug.CannyEdges);
            _processor.OnRender(_debug.OnDebugPaint);
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sobelToolStripMenuItem.Checked = Core.Debug.Toggle(Core.Debug.SobelEdges);
            _processor.OnRender(_debug.OnDebugPaint);
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            laplacianToolStripMenuItem.Checked = Core.Debug.Toggle(Core.Debug.LaplacianEdges);
            _processor.OnRender(_debug.OnDebugPaint);
        }

        private void devToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_processor is WebProcessor)
            {
                var webProcessor = (WebProcessor)_processor;
                webProcessor.ShowDevTools();
            }
        }

        private void magnifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            magnifierToolStripMenuItem.Checked = Core.Debug.Toggle(Core.Debug.Magnifier);
        }

        private void updatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bot.botWindow._doubleBuffered = false;
            updatesToolStripMenuItem.Checked = Core.Debug.Toggle(Core.Debug.NoDoubleBuffer);
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var tabId = tabControlMain.SelectedIndex;
                _processor = _bot.GetCoreService().GetProcessors().GetById(tabId - 1) ?? _processor;

                LoadDebugPaint(_processor);

                if (tabControlMain.SelectedTab == _tabPage)
                {
                    _bot.CreateWindow("View", Core.Utilities.ProcessorType.BrowserProcessor).Open();

                    for (int i = 0; i < tabControlMain.TabPages.Count; i++)
                    {
                        SwapTabPages(_tabPage, tabControlMain.TabPages[i]);
                    }
                    tabControlMain.SelectedTab = tabControlMain.TabPages[tabControlMain.TabPages.Count - 2];
                }

                if (_executable.GetExecutables<IScript>() != null)
                {
                    if (tabControlMain.SelectedIndex < _executable.GetExecutables<IScript>().Count && tabControlMain.SelectedIndex != -1)
                    {
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

        private void SwapTabPages(TabPage tabPageOne, TabPage tabPageTwo)
        {
            int tp1Index = tabControlMain.TabPages.IndexOf(tabPageOne);
            int tp2Index = tabControlMain.TabPages.IndexOf(tabPageTwo);
            tabControlMain.TabPages[tp1Index] = tabPageTwo;
            tabControlMain.TabPages[tp2Index] = tabPageOne;
        }
    }
}
