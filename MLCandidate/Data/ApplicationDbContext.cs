using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MLCandidate.Models;

namespace MLCandidate.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentStatus> CommentStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CommentStatus>()
                .HasData(
                new CommentStatus
                {
                    Id = 1,
                    Description = "Pending"
                },
                new CommentStatus
                {
                    Id = 2,
                    Description = "Under Review"
                },
                new CommentStatus
                {
                    Id = 3,
                    Description = "Posted"
                });
        }
    }
}
