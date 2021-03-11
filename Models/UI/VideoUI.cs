using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.UI
{
    public class VideoUI
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Quality { get; set; }
        public bool IsCompleted { get; set; }
        public int? MaterialId { get; set; }
        public int? MaterialTypeId { get; set; }
    }
}
