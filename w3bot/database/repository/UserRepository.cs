using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.response;

namespace w3bot.database.repository
{
    internal class UserRepository : RepositoryManager
    {
        internal async Task<List<Dictionary<string, object>>> FetchUser(string username)
        {
            return await GetEntities("User", $"user/?name={username}", new UserResponse());
        }

        protected override string FetchRepository()
        {
            return "User";
        }
    }
}
