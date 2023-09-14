using LKBlog.Data;
using LKBlog.Models.Domain;

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

        public Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            throw new NotImplementedException();
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
