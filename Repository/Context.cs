using Helpers.Mapers;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialType>().HasData(new MaterialType { Id = 1, Name = "Video" }, new MaterialType { Id = 2, Name = "Article" }, new MaterialType{ Id = 3, Name = "Book"});
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Default" });
            base.OnModelCreating(modelBuilder);
            new SkillUserMaper(modelBuilder);
            new UserMaterialMaper(modelBuilder);
        }
    }
}
