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
    public class FacilityDepConfiguration : IEntityTypeConfiguration<FacilityDepartment>
    {
        public void Configure(EntityTypeBuilder<FacilityDepartment> builder)
        {
            builder.HasKey(fd => fd.Id);

            builder.HasOne(fd => fd.Facility)
                .WithMany(f => f.FacilityDepartments) 
                .HasForeignKey(fd => fd.FacilityId)  
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(fd => fd.Department)
                .WithMany(d => d.FacilityDepartments) 
                .HasForeignKey(fd => fd.DepartmentId) 
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
