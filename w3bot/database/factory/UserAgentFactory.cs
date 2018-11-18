using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.entity;
using w3bot.database.interfaces;

namespace w3bot.database.factory
{
    internal class UserAgentFactory : AbstractResponseModel
    {
        public UserAgentFactory(object data) : base(data)
        {
            base._data = data;
        }

        protected override Dictionary<string, object> fetch(dynamic data)
        {
            return new Dictionary<string, object>
            {
                { "entity", new UserAgent((int)data.id, new entity.OperatingSystem((int)data.operatingSystem.id, (string)data.operatingSystem.operatingSystemName.name, (string)data.operatingSystem.version), new Software((int)data.software.id, (string)data.software.softwareName.name, (string)data.software.version, (string)data.software.layoutEngine.name, (string)data.software.leVersion, null), (string)data.agent) }
            };
        }
    }
}
