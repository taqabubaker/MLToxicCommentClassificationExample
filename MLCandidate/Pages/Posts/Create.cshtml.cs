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
    public class CreateModel : BaseModel
    {
        public CreateModel(ApplicationDbContext dbContext, IConfiguration configuration)
            :base(dbContext, configuration)
        {            
        }

        [BindProperty]
        public Post Post { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DbContext.Posts.Add(Post);
            await DbContext.SaveChangesAsync();

            var count = await DbContext.Posts.CountAsync();
            int? pageSize = Configuration.GetValue<int>("AppSettings:PagingSize");
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return RedirectToPage("./Index", new { pageIndex = totalPages });
        }
    }
}