using Interfaces;
using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class ListSkill_ListSkillUI_Maper : IMaper<List<Skill>, List<SkillUI>>
    {
         IMaper<Skill, SkillUI> skillMaper;
        public ListSkill_ListSkillUI_Maper(IMaper<Skill, SkillUI> skillMaper)
        {
            this.skillMaper = skillMaper;
        }

        public List<SkillUI> Map(List<Skill> skills)
        {
            var skillsUI = new List<SkillUI>();
            foreach(var skill in skills)
            {
                skillsUI.Add(skillMaper.Map(skill));
            }
            return skillsUI;
        }
    }
}
