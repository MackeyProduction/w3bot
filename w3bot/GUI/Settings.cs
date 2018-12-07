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
using w3bot.database.interfaces;
using w3bot.database.repository;

namespace w3bot.GUI
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnAddProxy_Click(object sender, EventArgs e)
        {
            new ProxySettings().ShowDialog();
        }

        private void btnAddUserAgent_Click(object sender, EventArgs e)
        {
            new UserAgentSettings().ShowDialog();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
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
            })).Start();
        }
    }
}
