using Interfaces;
using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class Skill_SkillUI_Maper : IMaper<Skill, SkillUI>
    {
        public SkillUI Map(Skill skill)
        {
            var skillUI = new SkillUI();
            skillUI.Id = skill.Id;
            skillUI.Name = skill.Name;
            return skillUI;
        }
    }
}
