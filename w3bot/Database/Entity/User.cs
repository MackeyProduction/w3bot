using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Interfaces;

namespace w3bot.Database.Entity
{
    internal class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Group Group { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
