using System;
using System.Collections.Generic;
using System.Text;

namespace MLCandidate.Services
{
    public interface IToxicCommentService
    {
        bool IsToxicComment(string comment);
    }
}
