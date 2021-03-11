using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsUI
{
    public class CourseUI
    {
        public int? Id { get; set; }
        public List<VideoUI> Videos { get; set; }
        public List<ArticleUI> Articles { get; set; }
        public List<BookUI> Books { get; set; }
        public SkillUI Skill { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
