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
        private static string USER_ENDPOINT = ENDPOINT + "/user";
        
        public UserRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        internal T FetchUser<T>(string username)
        {
            return FetchOne<T>($"{USER_ENDPOINT}/?name={username}");
        }

        public T FetchById<T>(int id)
        {
            return FetchOne<T>($"{USER_ENDPOINT}/{id}");
        }

        public IList<T> FetchAll<T>()
        {
            return null;
        }

        internal T FetchOne<T>(string endpoint)
        {
            var receivedData = Fetch($"{endpoint}");

            if (receivedData.Result.IsSuccessStatusCode && receivedData.IsCompleted)
            {
                dynamic userResult = HttpContentAsJsonObject(receivedData.Result.Content).Result;

                if (userResult.data.count == 0)
                {
                    throw new HttpRequestException(String.Format("The user could not be found."));
                }

                var user = Hydrate(userResult.data.items[0]);

                return (T)Convert.ChangeType(user, typeof(Entity.User));
            }

            throw new HttpRequestException(String.Format("The user could not be fetched by the database."));
        }

        internal bool AddUserAgent(int userId, int userAgentId)
        {
            var values = new Dictionary<string, string>
                {
                    { "userId", userId.ToString() },
                    { "userAgentId", userAgentId.ToString() }
                };

            return SendPostRequestWithTokenCheck("user/agent", values);
        }

        internal bool AddProxy(int userId, int proxyId)
        {
            var values = new Dictionary<string, string>
                {
                    { "userId", userId.ToString() },
                    { "userAgentId", proxyId.ToString() }
                };

            return SendPostRequestWithTokenCheck("user/proxy", values);
        }

        internal bool Login(string username, string password)
        {
            try
            {
                var values = new Dictionary<string, string>
                {
                    { "username", username },
                    { "password", password }
                };

                var receivedData = Post($"{ENDPOINT}/login", values);
                
                if (receivedData.Result.IsSuccessStatusCode && receivedData.IsCompleted)
                {
                    dynamic loginResult = HttpContentAsJsonObject(receivedData.Result.Content).Result;

                    // fetch token
                    Token = (string)loginResult.token;

                    return true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return false;
        }

        internal bool Logout()
        {
            return SendPostRequestWithTokenCheck("logout");
        }

        internal bool Register(string username, string password, string email)
        {
            var values = new Dictionary<string, string>
                {
                    { "username", username },
                    { "password", password },
                    { "email", email }
                };

            return SendPostRequest("register", values);
        }

        internal bool ForgotPassword(string username)
        {
            var values = new Dictionary<string, string>
                {
                    { "username", username }
                };

            return SendPostRequest("forgot", values);
        }

        internal bool Refresh(string expiredToken)
        {
            var values = new Dictionary<string, string>
                {
                    { "expiredToken", expiredToken }
                };

            return SendPostRequest("refresh", values);
        }
        
        private bool SendPostRequest(string endpoint, Dictionary<string, string> values = null)
        {
            var receivedData = Post($"{ENDPOINT}/{endpoint}", values);

            if (receivedData.Result.IsSuccessStatusCode && receivedData.IsCompleted)
            {
                return true;
            }

            return false;
        }

        private bool SendPostRequestWithTokenCheck(string endpoint, Dictionary<string, string> values = null)
        {
            if (CheckTokenStatus(Token))
            {
                SendPostRequest(endpoint, values);
            }

            return false;
        }

        private Entity.User Hydrate(dynamic userResult)
        {
            var user = new Entity.User
            {
                Id = (int)userResult.id,
                Email = (string)userResult.email,
                Group = new Entity.Group
                {
                    Id = userResult.group.id,
                    Name = userResult.group.name,
                },
                Username = (string)userResult.username,
                Password = (string)userResult.password,
                RegisterDate = (DateTime)userResult.registerDate,
            };

            return user;
        }
    }
}
