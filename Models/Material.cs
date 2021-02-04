using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Material
    {
        public Video Video { get;set; }
        public Book Book { get; set; }
        public Article Article { get; set; }
        public MaterialType MaterialType { get; set; }
        public List<Course> Courses { get; set; }
    }
}
