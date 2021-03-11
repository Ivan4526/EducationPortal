using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Mapers
{
    class UserCourseMaper
    {
        public UserCourseMaper(ModelBuilder modelBuilder)
        {
          /*  modelBuilder.Entity<UserCourse>()
        .HasKey(pc => new { pc.UserId, pc.CourseId });

            modelBuilder.Entity<UserCourse>()
                .HasOne(pc => pc.User)
                .WithMany(p => p.UserCourses)
                .HasForeignKey(pc => pc.UserId);

            modelBuilder.Entity<UserCourse>()
                .HasOne(pc => pc.Course)
                .WithMany(c => c.UserCourses)
                .HasForeignKey(pc => pc.CourseId);*/
        }
    }
}
