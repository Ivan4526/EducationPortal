using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Mapers
{
    public class SkillUserMaper
    {
        public SkillUserMaper(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillUser>()
  .HasKey(pc => new { pc.UserId, pc.SkillId });

            modelBuilder.Entity<SkillUser>()
                .HasOne(pc => pc.User)
                .WithMany(p => p.SkillUsers)
                .HasForeignKey(pc => pc.UserId);

            modelBuilder.Entity<SkillUser>()
                .HasOne(pc => pc.Skill)
                .WithMany(c => c.SkillUsers)
                .HasForeignKey(pc => pc.SkillId);
        }
    }
}
