﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace w3bot.listener
{
    interface IKeyPressListener
    {
        void KeyPress(object sender, KeyPressEventArgs e);
    }
}
