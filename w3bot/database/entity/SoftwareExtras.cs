using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Database.Interfaces;

namespace w3bot.Database.Entity
{
    internal class SoftwareExtras : ISoftwareExtras
    {
        private int _id;
        private string _info;

        internal SoftwareExtras()
        {
            _id = 0;
        }

        internal SoftwareExtras(int id, string info)
        {
            _id = id;
            _info = info;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string Info
        {
            get
            {
                return _info;
            }

            set
            {
                _info = value;
            }
        }
    }
}
