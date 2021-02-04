﻿using System;
using System.Collections.Generic;

namespace Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
