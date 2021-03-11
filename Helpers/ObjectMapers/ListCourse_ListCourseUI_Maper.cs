using Interfaces;
using Models;
using ModelsUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class ListCourse_ListCourseUI_Maper : IMaper<List<Course>, List<CourseUI>>
    {
        IMaper<Course, CourseUI> courseMaper;
        public ListCourse_ListCourseUI_Maper(IMaper<Course, CourseUI> courseMaper)
        {
            this.courseMaper = courseMaper;
        }
        public List<CourseUI> Map(List<Course> coursesRepo)
        {
            var coursesUI = new List<CourseUI>();
            foreach(var courseRepo in coursesRepo)
            {
                coursesUI.Add(courseMaper.Map(courseRepo));
            }
            return coursesUI;

        }
    }
}
