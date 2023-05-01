using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace FileData;

public class RedditContext : DbContext
{
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = database.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(post => post.Id);
            modelBuilder.Entity<User>().HasKey(user => user.Id);
        }
}