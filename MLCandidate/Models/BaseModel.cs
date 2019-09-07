using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MLCandidate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCandidate.Models
{
    public class BaseModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IConfiguration configuration;

        public BaseModel(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public ApplicationDbContext DbContext { get { return dbContext; } }
        public IConfiguration Configuration { get { return configuration; } }
    }
}
