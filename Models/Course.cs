using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SkillCourses> SkillCourses { get; set; }
        public List<MaterialCourses> MaterialCourses { get; set; }
    }
}
