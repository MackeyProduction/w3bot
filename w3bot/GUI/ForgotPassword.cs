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
using w3bot.Database.Repository;
using w3bot.Service;

namespace w3bot.GUI
{
    public partial class ForgotPassword : Form
    {
        private IManager _serviceManager;

        public ForgotPassword(IManager serviceManager)
        {
            _serviceManager = serviceManager;

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
            var dbService = _serviceManager.Get("databaseService").Load() as RepositoryFactory;
            var userRepository = dbService.CreateRepository("User") as UserRepository;

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
