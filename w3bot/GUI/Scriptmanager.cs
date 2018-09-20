using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
    }
}
