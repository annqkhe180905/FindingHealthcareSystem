using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Configurations
{
    public class PublicServiceConfiguration : IEntityTypeConfiguration<PublicService>
    {
        public void Configure(EntityTypeBuilder<PublicService> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder.HasOne(ps => ps.Facility)
                .WithMany(f => f.PublicServices) 
                .HasForeignKey(ps => ps.FacilityId) 
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
