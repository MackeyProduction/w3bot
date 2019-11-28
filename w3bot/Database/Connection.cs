using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database
{
    internal class Connection
    {
        internal const string DEVELOPMENT_ENDPOINT = "http://127.0.0.1:8000/api";
        internal const string STAGING_ENDPOINT = "http://api-staging.w3bot.org";
        internal const string LIVE_ENDPOINT = "http://api.w3bot.org";

        internal bool IsDevelopment { get; set; }
        internal bool IsStaging { get; set; }
        internal bool IsLive { get; set; }
    }
}
