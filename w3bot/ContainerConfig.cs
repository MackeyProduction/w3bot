using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using w3bot.Core.Database.Repository;

namespace w3bot
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HttpClient>();
            builder.RegisterType<UserRepository>().As<IRepository>();
            builder.RegisterType<ProxyRepository>().As<IRepository>();
            builder.RegisterType<UserAgentRepository>().As<IRepository>();
            builder.RegisterType<UPRepository>().As<IRepository>();
            builder.RegisterType<UUARepository>().As<IRepository>();
            builder.RegisterType<RepositoryService>().As<IRepositoryService>();

            return builder.Build();
        }
    }
}
