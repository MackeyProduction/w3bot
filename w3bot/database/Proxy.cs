using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database
{
    internal class Proxy
    {
        private string _name, _ip, _username, _password;
        private int _port;

        internal Proxy(string name, string ip, int port, string username, string password)
        {
            _name = name;
            _ip = name;
            _port = port;
            _username = username;
            _password = password;
        }
    }
}
