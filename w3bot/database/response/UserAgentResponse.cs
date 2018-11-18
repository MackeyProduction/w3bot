using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.factory;

namespace w3bot.database.response
{
    internal class UserAgentResponse : AbstractResponse
    {
        protected override AbstractResponseModel onSuccess(dynamic data)
        {
            return new UserAgentFactory(data);
        }
    }
}
