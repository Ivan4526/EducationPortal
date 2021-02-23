using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Mapers
{
    public class UserMaper
    {
        public UserMaper(ModelBuilder modelBuilder)
        {
          /* modelBuilder.Entity<User>()
          .HasOne(s => s.Role)
          .WithMany(g => g.Users)
          .HasForeignKey(s => s.RoleId);

           modelBuilder.Entity<UserSkills>().HasKey(sc => new { sc.SkillId, sc.UserId });

           modelBuilder.Entity<UserCourses>().HasKey(sc => new { sc.CourseId, sc.UserId });*/
        }
    }
}
