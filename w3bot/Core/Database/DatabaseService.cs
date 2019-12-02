using System.Net.Http;
using w3bot.Core.Database.Repository;
using w3bot.Service;

namespace w3bot.Core.Database
{
    internal class DatabaseService : ILoadable
    {
        public object Load()
        {
            var httpClient = new HttpClient();
            var factory = new RepositoryFactory(httpClient);

            return factory;
        }
    }
}
