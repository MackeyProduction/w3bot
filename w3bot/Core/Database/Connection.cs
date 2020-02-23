using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Core.Database
{
    internal class Connection
    {
        internal static string ENDPOINT = "http://api.w3bot.org";

        internal static bool IsDevelopment { get; set; } = false;
        internal static bool IsStaging { get; set; } = false;
        internal static bool IsLive { get; set; } = false;
    }
}
