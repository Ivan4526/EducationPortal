using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Models
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public List<SkillCourses> SkillCourses { get; set; }
    }
}
