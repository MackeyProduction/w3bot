using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace w3bot.GUI
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            labelVersion.Text = core.CoreInformation.programVersion.ToString("0.0", CultureInfo.InvariantCulture);
            labelAPIVersion.Text = core.CoreInformation.apiVersion.ToString("0.0", CultureInfo.InvariantCulture);
            labelBuild.Text = core.CoreInformation.build.ToString("0.0", CultureInfo.InvariantCulture);
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://w3bot.org");
        }
    }
}
