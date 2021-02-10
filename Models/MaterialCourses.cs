﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MaterialCourses
    {
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
