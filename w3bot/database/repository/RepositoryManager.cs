using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.interfaces;
using w3bot.database.response;

namespace w3bot.database.repository
{
    internal abstract class RepositoryManager
    {
        private static Dictionary<string, IRepository> _factories;

        internal static async Task<Dictionary<string, IRepository>> GetFactory()
        {
            var entityHelper = new EntityMappingHelper();

            _factories = new Dictionary<string, IRepository>
                {
                    { "User", new RepositoryHelper(await entityHelper.GetEntities("User", "user", new UserResponse())) },
                    { "UserAgent", new RepositoryHelper(await entityHelper.GetEntities("UserAgent", "user/agent", new UserAgentResponse())) },
                    { "Proxy", new RepositoryHelper(await entityHelper.GetEntities("Proxy", "user/proxy", new ProxyResponse())) }
                };

            return _factories;
        }

        internal IRepository GetRepositoryManager()
        {
            var result = GetFactory().Result;

            return result[FetchRepository()];
        }

        protected abstract string FetchRepository();
    }
}
