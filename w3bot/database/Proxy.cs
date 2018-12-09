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
    internal class Proxy
    {
        private ProxyResponse _proxyResponse;

        internal Proxy()
        {
            if (_proxyResponse == null)
            {
                _proxyResponse = new ProxyResponse();
            }
        }

        internal async void AddProxy(IProxy proxy)
        {
            var values = new Dictionary<string, string>
                {
                    { "name", proxy.ProxyName },
                    { "ip", proxy.IP },
                    { "port", proxy.Port.ToString() },
                    { "username", proxy.Username },
                    { "password", proxy.Password }
                };

            var response = await Connection.PostRequest("proxy", values);
            await _proxyResponse.GetResponse(response);
        }
    }
}
