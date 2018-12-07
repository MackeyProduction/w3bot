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
    public partial class UserAgentSettings : Form
    {
        public UserAgentSettings()
        {
            InitializeComponent();
        }

        private void UserAgentSettings_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                var userAgentRepository = new UserAgentRepository();
                var userAgentInformation = userAgentRepository.GetRepositoryManager().FetchAll();

                core.Core.ExeThreadSafe(delegate
                {
                    try
                    {
                        dynamic value;

                        // fetch user agents
                        foreach (var userAgent in userAgentInformation)
                        {
                            userAgent.TryGetValue("entity", out value);
                            cbOperatingSystem.Items.Add(((IUserAgent)value).OperatingSystem.Name);
                        }
                    }
                    catch (Exception)
                    { }
                });
            })).Start();
        }
    }
}
