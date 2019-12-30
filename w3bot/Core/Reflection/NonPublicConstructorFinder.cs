using Autofac.Core.Activators.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Core.Reflection
{
    internal class NonPublicConstructorFinder : DefaultConstructorFinder
    {
        public NonPublicConstructorFinder()
        : base(type => type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
        }
    }
}
