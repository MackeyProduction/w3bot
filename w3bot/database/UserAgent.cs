using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.interfaces;

namespace w3bot.database
{
    internal class UserAgent : IUserAgent
    {
        internal UserAgent(IOperatingSystem operatingSystem, ISoftware software)
        {

        }

        public IOperatingSystem OperatingSystem
        {
            get
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
