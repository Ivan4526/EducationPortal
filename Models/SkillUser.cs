using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SkillUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int Level { get; set; }
    }
}
