using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        internal async Task<HttpResponseMessage> Login(string username, string password)
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

                return response;
            }
            catch (Exception) { }

            return null;
        }

        internal async void Logout()
        {
            await Connection.PostRequest("logout", GetBearerHeader(), true);
            //_authFactory.GetLogoutResponse(response);
        }

        internal async void Register(string username, string password, string email)
        {
            var values = new Dictionary<string, string>
                {
                    { "username", username },
                    { "password", password },
                    { "email", email }
                };

            var response = await Connection.PostRequest("register", values);
            await _authResponse.GetResponse(response);
        }

        internal async void ForgotPassword(string username)
        {
            var values = new Dictionary<string, string>
                {
                    { "username", username }
                };

            var response = await Connection.PostRequest("forgot", values);
            await _authResponse.GetResponse(response);
        }

        internal async void Refresh(string expiredToken)
        {
            var values = new Dictionary<string, string>
                {
                    { "expiredToken", expiredToken }
                };

            var response = await Connection.PostRequest("refresh", values);
            await _authResponse.GetResponse(response);
        }

        internal Dictionary<string, string> GetBearerHeader()
        {
            var values = new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + Connection.TOKEN },
                };

            return values;
        }
    }
}
