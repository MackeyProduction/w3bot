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
    public partial class LaplacianEdge : Form
    {
        public LaplacianEdge()
        {
            InitializeComponent();
        }

        private void numericApertureSize_ValueChanged(object sender, EventArgs e)
        {
            Debug.ApplyLaplacian((int)numericApertureSize.Value);
        }
    }
}
