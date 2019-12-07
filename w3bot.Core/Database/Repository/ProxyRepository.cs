using System;
using System.Collections.Generic;
using System.Net.Http;

namespace w3bot.Core.Database.Repository
{
    public class ProxyRepository : AbstractHttpRepository, IRepository
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

        public bool IsValid(string validator)
        {
            return validator == "Proxy";
        }

        internal async void AddProxy(Entity.Proxy proxy)
        {
            //var values = new Dictionary<string, string>
            //    {
            //        { "name", proxy.ProxyName },
            //        { "ip", proxy.IP },
            //        { "port", proxy.Port.ToString() },
            //        { "username", proxy.Username },
            //        { "password", proxy.Password }
            //    };

            //var response = await Connection.PostRequest("proxy", values);
            //await _proxyResponse.GetResponse(response);
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
