using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Entity
{
    internal class UserAgent
    {
        private int _id;
        private OperatingSystem _operatingSystem;
        private Software _software;
        private string _agent;

        internal UserAgent()
        {
            _id = 0;
        }

        internal UserAgent(int id, OperatingSystem operatingSystem, Software software, string agent)
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

        public OperatingSystem OperatingSystem
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

        public Software Software
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
