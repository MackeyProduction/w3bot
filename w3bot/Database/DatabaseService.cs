using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Repository;
using w3bot.Service;

namespace w3bot.Database
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
