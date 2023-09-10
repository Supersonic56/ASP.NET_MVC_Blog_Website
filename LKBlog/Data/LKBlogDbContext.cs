using LKBlog.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LKBlog.Data
{
    public class LKBlogDbContext : DbContext
    {
        public LKBlogDbContext(DbContextOptions<LKBlogDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }

        public DbSet<Tag> Tags { get; set; }

        //public DbSet<BlogPostLike> BlogPostLike { get; set; }
        //public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}
