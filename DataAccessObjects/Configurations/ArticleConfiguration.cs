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
            builder.HasOne(a => a.CreatedBy)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.CreatedById)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.Category)
                .WithMany(c => c.Articles) 
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(a => a.ArticleImages)
                .WithOne() 
                .HasForeignKey(ai => ai.ArticleId)  
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
