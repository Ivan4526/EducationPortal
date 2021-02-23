using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Video : BaseEntity
    {
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
    }
}
