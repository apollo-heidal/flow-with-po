using FlowWithPo.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowWithPo.Data
{
    public class BlogPostContext : DbContext
    {
        public BlogPostContext(DbContextOptions<BlogPostContext> options) : base(options)
        {

        }
        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    BlogPostId = 1,
                    Title = "First post",
                    Text = "This is a default post used for debugging.",
                    TimePosted = System.DateTime.Now
                }
            );
        }
    }
}