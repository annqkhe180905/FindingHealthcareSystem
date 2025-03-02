using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(a => a.CreatedBy)
              .WithMany()
              .HasForeignKey(a => a.CreatedById)
              .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.Category)
              .WithMany()
              .HasForeignKey(a => a.CategoryId)
              .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(a => a.ArticleImages)
                   .WithOne()
                   .HasForeignKey(ai => ai.Id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
