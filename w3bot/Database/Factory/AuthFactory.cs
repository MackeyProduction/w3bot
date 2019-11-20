using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Factory
{
    internal class AuthFactory : AbstractResponseModel
    {
        public AuthFactory(object data) : base(data)
        {
            base._data = data;
        }

        protected override Dictionary<string, object> fetch(dynamic data)
        {
            return new Dictionary<string, object>
            {
                { "response", (string)data.response },
                { "token", (string)data.token }
            };
        }
    }
}
