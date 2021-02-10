using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class UserSkills
    {
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int UserId { get; set; }
        public User User {get;set;}
    }
}
