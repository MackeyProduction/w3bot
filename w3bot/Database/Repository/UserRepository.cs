using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Repository
{
    internal class UserRepository : AbstractHttpRepository, IRepository
    {
        public UserRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        internal IList<T> FetchUser<T>(string username)
        {
            return null;
            //return await GetEntities("User", $"user/?name={username}", new UserResponse());
        }

        public T FetchById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> FetchAll<T>()
        {
            throw new NotImplementedException();
        }

        //internal async void AddUserAgent(int userId, int userAgentId)
        //{
        //    var values = new Dictionary<string, string>
        //        {
        //            { "userId", userId.ToString() },
        //            { "userAgentId", userAgentId.ToString() }
        //        };

        //    var response = await Connection.PostRequest("user/agent", values);
        //    await _userResponse.GetResponse(response);
        //}

        //internal async void AddProxy(int userId, int proxyId)
        //{
        //    var values = new Dictionary<string, string>
        //        {
        //            { "userId", userId.ToString() },
        //            { "userAgentId", proxyId.ToString() }
        //        };

        //    var response = await Connection.PostRequest("user/proxy", values);
        //    await _userResponse.GetResponse(response);
        //}

        internal async Task<HttpResponseMessage> Login(string username, string password)
        {
            //try
            //{
            //    var values = new Dictionary<string, string>
            //    {
            //        { "username", username },
            //        { "password", password }
            //    };

            //    var response = await Connection.PostRequest("login", values, true);
            //    var result = await _authResponse.GetResponse(response);
            //    var dictionary = result.FetchResponseData();

            //    // fetch token
            //    Connection.TOKEN = (string)dictionary["token"];

            //    return response;
            //}
            //catch (Exception) { }

            return null;
        }

        internal async void Logout()
        {
            //await Connection.PostRequest("logout", GetBearerHeader(), true);
            //_authFactory.GetLogoutResponse(response);
        }

        internal async void Register(string username, string password, string email)
        {
            //var values = new Dictionary<string, string>
            //    {
            //        { "username", username },
            //        { "password", password },
            //        { "email", email }
            //    };

            //var response = await Connection.PostRequest("register", values);
            //await _authResponse.GetResponse(response);
        }

        internal async void ForgotPassword(string username)
        {
            //var values = new Dictionary<string, string>
            //    {
            //        { "username", username }
            //    };

            //var response = await Connection.PostRequest("forgot", values);
            //await _authResponse.GetResponse(response);
        }

        internal async void Refresh(string expiredToken)
        {
            //var values = new Dictionary<string, string>
            //    {
            //        { "expiredToken", expiredToken }
            //    };

            //var response = await Connection.PostRequest("refresh", values);
            //await _authResponse.GetResponse(response);
        }

        internal Dictionary<string, string> GetBearerHeader(string token)
        {
            var values = new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + token },
                };

            return values;
        }

    }
}
