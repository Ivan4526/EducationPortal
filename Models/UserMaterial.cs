using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class UserMaterial
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public bool IsCompleted { get; set; }

    }
}
