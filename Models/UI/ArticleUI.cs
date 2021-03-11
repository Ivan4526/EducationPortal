using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.UI
{
    public class ArticleUI
    {
        public int? Id { get; set; }
        public DateTime PublishDate { get; set; }
        public string URL { get; set; }
        public bool IsCompleted { get; set; }
        public int? MaterialId { get; set; }
        public int? MaterialTypeId { get; set; }
    }
}
