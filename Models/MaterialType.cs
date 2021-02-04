using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MaterialType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Material> Material { get; set; }
    }
}
