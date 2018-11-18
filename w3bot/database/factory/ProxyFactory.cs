﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.entity;

namespace w3bot.database.factory
{
    internal class ProxyFactory : AbstractResponseModel
    {
        public ProxyFactory(object data) : base(data)
        {
            base._data = data;
        }

        protected override Dictionary<string, object> fetch(dynamic data)
        {
            return new Dictionary<string, object>
            {
                { "entity", new Proxy((int)data.id, (string)data.name, (string)data.ip, (int)data.port, (string)data.username, (string)data.password) }
            };
        }
    }
}
