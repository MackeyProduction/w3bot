using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Repository
{
    internal class UPRepository : AbstractHttpRepository, IRepository
    {
        public UPRepository(HttpClient httpClient) : base(httpClient)
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
