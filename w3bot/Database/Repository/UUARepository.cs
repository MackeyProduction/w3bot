using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Repository;

namespace w3bot.Database.Repository
{
    internal class UUARepository : AbstractHttpRepository, IRepository
    {
        public UUARepository(HttpClient httpClient) : base(httpClient)
        {
        }

        public IList<T> FetchAll<T>()
        {
            throw new NotImplementedException();
        }

        public T FetchById<T>(int id)
        {
            throw new NotImplementedException();
        }
    }
}
