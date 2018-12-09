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
    internal class User
    {
        private UserResponse _userResponse;

        internal User()
        {
            if (_userResponse == null)
            {
                _userResponse = new UserResponse();
            }
        }

        internal async void AddUserAgent(int userId, int userAgentId)
        {
            var values = new Dictionary<string, string>
                {
                    { "userId", userId.ToString() },
                    { "userAgentId", userAgentId.ToString() }
                };

            var response = await Connection.PostRequest("user/agent", values);
            await _userResponse.GetResponse(response);
        }

        internal async void AddProxy(int userId, int proxyId)
        {
            var values = new Dictionary<string, string>
                {
                    { "userId", userId.ToString() },
                    { "userAgentId", proxyId.ToString() }
                };

            var response = await Connection.PostRequest("user/proxy", values);
            await _userResponse.GetResponse(response);
        }
    }
}
