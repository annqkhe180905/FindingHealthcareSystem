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
    public class PatientUnderlyingDiseaseConfiguration : IEntityTypeConfiguration<PatientUnderlyingDisease>
    {
        public void Configure(EntityTypeBuilder<PatientUnderlyingDisease> builder)
        {
            builder.HasKey(pud => pud.Id);

            builder.HasOne(pud => pud.Patient)
                .WithMany(p => p.PatientUnderlyingDiseases)
                .HasForeignKey(pud => pud.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pud => pud.UnderlyingDisease)
                .WithMany()
                .HasForeignKey(pud => pud.UnderlyingDiseaseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
