using CodeCareer.ApplierDetails;
using CodeCareer.Appliers;
using CodeCareer.Posts;
using CodeCareer.Recruiters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL.Configuration
{
    public class ApplierDetailConfiguration : IEntityTypeConfiguration<ApplierDetail>
    {
        public void Configure(EntityTypeBuilder<ApplierDetail> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(p => p.Id)
                   .HasConversion(
                       applierDetailId => applierDetailId.value,
                       value => new ApplierDetailId(value));


            builder.HasOne<Post>()
                .WithMany()
                .HasForeignKey(a => a.PostId)
                .IsRequired();

            builder.HasOne<Applier>()
                .WithMany()
                .HasForeignKey(a => a.ApplierId)
                .IsRequired();
        }
    }
}
