using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.database.interfaces;

namespace w3bot.database.entity
{
    internal class UserAgent : IUserAgent
    {
        private IOperatingSystem _operatingSystem;
        private ISoftware _software;

        internal UserAgent(IOperatingSystem operatingSystem, ISoftware software)
        {
            _operatingSystem = operatingSystem;
            _software = software;
        }

        public IOperatingSystem OperatingSystem
        {
            get
            {
                return _operatingSystem;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ISoftware Software
        {
            get
            {
                return _software;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
