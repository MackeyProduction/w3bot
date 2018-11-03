using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.entity;

namespace w3bot.database.factory
{
    internal class UserFactory : AbstractResponseModel
    {
        public UserFactory(object data) : base(data)
        {
            base._data = data;
        }

        protected override Dictionary<string, object> fetch(dynamic data)
        {
            return new Dictionary<string, object>
            {
                { "entity", new User((string)data.username, "", (string)data.email, DateTime.ParseExact(((string)data.registerDate.date).Split(' ')[0], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture), null) }
            };
        }
    }
}
