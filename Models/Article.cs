﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Article : BaseEntity
    {
        public DateTime PublishDate { get; set; }
        public string URL { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
    }
}
