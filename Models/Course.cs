using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Material> Materials { get; set; }
    }
}
