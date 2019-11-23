using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Repository
{
    internal class RepositoryFactory
    {
        private HttpClient _httpClient;

        internal RepositoryFactory(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        internal IRepository CreateRepository(string repositoryName)
        {
            switch (repositoryName)
            {
                case "Proxy":
                    return new ProxyRepository(_httpClient);
                case "User":
                    return new UserRepository(_httpClient);
                case "UserAgent":
                    return new UserAgentRepository(_httpClient);
                case "UP":
                    return new UPRepository(_httpClient);
                case "UUA":
                    return new UUARepository(_httpClient);
            }

            throw new ArgumentException(String.Format("The repository by the name %s does not exist or the given name is invalid.", repositoryName));
        } 
    }
}
