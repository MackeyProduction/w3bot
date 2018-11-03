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
        private string _username, _password, _email;
        private DateTime _registerDate;
        private IGroup _group;

        internal User(string username, string password, string email, DateTime registerDate, IGroup group)
        {
            _username = username;
            _password = password;
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
                throw new NotImplementedException();
            }
        }

        public string Password
        {
            get
            {
                return _password;
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
