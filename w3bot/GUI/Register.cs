using System;
using System.ComponentModel;
using System.Windows.Forms;
using w3bot.Core.Database.Repository;
using w3bot.Service;

namespace w3bot.GUI
{
    public partial class Register : Form
    {
        private IManager _serviceManager;

        public Register(IManager serviceManager)
        {
            _serviceManager = serviceManager;

            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            registerWorker.DoWork += RegisterWorker_DoWork;
            registerWorker.RunWorkerCompleted += RegisterWorker_RunWorkerCompleted;
            registerWorker.RunWorkerAsync();
            btnRegister.Enabled = false;
        }

        private void RegisterWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnRegister.Enabled = true;
        }

        private void RegisterWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (tbPassword.Text == tbRepeatPassword.Text)
            {
                var dbService = _serviceManager.Get("databaseService").Load() as RepositoryFactory;
                var userRepository = dbService.CreateRepository("User") as UserRepository;

                if (userRepository.Register(tbUsername.Text, tbPassword.Text, tbEmail.Text))
                {
                    MessageBox.Show("Registration successful.");
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try later again.");
                }
            }
            else
            {
                MessageBox.Show("The password not fit with the second password.");
            }
        }
    }
}
