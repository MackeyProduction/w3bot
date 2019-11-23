using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Entity
{
    internal class Software
    {
        public int Id { get; set; }
        public string LEName { get; set; }
        public string LEVersion { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public SoftwareExtras Extras { get; set; }
    }
}
