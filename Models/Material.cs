using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Material : BaseEntity
    {
        public virtual Video Video { get;set; }
        public virtual Book Book { get; set; }
        public virtual Article Article { get; set; }
        public int MaterialTypeId { get;set; }
        public virtual MaterialType MaterialType { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<UserMaterial> UserMaterials { get; set; }
    }
}
