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
        private int _id;
        private IOperatingSystem _operatingSystem;
        private ISoftware _software;
        private string _agent;

        internal UserAgent()
        {
            _id = 0;
        }

        internal UserAgent(int id, IOperatingSystem operatingSystem, ISoftware software, string agent)
        {
            _id = id;
            _operatingSystem = operatingSystem;
            _software = software;
            _agent = agent;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public IOperatingSystem OperatingSystem
        {
            get
            {
                return _operatingSystem;
            }

            set
            {
                _operatingSystem = value;
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
                _software = value;
            }
        }

        public string Agent
        {
            get
            {
                return _agent;
            }

            set
            {
                _agent = value;
            }
        }
    }
}
