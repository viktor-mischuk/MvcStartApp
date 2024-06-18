using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace MvcStartApp.Models.Db
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<Request> Requests { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<UserPost>().ToTable("UserPosts");
            builder.Entity<Request>().ToTable("Request");
        }
    }
}
