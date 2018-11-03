using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.interfaces;
using w3bot.interfaces;

namespace w3bot.database.entity
{
    internal class User : IUser
    {
        private int _id;
        private string _username, _password, _email;
        private DateTime _registerDate;
        private IGroup _group;

        internal User()
        {
            _id = 0;
        }

        internal User(int id, string username, string email, DateTime registerDate, IGroup group)
        {
            _id = id;
            _username = username;
            _email = email;
            _registerDate = registerDate;
            _group = group;
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public IGroup Group
        {
            get
            {
                return _group;
            }

            set
            {
                _group = value;
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public DateTime RegisterDate
        {
            get
            {
                return _registerDate;
            }

            set
            {
                _registerDate = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }
    }
}
