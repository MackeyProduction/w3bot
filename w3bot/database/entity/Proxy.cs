using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Interfaces;

namespace w3bot.Database.Entity
{
    internal class Proxy : IProxy
    {
        private int _id;
        private string _name, _ip, _username, _password;
        private int _port;

        internal Proxy()
        {
            _id = 0;
        }

        internal Proxy(int id, string name, string ip, int port, string username, string password)
        {
            _id = id;
            _name = name;
            _ip = name;
            _port = port;
            _username = username;
            _password = password;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string IP
        {
            get
            {
                return _ip;
            }

            set
            {
                _ip = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public int Port
        {
            get
            {
                return _port;
            }

            set
            {
                _port = value;
            }
        }

        public string ProxyName
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }
    }
}
