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
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Patients)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Patient
                {
                    Id = 1,
                    UserId = 2,
                    Note = "John's medical history",
                    CreatedAt = new DateTime(2024, 1, 1),
                    UpdatedAt = new DateTime(2024, 1, 1)
                }
            );
        }
    }
}
