using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCandidate.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
