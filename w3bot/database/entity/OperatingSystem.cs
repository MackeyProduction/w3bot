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
        private string _name, _version;

        internal OperatingSystem(string name, string version)
        {
            _name = name;
            _version = version;
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
