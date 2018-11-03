using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.database.factory;

namespace w3bot.database.response
{
    internal class AuthResponse : AbstractResponse
    {
        protected override AbstractResponseModel onSuccess(dynamic data)
        {
            return new AuthFactory(data);
        }
    }
}
