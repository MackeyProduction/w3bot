using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.interfaces;

namespace w3bot.database.repository
{
    internal class UserAgentRepository : RepositoryManager
    {
        protected override string FetchRepository()
        {
            return "UserAgent";
        }
    }
}
