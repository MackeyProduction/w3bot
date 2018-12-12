using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Interfaces;

namespace w3bot.Database.Helper
{
    internal class RepositoryHelper : IRepository
    {
        private List<Dictionary<string, object>> _data;

        internal RepositoryHelper(List<Dictionary<string, object>> data)
        {
            _data = data;
        }

        public List<Dictionary<string, object>> FetchAll()
        {
            return _data;
        }

        public Dictionary<string, object> FetchById(int id)
        {
            return _data[id];
        }
    }
}
