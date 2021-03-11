using System;
using System.Collections.Generic;
using System.Net;

namespace Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        //public List<UserSkills> UserSkills { get; set; }
        public virtual List<SkillUser> SkillUsers { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<UserMaterial> UserMaterials { get; set; }
        //public List<UserCourses> UserCourses { get; set; }
    }
}
