using System;
using System.Collections.Generic;
using System.Net.Http;

namespace w3bot.Core.Database.Repository
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
