using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Configurations
{
    public class ProfessionalConfiguration : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User)
                .WithOne(u => u.Professional)
                .HasForeignKey<Professional>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Expertise)
                .WithMany()
                .HasForeignKey(p => p.ExpertiseId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.PrivateServices)
                .WithOne(ps => ps.Professional)
                .HasForeignKey(ps => ps.ProfessionalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ProfessionalSpecialties)
           .WithOne(ps => ps.Professional) 
           .HasForeignKey(ps => ps.ProfessionalId) 
           .OnDelete(DeleteBehavior.Cascade);

            

        }
    }
}
