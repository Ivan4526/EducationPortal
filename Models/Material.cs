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
        public int MaterialTypeId { get;set; }
        public MaterialType MaterialType { get; set; }
        public List<MaterialCourses> MaterialCourses { get; set; }
    }
}
