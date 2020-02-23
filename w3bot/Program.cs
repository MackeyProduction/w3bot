using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Api;
using w3bot.GUI;
using w3bot.Input;
using w3bot.Script;

namespace w3bot
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var scope = ContainerConfig.Configure().BeginLifetimeScope())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // resolving api
                scope.Resolve<Browser>();
                scope.Resolve<Frame>();
                scope.Resolve<Captcha>();
                scope.Resolve<MethodProvider>();
                scope.Resolve<w3bot.Core.Debug>();

                var mainForm = scope.Resolve<Main>();
                Application.Run(mainForm);
            }
        }
    }
}
