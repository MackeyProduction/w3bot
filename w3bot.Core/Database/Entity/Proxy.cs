using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Core.Database.Entity
{
    internal class Proxy
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string ProxyName { get; set; }
        public string Username { get; set; }
    }
}
