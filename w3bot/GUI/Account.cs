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
using w3bot.database.repository;

namespace w3bot.GUI
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = new Auth();
            var result = user.Login(tbUsername.Text, tbPassword.Text);

            // fetch user information
            result.ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    var userRepository = new UserRepository();
                    var userInformation = userRepository.GetRepositoryManager().FetchAll();
                }
            });
        }
    }
}
