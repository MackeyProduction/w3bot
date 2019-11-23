using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Repository;

namespace w3bot.Database.Repository
{
    internal class ProxyRepository : AbstractHttpRepository, IRepository
    {
        private static string PROXY_ENDPOINT = ENDPOINT + "/proxy";

        public ProxyRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        public IList<T> FetchAll<T>()
        {
            var receivedData = Fetch(PROXY_ENDPOINT);
            List<Entity.Proxy> proxyList = new List<Entity.Proxy>();

            if (receivedData.Result.IsSuccessStatusCode && receivedData.IsCompleted)
            {
                // fetch proxy result
                dynamic proxyResult = HttpContentAsJsonObject(receivedData.Result.Content).Result;
                
                for (int i = 0; i < (int)proxyResult.data.count; i++)
                {
                    var proxy = Hydrate(proxyResult.data.items[i]);

                    proxyList.Add(proxy);
                }

                return (IList<T>)proxyList;
            }

            throw new HttpRequestException("Could not receive all proxy data.");
        }

        public T FetchById<T>(int id)
        {
            var receivedData = Fetch($"{PROXY_ENDPOINT}/{id}");

            if (receivedData.Result.IsSuccessStatusCode && receivedData.IsCompleted)
            {
                dynamic proxyResult = HttpContentAsJsonObject(receivedData.Result.Content).Result;

                if (proxyResult.data.count == 0)
                {
                    throw new HttpRequestException(String.Format("The proxy with the id {0} could not be found.", id));
                }

                var proxy = Hydrate(proxyResult.data.items[0]);

                return (T)Convert.ChangeType(proxy, typeof(Entity.Proxy));
            }

            throw new HttpRequestException(String.Format("The proxy with the id {0} could not be fetched by the database.", id));
        }

        private Entity.Proxy Hydrate(dynamic proxyResult)
        {
            var proxy = new Entity.Proxy
            {
                Id = (int)proxyResult.id,
                ProxyName = (string)proxyResult.name,
                IP = (string)proxyResult.ip,
                Port = (int)proxyResult.port,
                Username = (string)proxyResult.username ?? "",
                Password = (string)proxyResult.password ?? "",
            };

            return proxy;
        }
    }
}
