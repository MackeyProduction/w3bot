using System;
using System.Threading;
using System.Windows.Forms;
using w3bot.Core.Bot;
using w3bot.Core.Script;
using w3bot.Evt.Handler;

namespace w3bot.GUI
{
    public partial class Scriptmanager : Form
    {
        private Bot.Bot _bot;
        private Action _start, _stop;

        public Scriptmanager()
        {
            InitializeComponent();
        }

        public Scriptmanager(Bot.Bot bot, Action start, Action stop)
        {
            InitializeComponent();
            _start = start;
            _stop = stop;
            _bot = bot;
        }

        private void buttonStart_Click(object sender, System.EventArgs e)
        {
            if (listViewScripts.SelectedItems.Count == 1)
            {
                TaskScheduler.Create = new TaskScheduler(_bot);
                var taskScheduler = TaskScheduler.Create; 
                taskScheduler.Bind(new BotStub(_bot, ((ScriptItem)listViewScripts.SelectedItems[0]).script, _stop));
                taskScheduler.Execute(_bot.botTab.SelectedIndex);
                _start();
                this.Close();
            }
        }

        private void Scriptmanager_Load(object sender, System.EventArgs e)
        {
            Scriptloader scriptLoader = new Scriptloader();
            
            // starting a new thread to load scripts in background
            new Thread(new ThreadStart(delegate
            {
                var scripts = scriptLoader.LoadScripts();

                if (scripts != null)
                {
                    foreach (var script in scripts)
                    {
                        Core.Core.ExeThreadSafe(delegate
                        {
                            script.Text = script.manifest.name;
                            script.SubItems.Add(script.manifest.targetApp);
                            script.SubItems.Add(script.manifest.description);
                            script.SubItems.Add(script.manifest.author);
                            script.SubItems.Add(script.manifest.version.ToString());
                            listViewScripts.Items.Add(script);
                        });
                    }
                    Core.Core.ExeThreadSafe(delegate { progressBarLoad.Visible = false; });
                }
                else
                {
                    MessageBox.Show("No scripts found.");
                }
            })).Start();
        }
    }
}
