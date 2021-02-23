using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MaterialType : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<Material> Material { get; set; }
    }
}
