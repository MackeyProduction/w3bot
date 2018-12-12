using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Helper;
using w3bot.Database.Interfaces;
using w3bot.Database.Response;

namespace w3bot.Database.Repository
{
    internal abstract class RepositoryManager : EntityMappingHelper
    {
        private static Dictionary<string, IRepository> _factories;
        private static EntityMappingHelper _entityHelper;

        internal RepositoryManager()
        {
            _entityHelper = this;
        }

        internal static async Task<Dictionary<string, IRepository>> GetFactory()
        {
            if (_factories == null)
            {
                _factories = new Dictionary<string, IRepository>
                {
                    { "User", new RepositoryHelper(await _entityHelper.GetEntities("User", "user", new UserResponse())) },
                    { "UUA", new RepositoryHelper(await _entityHelper.GetEntities("UserAgent", "user/agent", new UserAgentResponse())) },
                    { "UP", new RepositoryHelper(await _entityHelper.GetEntities("Proxy", "user/proxy", new ProxyResponse())) },
                    { "UserAgent", new RepositoryHelper(await _entityHelper.GetEntities("UserAgent", "agent", new UserAgentResponse())) },
                    { "Proxy", new RepositoryHelper(await _entityHelper.GetEntities("Proxy", "proxy", new ProxyResponse())) }
                };
            }

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
