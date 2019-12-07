using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using w3bot.Core.Database.Repository;
using w3bot.Core.Utilities;

namespace w3bot.Core.Database
{
    public class RepositoryService : IRepositoryService
    {
        private IEnumerable<IRepository> _repositories;

        public RepositoryService(IEnumerable<IRepository> repositories)
        {
            _repositories = repositories;
        }

        public IRepository CreateRepository(string repositoryName)
        {
            return _repositories.Single(item => item.IsValid(repositoryName));
        }
    }
}
