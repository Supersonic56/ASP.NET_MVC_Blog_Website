using LKBlog.Data;
using LKBlog.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LKBlog.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly LKBlogDbContext lKBlogDbContext;

        public BlogPostRepository(LKBlogDbContext lKBlogDbContext)
        {
            this.lKBlogDbContext = lKBlogDbContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await lKBlogDbContext.AddAsync(blogPost);
            await lKBlogDbContext.SaveChangesAsync();
            return blogPost;
        }

        public Task<BlogPost?> DeleteAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await lKBlogDbContext.BlogPost.Include(x => x.Tags).ToListAsync();
        }

        public Task<BlogPost?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
