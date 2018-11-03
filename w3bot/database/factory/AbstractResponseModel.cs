using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database.factory
{
    internal abstract class AbstractResponseModel
    {
        protected dynamic _data;
        protected List<Dictionary<string, object>> _objectList;

        internal AbstractResponseModel(object data)
        {
            _data = data;
            _objectList = new List<Dictionary<string, object>>();
        }

        internal List<Dictionary<string, object>> FetchResponseItems()
        {
            var count = (int)_data["data"].count;

            // fetch items
            for (int i = 0; i < count; i++)
            {
                // fetch current item and add dictionary to list
                var dictionary = fetch(_data["data"].items[i]);
                _objectList.Add(dictionary);
            }

            return _objectList;
        }

        internal Dictionary<string, object> FetchResponseData()
        {
            return fetch(_data);
        }

        protected abstract Dictionary<string, object> fetch(dynamic data);
    }
}
