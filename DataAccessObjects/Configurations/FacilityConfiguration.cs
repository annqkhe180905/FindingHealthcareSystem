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
    public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasMany(f => f.FacilityDepartments)
                   .WithOne(fd => fd.Facility)
                   .HasForeignKey(fd => fd.FacilityId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.PublicServices)
                   .WithOne(ps => ps.Facility)
                   .HasForeignKey(ps => ps.FacilityId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Type)
                   .WithMany(ft => ft.Facilities)
                   .HasForeignKey(f => f.TypeId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
