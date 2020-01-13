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
using w3bot.Api;
using w3bot.Core;
using w3bot.Core.Database.Repository;
using w3bot.Core.Processor;
using w3bot.Core.Reflection;
using w3bot.Core.Utilities;
using w3bot.Event;
using w3bot.GUI;
using w3bot.GUI.Service;
using w3bot.Input;
using w3bot.Script;
using w3bot.Wrapper;
using w3bot.Wrapper.Browser;
using w3bot.Wrapper.Input;

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
            RegisterApi();
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
            builder.RegisterType<Panel>();
            //builder.RegisterType<ChromiumBrowserAdapter>().As<IApiEventListener>()
            //    .FindConstructorsWith(new NonPublicConstructorFinder())
            //    .AsSelf();
            //builder.RegisterType<Mouse>().As<IEventListener>()
            //    .FindConstructorsWith(new NonPublicConstructorFinder())
            //    .AsSelf();
            //builder.RegisterType<Chromium>().As<IEventListener>()
            //    .FindConstructorsWith(new NonPublicConstructorFinder())
            //    .AsSelf();
            builder.RegisterType<WebProcessor>().As<IProcessor>()
                .OnActivating(e => {
                    //var botBrowser = e.Context.Resolve<IApiEventListener>();
                    //var mouse = e.Context.Resolve<IEventListener>();
                    //var browser = e.Context.Resolve<IEventListener>();

                    //e.Instance.Attach(botBrowser);
                    //e.Instance.Attach(mouse);
                    //e.Instance.Attach(browser);
                })
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
            builder.RegisterType<WebProcessor>().As<IRenderProcessor>()
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
                .OnActivating(e =>
                {
                    var formService = e.Context.Resolve<FormService>();
                    var coreService = e.Context.Resolve<CoreService>();
                    var executable = e.Context.Resolve<IExecutable>();

                    e.Instance.AddConfiguration(formService, coreService, executable);
                });
        }
        
        private static void RegisterApi()
        {
            builder.RegisterType<Frame>().OnActivating(e =>
            {
                var frame = e.Context.Resolve<IProcessor>();

                e.Instance.AddConfiguration(frame);
            });
        }
    }
}
