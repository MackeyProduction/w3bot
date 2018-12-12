using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Database;

namespace w3bot.GUI
{
    public partial class Login : Form
    {
        private bool _statusOk = false;
        public bool StatusOk { get { return _statusOk; } set { _statusOk = value; } }

        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbUsername.Text) && !string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                try
                {
                    var user = new Auth();
                    var result = user.Login(tbUsername.Text, tbPassword.Text);

                    var myTask = result.ContinueWith(task =>
                    {
                        if (task.IsCompleted && task.Result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            StatusOk = true;
                        }
                    });
                    await myTask;

                    if (StatusOk)
                    {
                        Close();
                    }
                } catch (Exception) { }
            } else
            {
                MessageBox.Show("Please enter a valid username and password.");
            }
        }

        private void linkLblCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Register().Show();
        }

        private void linkLblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ForgotPassword().Show();
        }
    }
}
