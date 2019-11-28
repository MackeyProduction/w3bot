using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Service
{
    internal class ServiceManager : IManager
    {
        private Dictionary<string, ILoadable> _services = new Dictionary<string, ILoadable>();

        public ILoadable Get(string name)
        {
            return _services[name];
        }

        public void Set(string name, ILoadable service)
        {
            var loadable = _services.Where(x => x.Key == name).FirstOrDefault();

            if (loadable.Key == null)
            {
                _services.Add(name, service);
            }
        }
    }
}
