using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MLCandidate.Data;
using MLCandidate.Models;

namespace MLCandidate.Pages.Posts
{
    [Authorize]
    public class IndexModel : BaseModel
    {
        public PaginatedList<Post> Posts { get; set; }

        public IndexModel(ApplicationDbContext dbContext, IConfiguration configuration)
            :base(dbContext, configuration)
        {
        }

        public async Task<IActionResult> OnGetAsync(int? pageIndex)
        {
            int? pageSize = Configuration.GetValue<int>("AppSettings:PagingSize");

            Posts = await PaginatedList<Post>.CreateAsync(
                DbContext.Posts.AsNoTracking(), pageIndex ?? 1, pageSize ?? 3);

            return Page();
        }

        public async Task<JsonResult> OnGetPostByIdAsync(int id)
        {
            var post = await DbContext.Posts.FindAsync(id);
            return new JsonResult(post);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id, int? pageIndex)
        {
            //try to find the post by id
            var post = await DbContext.Posts.FindAsync(id);

            if (post == null)
            {
                return Page();
            }

            //try to find all related comments
            var comments = await DbContext.Comments
                .Where(c => c.PostId == post.Id)
                .ToListAsync();
            
            //remove the comments and posts
            DbContext.Comments.RemoveRange(comments);
            DbContext.Posts.Remove(post);

            //save changes
            await DbContext.SaveChangesAsync();
            return RedirectToPage(new { pageIndex = pageIndex });
        }
    }
}