﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.repository;

namespace w3bot.Database.repository
{
    internal class ProxyRepository : RepositoryManager
    {
        protected override string FetchRepository()
        {
            return "Proxy";
        }
    }
}
