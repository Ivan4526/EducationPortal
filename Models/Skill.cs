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
        public virtual List<Course> Courses { get; set; }
        public virtual List<User> Users { get; set; }
        //public List<SkillCourses> SkillCourses { get; set; }
       // public List<UserSkills> UserSkills { get; set; }
    }
}
