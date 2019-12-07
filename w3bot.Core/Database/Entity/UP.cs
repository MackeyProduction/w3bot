using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Core.Database.Entity
{
    internal class UP
    {
        public int Id { get; set; }
        public Proxy Proxy { get; set; }
        public User User { get; set; }
    }
}
