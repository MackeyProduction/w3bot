using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Core;

namespace w3bot.GUI
{
    internal partial class CannyEdge : Form
    {
        public CannyEdge()
        {
            InitializeComponent();
        }

        private void numericThreshold_ValueChanged(object sender, EventArgs e)
        {
            Debug.ApplyCanny((double)numericThreshold.Value, (double)numericThresholdLink.Value);
        }

        private void numericThresholdLink_ValueChanged(object sender, EventArgs e)
        {
            Debug.ApplyCanny((double)numericThreshold.Value, (double)numericThresholdLink.Value);
        }
    }
}
