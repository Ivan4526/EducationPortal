using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        List<Book> Books { get; set; }
    }
}
