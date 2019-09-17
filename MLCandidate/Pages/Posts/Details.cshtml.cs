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
    public class DetailsModel : BaseModel
    {
        public DetailsModel(ApplicationDbContext dbContext, IConfiguration confinguraiton)
            : base(dbContext, confinguraiton)
        {

        }

        [BindProperty]
        public Post Post { get; set; }

        [BindProperty]
        public Comment Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Post = await DbContext.Posts
                .Include(p => p.Comments)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (Post == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("./Details", new { id = Post.Id });
            }

            Comment.CommentStatusId = (await DbContext.CommentStatuses
                .SingleOrDefaultAsync(cs => cs.Description == "Under Review"))
                .Id;
            Comment.PostId = Post.Id;
            DbContext.Comments.Add(Comment);
            await DbContext.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = Post.Id });
        }
    }
}