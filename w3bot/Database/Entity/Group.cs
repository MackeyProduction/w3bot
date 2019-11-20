using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Entity
{
    internal class Group
    {
        private int _id;
        private string _name;

        internal Group()
        {
            _id = 0;
        }

        internal Group(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
    }
}
