using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Api;
using w3bot.Core;
using w3bot.Wrapper;

namespace w3bot.Script
{
    public class MethodProvider
    {
        /// <summary>
        /// The running browser instance.
        /// </summary>
        public Browser Browser { get; set; }

        /// <summary>
        /// The running frame instance.
        /// </summary>
        public Frame Frame { get; set; }

        internal MethodProvider(IBotBrowser botBrowser, CoreService coreService)
        {

        }
    }
}
