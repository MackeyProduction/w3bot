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
using w3bot.Database.Repository;
using w3bot.Service;

namespace w3bot.GUI
{
    public partial class Login : Form
    {
        private bool _statusOk = false;
        public bool StatusOk { get { return _statusOk; } set { _statusOk = value; } }
        private IManager _serviceManager;

        public Login(IManager serviceManager)
        {
            _serviceManager = serviceManager;

            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginWorker.DoWork += LoginWorker_DoWork;
            loginWorker.RunWorkerCompleted += LoginWorker_RunWorkerCompleted;
            loginWorker.RunWorkerAsync();
            btnLogin.Enabled = false;
        }

        private void LoginWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!loginWorker.CancellationPending && StatusOk)
            {
                Close();
            }
            else
            {
                btnLogin.Enabled = true;
            }
        }

        private void LoginWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var dbService = _serviceManager.Get("databaseService").Load() as RepositoryFactory;
            var user = dbService.CreateRepository("User") as UserRepository;

            if (!string.IsNullOrWhiteSpace(tbUsername.Text) && !string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                var result = user.Login(tbUsername.Text, tbPassword.Text);
                
                if (result)
                {
                    StatusOk = true;
                }
                else
                {
                    MessageBox.Show("User login failed. Check your user credentials.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid username and password.");
            }
        }

        private void linkLblCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Register(_serviceManager).Show();
        }

        private void linkLblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ForgotPassword(_serviceManager).Show();
        }
    }
}
