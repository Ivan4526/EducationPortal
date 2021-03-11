using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.UI
{
    public class BookUI
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public List<AuthorUI> Authors { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsCompleted { get; set; }
        public int? MaterialId { get; set; }
        public int? MaterialTypeId { get; set; }
    }
}
