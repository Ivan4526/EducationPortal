using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public virtual List<Material> Materials { get; set; }
        public virtual List<User> Users{ get; set; }
       // public List<SkillCourses> SkillCourses { get; set; }
       // public List<MaterialCourses> MaterialCourses { get; set; }
       // public List<UserCourses> UserCourses { get; set; }
    }
}
