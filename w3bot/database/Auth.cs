﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.factory;
using w3bot.database.response;

namespace w3bot.database
{
    internal class Auth
    {
        private static AuthResponse _authResponse;

        static Auth()
        {
            if (_authResponse == null)
            {
                _authResponse = new AuthResponse();
            }
        }

        internal async Task Login(string username, string password)
        {
            try
            {
                var values = new Dictionary<string, string>
                {
                    { "username", username },
                    { "password", password }
                };

                var response = await Connection.PostRequest("login", values, true);
                var result = await _authResponse.GetResponse(response);
                var dictionary = result.FetchResponseData();

                // fetch token
                Connection.TOKEN = (string)dictionary["token"];
            }
            catch (Exception) { }
        }

        internal async void Logout()
        {
            var values = new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + Connection.TOKEN },
                };

            var response = await Connection.PostRequest("logout", values, true);
            //_authFactory.GetLogoutResponse(response);
        }
    }
}
