using Autofac;
using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Core;
using w3bot.Core.Database.Repository;
using w3bot.Core.Processor;
using w3bot.Core.Reflection;
using w3bot.Core.Utilities;
using w3bot.Event;
using w3bot.GUI;
using w3bot.GUI.Service;
using w3bot.Script;
using w3bot.Wrapper;

namespace w3bot
{
    public static class ContainerConfig
    {
        static ContainerBuilder builder = new ContainerBuilder();

        public static IContainer Configure()
        {
            RegisterRepositories();
            RegisterProcessors();
            RegisterLogger();
            RegisterBot();
            RegisterForms();

            return builder.Build();
        }

        private static void RegisterForms()
        {
            //builder.RegisterType<Login>();
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

        private static void RegisterProcessors()
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .Where(type => type.IsSubclassOf(typeof(Panel)));
            builder.RegisterType<WebProcessor>().As<IProcessor>()
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
            //builder.RegisterType<AppletProcessor>().As<IProcessor>();
            builder.RegisterType<ProcessorService>().As<IProcessorService>()
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
        }

        private static void RegisterLogger()
        {
            builder.RegisterType<Logger>().As<ILogger>();
        }

        private static void RegisterBot()
        {
            builder.RegisterType<FormService>();
            builder.RegisterType<CoreService>()
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
            builder.RegisterType<ScriptExecutor>().As<IExecutable>()
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
            builder.RegisterType<BotWindow>().As<IBotWindow>();
            builder.RegisterType<ChromiumWebBrowser>();
            builder.RegisterType<ChromiumBrowserAdapter>().As<IBotBrowser>();
            builder.RegisterType<Bot>()
                .OnActivating(e => {
                    var formService = e.Context.Resolve<FormService>();
                    var coreService = e.Context.Resolve<CoreService>();
                    var executable = e.Context.Resolve<IExecutable>();

                    e.Instance.AddConfiguration(formService, coreService, executable);
                });
        }
    }
}
