using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
