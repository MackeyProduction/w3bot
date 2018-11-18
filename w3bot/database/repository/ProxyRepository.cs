using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database.repository
{
    internal class ProxyRepository : RepositoryManager
    {
        protected override string FetchRepository()
        {
            return "Proxy";
        }
    }
}
