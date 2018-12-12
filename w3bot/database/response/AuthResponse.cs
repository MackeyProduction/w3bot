using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Database.Factory;

namespace w3bot.Database.Response
{
    internal class AuthResponse : AbstractResponse
    {
        protected override AbstractResponseModel onSuccess(dynamic data)
        {
            return new AuthFactory(data);
        }
    }
}
