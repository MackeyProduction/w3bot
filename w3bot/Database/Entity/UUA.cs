﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Entity
{
    internal class UUA
    {
        public int Id { get; set; }
        public User User { get; set; }
        public UserAgent UserAgent { get; set; }
    }
}
