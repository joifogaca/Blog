using Blog.Data;
using Blog.ViewsModels.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class PostControlller : ControllerBase
    {
        [HttpGet("v1/posts")]
        public async Task<IActionResult> GetAsync([FromServices]BlogDataContext context) {

            var posts = await context.
                Posts.
                AsNoTracking().
                Include(x => x.Category).
                Include(x => x.Author).
                Select(x => new ListPostViewModel {
                    Id = x.Id,
                    Title = x.Title,
                    Slug = x.Slug,
                    LastUpdateDate = x.LastUpdateDate,
                    Category = x.Category.Name,
                    Author = $"{x.Author.Name } ({x.Author.Email})"
                }).
                ToListAsync();
        return Ok(posts);
        }
    }
}
