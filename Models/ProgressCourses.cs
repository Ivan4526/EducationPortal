using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ProgressCourses
    {
        public int ProgressId { get; set; }
        public Progress Progress { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
