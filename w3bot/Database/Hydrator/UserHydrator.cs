using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Entity;

namespace w3bot.Database.Hydrator
{
    internal class UserHydrator : IHydrator
    {
        public T Hydrate<T>(dynamic result)
        {
            var user = new User
            {
                Id = (int)result.id,
                Email = (string)result.email,
                Group = new Group
                {
                    Id = result.group.id,
                    Name = result.group.name,
                },
                Username = (string)result.username,
                Password = (string)result.password,
                RegisterDate = (DateTime)result.registerDate,
            };

            return (T)Convert.ChangeType(user, typeof(User));
        }
    }
}
