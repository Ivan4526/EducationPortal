using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Models
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
        public List<SkillUser> SkillUsers { get; set; }
        //public List<SkillCourses> SkillCourses { get; set; }
       // public List<UserSkills> UserSkills { get; set; }
    }
}
