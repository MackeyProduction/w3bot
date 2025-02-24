﻿using System;
using System.Threading;
using System.Windows.Forms;
using w3bot.Core.Bot;
using w3bot.Core.Script;
using w3bot.Event;
using w3bot.Script;

namespace w3bot.GUI
{
    public partial class Scriptmanager : Form
    {
        private IExecutable _executable;
        private Action _start, _stop;
        private int _runningExecutables;

        public Scriptmanager()
        {
            InitializeComponent();
        }

        public Scriptmanager(IExecutable executable, Action start, Action stop)
        {
            InitializeComponent();
            _start = start;
            _stop = stop;
            _executable = executable;
        }

        public int GetRunningExecutable()
        {
            return _runningExecutables;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (listViewScripts.SelectedItems.Count == 1)
            {
                _executable.Bind(((ScriptItem)listViewScripts.SelectedItems[0]).script);
                _runningExecutables = _executable.GetExecutables<IScript>().Count;
                _executable.Execute(_runningExecutables);
                _start();
                this.Close();
            }
        }

        private void Scriptmanager_Load(object sender, EventArgs e)
        {
            labelScript.Text = BotDirectories.baseDir;
            Scriptloader scriptLoader = new Scriptloader();
            
            // starting a new thread to load scripts in background
            new Thread(new ThreadStart(delegate
            {
                var scripts = scriptLoader.LoadScripts();

                if (scripts != null)
                {
                    foreach (var script in scripts)
                    {
                        Bot.ExeThreadSafe(delegate
                        {
                            script.Text = script.manifest.name;
                            script.SubItems.Add(script.manifest.targetApp);
                            script.SubItems.Add(script.manifest.description);
                            script.SubItems.Add(script.manifest.author);
                            script.SubItems.Add(script.manifest.version.ToString());
                            listViewScripts.Items.Add(script);
                        });
                    }
                    Bot.ExeThreadSafe(delegate { progressBarLoad.Visible = false; });
                }
                else
                {
                    MessageBox.Show("No scripts found.");
                }
            })).Start();
        }
    }
}
