using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database;
using w3bot.database.interfaces;
using w3bot.database.response;

namespace w3bot.Database
{
    internal class UserAgent
    {
        private UserAgentResponse _userAgentResponse;

        internal UserAgent()
        {
            if (_userAgentResponse == null)
            {
                _userAgentResponse = new UserAgentResponse();
            }
        }

        internal async void AddUserAgent(IUserAgent userAgent)
        {
            var values = new Dictionary<string, string>
                {
                    { "agent", userAgent.Agent },
                    { "softwareName", userAgent.Software.Name },
                    { "softwareVersion", userAgent.Software.Version },
                    { "softwareExtras", userAgent.Software.Extras.Info },
                    { "layoutEngine", userAgent.Software.LEName },
                    { "layoutEngineVersion", userAgent.Software.LEVersion },
                    { "osName", userAgent.OperatingSystem.Name },
                    { "osVersion", userAgent.OperatingSystem.Version }
                };

            var response = await Connection.PostRequest("agent", values);
            await _userAgentResponse.GetResponse(response);
        }
    }
}
