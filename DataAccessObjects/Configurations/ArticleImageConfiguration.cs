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
    public class ArticleImageConfiguration : IEntityTypeConfiguration<ArticleImage>
    {
        public void Configure(EntityTypeBuilder<ArticleImage> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(ai => ai.Article)
           .WithMany(a => a.ArticleImages)
           .HasForeignKey(ai => ai.ArticleId)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
