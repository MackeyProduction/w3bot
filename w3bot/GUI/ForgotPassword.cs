using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.database;

namespace w3bot.GUI
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            var auth = new Auth();
            auth.ForgotPassword(tbUsername.Text);
        }
    }
}
