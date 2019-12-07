using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Core
{
    internal static class ContainerConfig
    {
        internal static IContainer Configure()
        {
            var builder = new ContainerBuilder();



            return builder.Build();
        }
    }
}
