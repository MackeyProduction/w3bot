using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.interfaces;

namespace w3bot.database.entity
{
    internal class UUA : IUUA
    {
        private int _id;
        private IUser _user;
        private IUserAgent _userAgent;

        internal UUA(int id, IUser user, IUserAgent userAgent)
        {
            _id = id;
            _user = user;
            _userAgent = userAgent;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public IUser User
        {
            get
            {
                return _user;
            }
        }

        public IUserAgent UserAgent
        {
            get
            {
                return _userAgent;
            }
        }
    }
}
