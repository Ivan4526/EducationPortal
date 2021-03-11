using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Video : BaseEntity
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Quality { get; set; }
        public int MaterialId { get; set; } 
        public virtual Material Material { get; set; }
    }
}
