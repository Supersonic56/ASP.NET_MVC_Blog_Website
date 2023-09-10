using Azure;
using LKBlog.Data;
using LKBlog.Models.Domain;
using Microsoft.EntityFrameworkCore;


namespace LKBlog.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly LKBlogDbContext lKBlogDbContext;

        public TagRepository(LKBlogDbContext lKBlogDbContext)
        {
            this.lKBlogDbContext = lKBlogDbContext;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            await lKBlogDbContext.Tags.AddAsync(tag);
            await lKBlogDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id, LKBlogDbContext lKBlogDbContext) //
        {
            var existingTag = await lKBlogDbContext.Tags.FindAsync(id);

            if (existingTag != null) 
            {
                lKBlogDbContext.Tags.Remove(existingTag);
                await lKBlogDbContext.SaveChangesAsync();
                return existingTag;
            }

            return null;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await lKBlogDbContext.Tags.FindAsync(id);
            
            if (existingTag != null ) 
            {
                lKBlogDbContext.Tags.Remove(existingTag);
                await lKBlogDbContext.SaveChangesAsync(); 
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await lKBlogDbContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            return lKBlogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await lKBlogDbContext.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await lKBlogDbContext.SaveChangesAsync();

                return existingTag;
            }

            return null;
        }
    }
}
