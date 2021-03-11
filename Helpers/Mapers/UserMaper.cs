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
            modelBuilder.Entity<User>()
                     .HasMany(x => x.Courses)
                     .WithMany(x => x.Users);
        }
    }
}
