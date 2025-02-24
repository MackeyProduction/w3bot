﻿using System;
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
    public partial class SobelEdge : Form
    {
        public SobelEdge()
        {
            InitializeComponent();
        }

        private void numericXorder_ValueChanged(object sender, EventArgs e)
        {
            Debug.ApplySobel((int)numericXorder.Value, (int)numericYorder.Value, (int)numericApertureSize.Value);
        }

        private void numericYorder_ValueChanged(object sender, EventArgs e)
        {
            Debug.ApplySobel((int)numericXorder.Value, (int)numericYorder.Value, (int)numericApertureSize.Value);
        }

        private void numericApertureSize_ValueChanged(object sender, EventArgs e)
        {
            Debug.ApplySobel((int)numericXorder.Value, (int)numericYorder.Value, (int)numericApertureSize.Value);
        }
    }
}
