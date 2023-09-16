using LKBlog.Models.ViewModels;
using LKBlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LKBlog.Models.Domain;


namespace LKBlog.Controllers
{
    public class AdminBlogPostsController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IBlogPostRepository blogPostRepository;

        public AdminBlogPostsController(ITagRepository tagRepository, IBlogPostRepository blogPostRepository)
        {
            this.tagRepository = tagRepository;
            this.blogPostRepository = blogPostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //get tags from repository
            var tags = await tagRepository.GetAllAsync();

            var model = new AddBLogPostRequest
            {
                Tags = tags.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBLogPostRequest addBLogPostRequest)
        { 
            //map the view to domain model
            var blogPost = new BlogPost
            {
                Heading = addBLogPostRequest.Heading,
                PageTitle = addBLogPostRequest.PageTitle,
                Content = addBLogPostRequest.Content,
                ShortDescription = addBLogPostRequest.ShortDescription,
                FeaturedImageUrl = addBLogPostRequest.FeaturedImageUrl,
                UrlHandle = addBLogPostRequest.UrlHandle,
                PublishedDate = addBLogPostRequest.PublishedDate,
                Author = addBLogPostRequest.Author,
                Visible = addBLogPostRequest.Visible,
            };

            //call repository to add blog post map tags to selected tags
            var selectedTags = new List<Tag>();
            foreach (var selectedTagId in addBLogPostRequest.SelectedTags)
            {
                var selectedTagIdAsGuid = Guid.Parse(selectedTagId);
                var existingTag = await tagRepository.GetAsync(selectedTagIdAsGuid);

                if (existingTag != null)
                {
                    selectedTags.Add(existingTag);
                }
            }
            //mapping tags to domain model / blog post
            blogPost.Tags = selectedTags;
            await blogPostRepository.AddAsync(blogPost);
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> List()
                {

            //call repository to get all blog posts
            var blogPosts = await blogPostRepository.GetAllAsync();
                    return View(blogPosts);
                }
    }
}
