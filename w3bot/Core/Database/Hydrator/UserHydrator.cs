using System;
using w3bot.Core.Database.Entity;

namespace w3bot.Core.Database.Hydrator
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
