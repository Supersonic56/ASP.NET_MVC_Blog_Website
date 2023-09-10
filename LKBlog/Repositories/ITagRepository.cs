using LKBlog.Models.Domain;
using Microsoft.Identity.Client;


namespace LKBlog.Repositories
{
    public interface ITagRepository
    {
        //getalltags
       Task<IEnumerable<Tag>> GetAllAsync();

       Task<Tag?> GetAsync(Guid id);
       Task<Tag> AddAsync(Tag tag);

       Task<Tag?> UpdateAsync(Tag tag);

        Task<Tag?> DeleteAsync(Guid id);
    }
}
