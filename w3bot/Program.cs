using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Api;
using w3bot.GUI;

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

                var mainForm = scope.Resolve<Main>();
                Application.Run(mainForm);
            }
        }
    }
}
