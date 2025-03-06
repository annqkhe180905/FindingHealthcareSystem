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
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Payment)
                .WithMany()
                .HasForeignKey(a => a.PaymentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(a => a.MedicalRecords)
               .WithOne(mr => mr.Appointment)
               .HasForeignKey(mr => mr.AppointmentId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
