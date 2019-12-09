using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using w3bot.Core.Database;
using w3bot.Core.Database.Repository;

namespace w3bot.GUI
{
    public partial class Login : Form
    {
        private bool _statusOk = false;
        public bool StatusOk { get { return _statusOk; } set { _statusOk = value; } }
        private IRepositoryService _repositoryService;

        public Login(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;

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
            var user = _repositoryService.CreateRepository("User") as UserRepository;

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
            new Register(_repositoryService).Show();
        }

        private void linkLblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ForgotPassword(_repositoryService).Show();
        }
    }
}
