using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Core.Database;

namespace w3bot.GUI
{
    public partial class Loading : Form
    {
        public Loading()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var repository = scope.Resolve<IRepositoryService>();
                var userRepository = repository.CreateRepository("User");
            }

            InitializeComponent();
        }
    }
}
