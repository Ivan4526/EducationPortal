using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Mapers
{
    public class UserMaterialMaper
    {
        public UserMaterialMaper(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMaterial>()
        .HasKey(pc => new { pc.UserId, pc.MaterialId });

            modelBuilder.Entity<UserMaterial>()
                .HasOne(pc => pc.User)
                .WithMany(p => p.UserMaterials)
                .HasForeignKey(pc => pc.UserId);

            modelBuilder.Entity<UserMaterial>()
                .HasOne(pc => pc.Material)
                .WithMany(c => c.UserMaterials)
                .HasForeignKey(pc => pc.MaterialId);
        }
    }
}
