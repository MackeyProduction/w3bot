using System;
using w3bot.Core.Database.Entity;

namespace w3bot.Core.Database.Hydrator
{
    internal class UserAgentHydrator : IHydrator
    {
        public T Hydrate<T>(dynamic result)
        {
            var userAgent = new UserAgent
            {
                Id = (int)result.id,
                OperatingSystem = new Entity.OperatingSystem
                {
                    Id = result.operatingSystem.id,
                    Name = result.operatingSystem.operatingSystemName.name,
                    Version = result.operatingSystem.version
                },
                Software = new Software
                {
                    Id = result.software.id,
                    Name = result.software.softwareName.name,
                    Version = result.software.version,
                    LEName = result.software.layoutEngine.name,
                    LEVersion = result.software.leVersion,
                    //Extras = new Entity.SoftwareExtras
                    //{
                    //    Id = userAgentResult.data.items[0].software.extras.id,
                    //    Info = userAgentResult.data.items[0].software.extras.info
                    //},
                },
                Agent = result.agent,
            };

            return (T)Convert.ChangeType(userAgent, typeof(UserAgent));
        }
    }
}
