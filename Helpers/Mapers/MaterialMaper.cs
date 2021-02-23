using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Mapers
{
    public class MaterialMaper
    {
        public MaterialMaper(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>()
.HasOne(s => s.Video)
.WithOne(ad => ad.Material)
.HasForeignKey<Video>(ad => ad.MaterialId);

            modelBuilder.Entity<Material>()
.HasOne(s => s.Article)
.WithOne(ad => ad.Material)
.HasForeignKey<Article>(ad => ad.MaterialId);

            modelBuilder.Entity<Material>()
.HasOne(s => s.Book)
.WithOne(ad => ad.Material)
.HasForeignKey<Book>(ad => ad.MaterialId);
        }
    }
}
