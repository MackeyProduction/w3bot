using Autofac;
using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Api;
using w3bot.Core;
using w3bot.Core.Database;
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
            RegisterConnection();
            RegisterEvents();

            return builder.Build();
        }

        private static void RegisterForms()
        {
            //builder.RegisterType<Login>();
            builder.RegisterType<Main>();
            builder.RegisterType<w3bot.Core.Debug>()
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
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
            builder.RegisterType<ProcessorValueContext>()
                .SingleInstance()
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
            builder.RegisterType<WebProcessor>().As<IProcessor>()
                .OnActivating(e => {
                    var mouseEvent = e.Context.Resolve<IMouseEvent>();
                    var keyboardEvent = e.Context.Resolve<IKeyboardEvent>();
                    var paintEvent = e.Context.Resolve<IPaintEvent>();

                    e.Instance.MouseHandler = mouseEvent;
                    e.Instance.KeyboardHandler = keyboardEvent;
                    e.Instance.PaintHandler = paintEvent;
                })
                .Keyed<IProcessor>(ProcessorType.BrowserProcessor)
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
            builder.RegisterType<AppletProcessor>().As<IProcessor>()
                .Keyed<IProcessor>(ProcessorType.AppletProcessor)
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
            builder.RegisterType<ProcessorCreateService>().As<IProcessorCreateService>()
                .SingleInstance()
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
            builder.RegisterType<ProcessorService>().As<IProcessorService>()
                .SingleInstance()
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
                    var methodProvider = e.Context.Resolve<MethodProvider>();

                    //e.Instance.Methods = methodProvider;
                    e.Instance.AddConfiguration(formService, coreService, executable, methodProvider);
                });
        }
        
        private static void RegisterApi()
        {
            builder.RegisterType<Browser>();
            builder.RegisterType<Frame>()
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
            builder.RegisterType<Captcha>()
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
            builder.RegisterType<MethodProvider>().OnActivating(e =>
            {
                var browser = e.Context.Resolve<Browser>();
                var frame = e.Context.Resolve<Frame>();
                var captcha = e.Context.Resolve<Captcha>();

                e.Instance.Browser = browser;
                e.Instance.Frame = frame;
                e.Instance.Captcha = captcha;
            });
        }

        private static void RegisterConnection()
        {
            var process = Process.GetCurrentProcess();
            var commandLine = process.GetCommandLine();

            Connection.IsLive = true;
            if (commandLine.Contains("-dev") && !commandLine.Contains("-staging"))
            {
                Connection.ENDPOINT = "http://127.0.0.1:8000/api";
                Connection.IsDevelopment = true;
                Connection.IsLive = false;
            }

            if (commandLine.Contains("-staging") && !commandLine.Contains("-dev"))
            {
                Connection.ENDPOINT = "http://api-staging.w3bot.org";
                Connection.IsStaging = true;
                Connection.IsLive = false;
            }
        }

        private static void RegisterEvents()
        {
            //builder.RegisterType<BrowserEvent>().As<IEventListener>();
            builder.RegisterType<KeyboardEvent>().As<IKeyboardEvent>();
            builder.RegisterType<MouseEvent>().As<IMouseEvent>();
            builder.RegisterType<PaintEvent>().As<IPaintEvent>();
            builder.RegisterType<ScriptExecutor>().As<IExecutable>()
                .FindConstructorsWith(new NonPublicConstructorFinder())
                .AsSelf();
        }

        private static string GetCommandLine(this Process process)
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id))
            using (ManagementObjectCollection objects = searcher.Get())
            {
                return objects.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
            }

        }
    }
}
