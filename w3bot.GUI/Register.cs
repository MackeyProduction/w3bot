using Autofac;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using w3bot.Core.Database;
using w3bot.Core.Database.Repository;

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
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var dbService = scope.Resolve<IRepositoryService>();
                var userRepository = dbService.CreateRepository("User") as UserRepository;

                if (tbPassword.Text == tbRepeatPassword.Text)
                {             
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
}
