using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Response;

namespace w3bot.Database.Helper
{
    internal class EntityMappingHelper
    {
        internal async Task<List<Dictionary<string, object>>> GetEntities(string entityName, string endpoint, AbstractResponse factory)
        {
            object entity = entityName;
            var response = await Connection.GetRequest(endpoint);
            var result = await factory.GetResponse(response);
            var dictionary = result.FetchResponseItems();

            return dictionary;
        }
    }
}
