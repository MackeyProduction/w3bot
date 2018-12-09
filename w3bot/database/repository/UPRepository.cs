using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database.repository
{
    internal class UPRepository : RepositoryManager
    {
        protected override string FetchRepository()
        {
            return "UP";
        }
    }
}
