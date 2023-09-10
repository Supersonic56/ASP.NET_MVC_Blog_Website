using Azure;
using LKBlog.Data;
using LKBlog.Models.Domain;
using LKBlog.Models.ViewModels;
using LKBlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LKBlog.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        //private readonly LKBlogDbContext lKBlogDbContext;

        //private LKBlogDbContext _lKBlogDbContext;

        public AdminTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
            //_lKBlogDbContext = lKBlogDbContext;
            //this.lKBlogDbContext = lKBlogDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            //Mapping AddTagRequest to Tag domain model 
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            await tagRepository.AddAsync(tag);

            //var name = addTagRequest.Name;
            //var displayName = addTagRequest.DisplayName;
            //var name = Request.Form["name"];
            //var displayName = Request.Form["displayName"];
            //return View("Add");

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        //(LKBlogDbContext lKBlogDbContext)
        {
            //use dbContext to read the tags
            var tags = await tagRepository.GetAllAsync();
            //var tags = await tagRepository.GetAllAsync();

            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await tagRepository.GetAsync(id);
            //1st method
            //var Tag = lKBlogDbContext.Tags.Find(id);

            //2nd method
            //var tag = await lKBlogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);

            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };

                return View(editTagRequest);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var updatedTag = await tagRepository.UpdateAsync(tag);

            if (updatedTag != null) 
            {
                //show success notification
                //TempData["Success"] = "Tag updated successfully";
            }
            else
            {
                //show error noticication
                //TempData["Error"] = "Tag NOT updated successfully";
            }

            return RedirectToAction("List");
            //return RedirectToAction("Edit", new { id = editTagRequest.Id });
            //var existingTag = await lKBlogDbContext.Tags.FindAsync(tag.Id);

            //if (existingTag != null) 
            //{
            //    existingTag.Name = tag.Name;
            //    existingTag.DisplayName = tag.DisplayName;  

            //    //save the changes
            //    await lKBlogDbContext.SaveChangesAsync();
            //    //show success notification
            //    return RedirectToAction("List");
            //}

            //show failure notification

        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest) 
        {
            //var tag = await lKBlogDbContext.Tags.FindAsync(editTagRequest.Id);

            //if (tag != null) 
            //{
            //    lKBlogDbContext.Tags.Remove(tag);
            //    await lKBlogDbContext.SaveChangesAsync();

            //    //show a success notification
            //    return RedirectToAction("List");
            //}

            var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);

            if (deletedTag != null)
            {
                //show success notification
                return RedirectToAction("List");
            }

            //show an error notification
            return RedirectToAction("List");
            //return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }
    }
}
