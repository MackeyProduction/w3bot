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
using w3bot.database;
using w3bot.database.interfaces;
using w3bot.database.repository;
using w3bot.database.response;
using w3bot.Database;
using w3bot.Database.repository;

namespace w3bot.GUI
{
    public partial class UserAgentSettings : Form
    {
        private static UserAgentRepository _userAgentRepository;
        private static List<Dictionary<string, object>> operatingSystemVersionItems = new List<Dictionary<string, object>>();
        private static IUserAgent _userAgent;

        public UserAgentSettings()
        {
            InitializeComponent();

            _userAgentRepository = new UserAgentRepository();
        }

        private void UserAgentSettings_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                var userAgentInformation = _userAgentRepository.FetchAllByOperatingSystemName().Result;
                var operatingSystemVersions = new List<Dictionary<string, object>>();

                core.Core.ExeThreadSafe(delegate
                {
                    try
                    {
                        dynamic value;

                        // fetch user agents
                        foreach (var os in userAgentInformation)
                        {
                            os.TryGetValue("entity", out value);
                            cbOperatingSystem.Items.Add(((IUserAgent)value).OperatingSystem.Name);
                        }
                    }
                    catch (Exception)
                    { }
                });
            })).Start();
        }

        private void cbOperatingSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOperatingSystem.SelectedIndex != -1)
            {
                var operatingSystem = cbOperatingSystem.Items[cbOperatingSystem.SelectedIndex];

                new Thread(new ThreadStart(delegate
                {
                    var operatingSystemItems = _userAgentRepository.FetchAllByOperatingSystemName(operatingSystem.ToString()).Result;

                    core.Core.ExeThreadSafe(delegate
                    {
                        try
                        {
                            dynamic value;

                            // fetch user agents
                            foreach (var userAgent in operatingSystemItems)
                            {
                                userAgent.TryGetValue("entity", out value);
                                cbOperatingSystemVersion.Items.Add(((IUserAgent)value).OperatingSystem.Version);
                            }
                        }
                        catch (Exception)
                        { }
                    });
                })).Start();
            }
        }

        private void cbOperatingSystemVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOperatingSystemVersion.SelectedIndex != -1)
            {
                var operatingSystemName = cbOperatingSystem.Items[cbOperatingSystem.SelectedIndex];
                var operatingSystemVersion = cbOperatingSystemVersion.Items[cbOperatingSystemVersion.SelectedIndex];

                new Thread(new ThreadStart(delegate
                {
                    operatingSystemVersionItems = _userAgentRepository.FetchAllByOperatingSystemNameAndVersion(operatingSystemName.ToString(), operatingSystemVersion.ToString()).Result;

                    core.Core.ExeThreadSafe(delegate
                    {
                        try
                        {
                            dynamic value;

                            // fetch user agents
                            foreach (var userAgent in operatingSystemVersionItems)
                            {
                                userAgent.TryGetValue("entity", out value);
                                cbBrowser.Items.Add(((IUserAgent)value).Software.Name);
                            }
                        }
                        catch (Exception)
                        { }
                    });
                })).Start();
            }
        }

        private void cbBrowser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBrowser.SelectedIndex != -1)
            {
                var dictionary = FetchItems(operatingSystemVersionItems);
                foreach (var os in dictionary)
                {
                    cbBrowserVersion.Items.Add(((IUserAgent)os.Value).Software.Version);
                }
            }
        }

        private void cbBrowserVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBrowserVersion.SelectedIndex != -1)
            {
                var dictionary = FetchItems(operatingSystemVersionItems);
                foreach (var os in dictionary)
                {
                    cbLayoutEngine.Items.Add(((IUserAgent)os.Value).Software.LEName);
                }
            }
        }

        private void cbLayoutEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLayoutEngine.SelectedIndex != -1)
            {
                var dictionary = FetchItems(operatingSystemVersionItems);
                foreach (var os in dictionary)
                {
                    cbLayoutEngineVersion.Items.Add(((IUserAgent)os.Value).Software.LEVersion);
                }
            }
        }

        private void cbLayoutEngineVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLayoutEngineVersion.SelectedIndex != -1)
            {
                btnSave.Enabled = true;
                _userAgent = ((IUserAgent)operatingSystemVersionItems[cbBrowser.SelectedIndex].Where(item => ((IUserAgent)item.Value).OperatingSystem.Name == cbOperatingSystem.Text && ((IUserAgent)item.Value).Software.Name == cbBrowser.Text && ((IUserAgent)item.Value).Software.LEName == cbLayoutEngine.Text).SingleOrDefault().Value);
                lblUserAgent.Text += _userAgent.Agent;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //var userPost = new User();
            //var userRepository = new UserRepository();
            //dynamic payload = userRepository.GetRepositoryManager().FetchAll()[0]["payload"];
            //var username = payload.username;
            //dynamic fetchedUser = userRepository.FetchUser("").Result[0]["data"];
            //var result = fetchedUser.items.id;

            //userPost.AddUserAgent(result, _userAgent.Id);
        }

        private Dictionary<string, object> FetchItems(List<Dictionary<string, object>> data)
        {
            var dictionary = new Dictionary<string, object>();
            foreach (var keyValuePairs in data)
            {
                foreach (var kv in keyValuePairs)
                {
                    dictionary.Add(kv.Key, kv.Value);
                }
            }

            return dictionary;
        }
    }
}
