﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Progress : BaseEntity
    {
        public int Percent { get; set; }
        public virtual List<Course> Courses { get; set; }
       // public List<ProgressCourses> ProgressCourses { get; set; }
    }
}
