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
    public class ProfessionalSpecialtyConfiguration : IEntityTypeConfiguration<ProfessionalSpecialty>
    {
        public void Configure(EntityTypeBuilder<ProfessionalSpecialty> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder.HasOne(ps => ps.Professional)
                .WithMany(p => p.ProfessionalSpecialties) 
                .HasForeignKey(ps => ps.ProfessionalId) 
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(ps => ps.Specialty)
                .WithMany(s => s.ProfessionalSpecialties)  
                .HasForeignKey(ps => ps.SpecialtyId)  
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
