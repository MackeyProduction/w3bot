using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Service
{
    public interface IManager
    {
        void Set(string name, ILoadable service);
        ILoadable Get(string name);
    }
}
