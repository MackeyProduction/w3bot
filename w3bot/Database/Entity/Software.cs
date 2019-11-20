using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Entity
{
    internal class Software
    {
        private int _id;
        private string _name, _version, _LEName, _LEVersion;
        private SoftwareExtras _extras;

        internal Software()
        {
            _id = 0;
        }

        internal Software(int id, string name, string version, string LEName, string LEVersion, SoftwareExtras extras)
        {
            _id = id;
            _name = name;
            _version = version;
            _LEName = LEName;
            _LEVersion = LEVersion;
            _extras = extras;
        }

        public SoftwareExtras Extras
        {
            get
            {
                return _extras;
            }

            set
            {
                _extras = value;
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }
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
