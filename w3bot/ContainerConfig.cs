using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using w3bot.Core.Database;
using w3bot.Core.Database.Repository;

namespace w3bot
{
    public static class ContainerConfig
    {
        private static ContainerBuilder builder = new ContainerBuilder();

        public static IContainer Configure()
        {
            RegisterCore();
            RegisterAPI();
            RegisterGUI();

            return builder.Build();
        }

        private static void RegisterCore()
        {
            builder.RegisterType<HttpClient>();

            builder.RegisterType<RepositoryService>().As<IRepositoryService>();

            // load repository assemblies
            builder.RegisterAssemblyTypes(Assembly.Load("w3bot.Core"))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }

        private static void RegisterGUI()
        {

        }

        private static void RegisterAPI()
        {

        }
    }
}
