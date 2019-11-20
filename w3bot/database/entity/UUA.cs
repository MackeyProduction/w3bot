using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Entity
{
    internal class UUA
    {
        private int _id;
        private User _user;
        private UserAgent _userAgent;

        internal UUA()
        {
            _id = 0;
        }

        internal UUA(int id, User user, UserAgent userAgent)
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

        public UserAgent UserAgent
        {
            get
            {
                return _userAgent;
            }

            set
            {
                _userAgent = value;
            }
        }
    }
}
