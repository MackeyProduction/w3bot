using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.interfaces;

namespace w3bot.database
{
    internal class User
    {
        internal IProxy Proxy;
        internal IUserAgent UserAgent;

        internal IProxy GetProxy()
        {
            return null;
        }

        internal void AddProxyConnection(string name, string ip, int port, string username, string password)
        {
            
        }

        internal IUserAgent GetUserAgent()
        {
            return null;
        }

        internal void AddUserAgent(IOperatingSystem operatingSystem, ISoftware software)
        {

        }
    }
}
