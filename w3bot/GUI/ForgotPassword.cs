﻿using Autofac;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using w3bot.Core.Database;
using w3bot.Core.Database.Repository;

namespace w3bot.GUI
{
    public partial class ForgotPassword : Form
    {
        private IRepositoryService _repositoryService;

        public ForgotPassword(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;

            InitializeComponent();
        }

        private void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            forgotPasswordWorker.DoWork += ForgotPasswordWorker_DoWork;
            forgotPasswordWorker.RunWorkerCompleted += ForgotPasswordWorker_RunWorkerCompleted;
            forgotPasswordWorker.RunWorkerAsync();
            btnRecoverPassword.Enabled = false;
        }

        private void ForgotPasswordWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnRecoverPassword.Enabled = true;
        }

        private void ForgotPasswordWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var userRepository = _repositoryService.CreateRepository("User") as UserRepository;

            if (userRepository.ForgotPassword(tbUsername.Text))
            {
                MessageBox.Show("In few minutes you will receive an email for password recovery.\nUse the link to recover your password.");
            }
            else
            {
                MessageBox.Show("Username not found.");
            }
        }
    }
}
