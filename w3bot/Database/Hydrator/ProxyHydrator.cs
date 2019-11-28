using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Entity;

namespace w3bot.Database.Hydrator
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
