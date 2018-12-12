using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Database;

namespace w3bot.GUI
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text == tbRepeatPassword.Text)
            {
                var auth = new Auth();
                auth.Register(tbUsername.Text, tbPassword.Text, tbEmail.Text);
            } else
            {
                MessageBox.Show("The password not fit with the second password.");
            }
        }
    }
}
