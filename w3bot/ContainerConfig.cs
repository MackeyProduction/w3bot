using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using w3bot.Core.Database.Repository;
using w3bot.GUI;

namespace w3bot
{
    public static class ContainerConfig
    {
        static ContainerBuilder builder = new ContainerBuilder();

        public static IContainer Configure()
        {
            RegisterRepositories();
            RegisterForms();

            return builder.Build();
        }

        private static void RegisterForms()
        {
            builder.RegisterType<Login>();
            builder.RegisterType<Main>();
        }

        private static void RegisterRepositories()
        {
            builder.RegisterType<HttpClient>();
            builder.RegisterType<UserRepository>().As<IRepository>();
            builder.RegisterType<ProxyRepository>().As<IRepository>();
            builder.RegisterType<UserAgentRepository>().As<IRepository>();
            builder.RegisterType<UPRepository>().As<IRepository>();
            builder.RegisterType<UUARepository>().As<IRepository>();
            builder.RegisterType<RepositoryService>().As<IRepositoryService>();
        }
    }
}
