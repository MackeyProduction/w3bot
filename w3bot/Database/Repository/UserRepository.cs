using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Repository
{
    internal class UserRepository : AbstractHttpRepository, IRepository
    {
        public UserRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        internal async Task<List<Dictionary<string, object>>> FetchUser(string username)
        {
            return null;
            //return await GetEntities("User", $"user/?name={username}", new UserResponse());
        }

        public T FetchById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> FetchAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}
