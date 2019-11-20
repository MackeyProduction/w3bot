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
using w3bot.Database.Entity;
using w3bot.Database.Repository;
using w3bot.Database.Response;

namespace w3bot.GUI
{
    public partial class UserAgentSettings : Form
    {
        private static UserAgentRepository _userAgentRepository;
        private static List<Dictionary<string, object>> operatingSystemVersionItems = new List<Dictionary<string, object>>();
        private static UserAgent _userAgent;

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

                Core.Core.ExeThreadSafe(delegate
                {
                    try
                    {
                        dynamic value;

                        // fetch user agents
                        foreach (var os in userAgentInformation)
                        {
                            os.TryGetValue("entity", out value);
                            cbOperatingSystem.Items.Add(((UserAgent)value).OperatingSystem.Name);
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

                    Core.Core.ExeThreadSafe(delegate
                    {
                        try
                        {
                            dynamic value;

                            // fetch user agents
                            foreach (var userAgent in operatingSystemItems)
                            {
                                userAgent.TryGetValue("entity", out value);
                                cbOperatingSystemVersion.Items.Add(((UserAgent)value).OperatingSystem.Version);
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

                    Core.Core.ExeThreadSafe(delegate
                    {
                        try
                        {
                            dynamic value;

                            // fetch user agents
                            foreach (var userAgent in operatingSystemVersionItems)
                            {
                                userAgent.TryGetValue("entity", out value);
                                cbBrowser.Items.Add(((UserAgent)value).Software.Name);
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
                    cbBrowserVersion.Items.Add(((UserAgent)os.Value).Software.Version);
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
                    cbLayoutEngine.Items.Add(((UserAgent)os.Value).Software.LEName);
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
                    cbLayoutEngineVersion.Items.Add(((UserAgent)os.Value).Software.LEVersion);
                }
            }
        }

        private void cbLayoutEngineVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLayoutEngineVersion.SelectedIndex != -1)
            {
                btnSave.Enabled = true;
                _userAgent = ((UserAgent)operatingSystemVersionItems[cbBrowser.SelectedIndex].Where(item => ((UserAgent)item.Value).OperatingSystem.Name == cbOperatingSystem.Text && ((UserAgent)item.Value).Software.Name == cbBrowser.Text && ((UserAgent)item.Value).Software.LEName == cbLayoutEngine.Text).SingleOrDefault().Value);
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
