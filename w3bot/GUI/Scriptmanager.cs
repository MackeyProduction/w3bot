using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.core;
using w3bot.interfaces;
using w3bot.listener;

namespace w3bot.GUI
{
    public partial class Scriptmanager : Form
    {
        private Action script_started;
        private Action script_stopped;

        public Scriptmanager()
        {
            InitializeComponent();
        }

        public Scriptmanager(Action script_started, Action script_stopped)
        {
            InitializeComponent();
            this.script_started = script_started;
            this.script_stopped = script_stopped;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

        }

        private void Scriptmanager_Load(object sender, EventArgs e)
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
                        Core.ExeThreadSafe(delegate
                        {
                            script.Text = script.manifest.name;
                            script.SubItems.Add(script.manifest.targetApp);
                            script.SubItems.Add(script.manifest.description);
                            script.SubItems.Add(script.manifest.author);
                            script.SubItems.Add(script.manifest.version.ToString());
                            listViewScripts.Items.Add(script);
                        });
                    }
                    Core.ExeThreadSafe(delegate { progressBarLoad.Visible = false; });
                }
                else
                {
                    MessageBox.Show("No scripts found.");
                }
            })).Start();
        }
    }
}
