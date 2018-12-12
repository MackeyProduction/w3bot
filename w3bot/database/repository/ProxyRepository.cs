using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Repository;

namespace w3bot.Database.Repository
{
    internal class ProxyRepository : RepositoryManager
    {
        protected override string FetchRepository()
        {
            return "Proxy";
        }
    }
}
