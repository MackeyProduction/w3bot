using System;

namespace w3bot.Core.Database.Entity
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
