using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCandidate.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int CommentStatusId { get; set; }
        public int PostId { get; set; }
        public CommentStatus CommentStatus { get; set; }
    }
}
