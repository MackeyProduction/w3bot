using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Core.Database.Entity
{
    internal class UserAgent
    {
        public int Id { get; set; }
        public OperatingSystem OperatingSystem { get; set; }
        public Software Software { get; set; }
        public string Agent { get; set; }
    }
}
