using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
        public int Pages { get; set; }
        public DateTime PublishDate { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
    }
}
