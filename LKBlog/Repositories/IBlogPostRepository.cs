﻿using LKBlog.Models.Domain;

namespace LKBlog.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();

        Task<BlogPost?> GetAsync(Guid id);
        Task<BlogPost> AddAsync(BlogPost blogPost);

        Task<BlogPost?> UpdateAsync(BlogPost blogPost);

        Task<BlogPost?> DeleteAsync(BlogPost blogPost);
    }
}
