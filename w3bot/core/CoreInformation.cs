using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Core
{
    internal class CoreInformation
    {
        internal static Version assemblyVersion { get { return Assembly.GetExecutingAssembly().GetName().Version; } }
        internal static string fileVersion { get { return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion; } }
        internal static int build { get { return assemblyVersion.Build; } }
        internal static double programVersion { get { return double.Parse(assemblyVersion.Major + "." + assemblyVersion.Minor, CultureInfo.InvariantCulture); } }
        internal static double apiVersion { get { return double.Parse(fileVersion.Substring(0, 3), CultureInfo.InvariantCulture); } }
    }
}
