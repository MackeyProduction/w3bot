using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Repository;

namespace w3bot.Database.Repository
{
    internal class UserAgentRepository : AbstractHttpRepository, IRepository
    {
        private static string USER_AGENT_ENDPOINT = ENDPOINT + "/agent";
        private Dictionary<Type, List<object>> items = new Dictionary<Type, List<object>>();

        public UserAgentRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        internal IList<T> FetchAllByOperatingSystemName<T>()
        {
            return FetchAllByEndpoint<T>($"{USER_AGENT_ENDPOINT}/os/names");
        }

        internal IList<T> FetchAllByOperatingSystemName<T>(string name)
        {
            return FetchAllByEndpoint<T>($"{USER_AGENT_ENDPOINT}/os/name/{name}");
        }

        internal IList<T> FetchAllByOperatingSystemNameAndVersion<T>(string name, string version)
        {
            return FetchAllByEndpoint<T>($"{USER_AGENT_ENDPOINT}/os/name/{name}?version={version}");
        }
        
        public T FetchById<T>(int id)
        {
            var receivedData = Fetch($"{USER_AGENT_ENDPOINT}/{id}");

            if (receivedData.Result.IsSuccessStatusCode && receivedData.IsCompleted)
            {
                dynamic userAgentResult = HttpContentAsJsonObject(receivedData.Result.Content).Result;

                if (userAgentResult.data.count == 0)
                {
                    throw new HttpRequestException(String.Format("The user agent with the id {0} could not be found.", id));
                }

                var userAgent = Hydrate(userAgentResult.data.items[0]);
                
                return (T)Convert.ChangeType(userAgent, typeof(Entity.UserAgent));
            }

            throw new HttpRequestException(String.Format("The user agent with the id {0} could not be fetched by the database.", id));
        }

        public IList<T> FetchAll<T>()
        {
            return FetchAllByEndpoint<T>(USER_AGENT_ENDPOINT);
        }

        private IList<T> FetchAllByEndpoint<T>(string endpoint)
        {
            var receivedData = Fetch(endpoint);
            List<Entity.UserAgent> userAgentList = new List<Entity.UserAgent>();

            if (receivedData.Result.IsSuccessStatusCode && receivedData.IsCompleted)
            {
                dynamic userAgentResult = HttpContentAsJsonObject(receivedData.Result.Content).Result;

                for (int i = 0; i < (int)userAgentResult.data.count; i++)
                {
                    var proxy = Hydrate(userAgentResult.data.items[i]);

                    userAgentList.Add(proxy);
                }

                return (IList<T>)userAgentList;
            }

            throw new HttpRequestException("Could not receive all user agent data.");
        }

        private Entity.UserAgent Hydrate(dynamic userAgentResult)
        {
            var userAgent = new Entity.UserAgent
            {
                Id = (int)userAgentResult.id,
                OperatingSystem = new Entity.OperatingSystem
                {
                    Id = userAgentResult.operatingSystem.id,
                    Name = userAgentResult.operatingSystem.operatingSystemName.name,
                    Version = userAgentResult.operatingSystem.version
                },
                Software = new Entity.Software
                {
                    Id = userAgentResult.software.id,
                    Name = userAgentResult.software.softwareName.name,
                    Version = userAgentResult.software.version,
                    LEName = userAgentResult.software.layoutEngine.name,
                    LEVersion = userAgentResult.software.leVersion,
                    //Extras = new Entity.SoftwareExtras
                    //{
                    //    Id = userAgentResult.data.items[0].software.extras.id,
                    //    Info = userAgentResult.data.items[0].software.extras.info
                    //},
                },
                Agent = userAgentResult.agent,
            };

            return userAgent;
        }
    }
}
