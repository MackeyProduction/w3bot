using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database
{
    internal class User
    {
        internal async void Login(string username, string password)
        {
            var values = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            var data = await Connection.PostRequest("login", values);
            dynamic result = JsonConvert.DeserializeObject(data);

            // set session id
            Connection.SESSION_ID = result.message;
        }

        internal void Logout()
        {
            Connection.SESSION_ID = null;
        }
    }
}
