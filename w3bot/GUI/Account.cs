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
using w3bot.database.interfaces;
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
                    var userAgentRepository = new UserAgentRepository();
                    var userAgentInformation = userAgentRepository.GetRepositoryManager().FetchAll();

                    var proxyRepository = new ProxyRepository();
                    var proxyInformation = proxyRepository.GetRepositoryManager().FetchAll();

                    core.Core.ExeThreadSafe(delegate
                    {
                        try
                        {
                            dynamic value;

                            // fetch proxies
                            foreach (var proxy in proxyInformation)
                            {
                                proxy.TryGetValue("entity", out value);
                                cbProxy.Items.Add(((IProxy)value).ProxyName);
                            }

                            // fetch user agents
                            foreach (var userAgent in userAgentInformation)
                            {
                                userAgent.TryGetValue("entity", out value);
                                cbUserAgent.Items.Add(((IUserAgent)value).Agent);
                            }
                        }
                        catch (Exception)
                        { }
                    });
                }
            });
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
