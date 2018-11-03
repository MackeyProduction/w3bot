using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.interfaces;

namespace w3bot.database.entity
{
    internal class Software : ISoftware
    {
        private string _name, _version, _LEName, _LEVersion;

        internal Software(string name, string version, string LEName, string LEVersion)
        {
            _name = name;
            _version = version;
            _LEName = LEName;
            _LEVersion = LEVersion;
        }

        public string LEName
        {
            get
            {
                return _LEName;
            }

            set
            {
                _LEName = value;
            }
        }

        public string LEVersion
        {
            get
            {
                return _LEVersion;
            }

            set
            {
                _LEVersion = value;
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
