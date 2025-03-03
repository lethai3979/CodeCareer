using CodeCareer.Posts;
using CodeCareer.Recruiters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL.Configuration
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasConversion(
                       postId => postId.value,
                       value => new PostId(value));

            //builder.HasOne<Recruiter>()
            //    .WithMany()
            //    .HasForeignKey(p => p.RecruiterId)
            //    .IsRequired();
        }
    }
}
