using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.repository;
using w3bot.database.response;

namespace w3bot.Database.repository
{
    internal class UserAgentRepository : RepositoryManager
    {
        internal async Task<List<Dictionary<string, object>>> FetchAllByOperatingSystemName()
        {
            return await GetEntities("UserAgent", "agent/os/names", new UserAgentResponse());
        }

        internal async Task<List<Dictionary<string, object>>> FetchAllByOperatingSystemName(string name)
        {
            return await GetEntities("UserAgent", $"agent/os/name/{name}", new UserAgentResponse());
        }

        internal async Task<List<Dictionary<string, object>>> FetchAllByOperatingSystemNameAndVersion(string name, string version)
        {
            return await GetEntities("UserAgent", $"agent/os/name/{name}?version={version}", new UserAgentResponse());
        }

        protected override string FetchRepository()
        {
            return "UserAgent";
        }
    }
}
