using System;
using System.Collections.Generic;
using System.Net.Http;

namespace w3bot.Core.Database.Repository
{
    public class UUARepository : AbstractHttpRepository, IRepository
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

        public bool IsValid(string validator)
        {
            return validator == "UUA";
        }
    }
}
