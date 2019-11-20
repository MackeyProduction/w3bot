using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Entity
{
    internal class UP
    {
        private int _id;
        private Proxy _proxy;
        private User _user;

        internal UP()
        {
            _id = 0;
        }

        internal UP(int id, Proxy proxy, User user)
        {
            _id = id;
            _proxy = proxy;
            _user = user;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public Proxy Proxy
        {
            get
            {
                return _proxy;
            }

            set
            {
                _proxy = value;
            }
        }

        public User User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }
    }
}
