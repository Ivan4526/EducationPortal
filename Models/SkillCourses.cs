using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SkillCourses
    {
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
