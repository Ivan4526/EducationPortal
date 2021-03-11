using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.UI
{
    [NotMapped]
    public class AllMaterials
    {
        public List<Video> Videos { get; set; }
        public List<Book> Books { get; set; }
        public List<Article> Articles { get; set; }
    }
}
