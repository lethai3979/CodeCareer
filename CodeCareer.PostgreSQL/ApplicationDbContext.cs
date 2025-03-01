using CodeCareer.ApplierDetails;
using CodeCareer.Appliers;
using CodeCareer.Posts;
using CodeCareer.Recruiters;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Applier> Appliers { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Recruiter> Recruiters { get; set; } = null!;
        public DbSet<ApplierDetail> ApplierDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
