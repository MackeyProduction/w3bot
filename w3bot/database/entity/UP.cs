using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Interfaces;

namespace w3bot.Database.Entity
{
    internal class UP : IUP
    {
        private int _id;
        private IProxy _proxy;
        private IUser _user;

        internal UP()
        {
            _id = 0;
        }

        internal UP(int id, IProxy proxy, IUser user)
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

        public IProxy Proxy
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

        public IUser User
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
