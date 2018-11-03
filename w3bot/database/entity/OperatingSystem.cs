using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.interfaces;

namespace w3bot.database.entity
{
    internal class OperatingSystem : IOperatingSystem
    {
        private int _id;
        private string _name, _version;

        internal OperatingSystem()
        {
            _id = 0;
        }

        internal OperatingSystem(int id, string name, string version)
        {
            _id = id;
            _name = name;
            _version = version;
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

        public string Version
        {
            get
            {
                return _version;
            }

            set
            {
                _version = value;
            }
        }
    }
}
