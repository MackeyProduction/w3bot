using System;
using w3bot.Core.Database.Entity;

namespace w3bot.Core.Database.Hydrator
{
    internal class ProxyHydrator : IHydrator
    {
        public T Hydrate<T>(dynamic result)
        {
            var proxy = new Proxy
            {
                Id = (int)result.id,
                ProxyName = (string)result.name,
                IP = (string)result.ip,
                Port = (int)result.port,
                Username = (string)result.username ?? "",
                Password = (string)result.password ?? "",
            };

            return (T)Convert.ChangeType(proxy, typeof(Proxy));
        }
    }
}
