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
    public class PrivateServiceConfiguration : IEntityTypeConfiguration<PrivateService>
    {
        public void Configure(EntityTypeBuilder<PrivateService> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder.HasOne(ps => ps.Professional)
                .WithMany(p => p.PrivateServices) 
                .HasForeignKey(ps => ps.ProfessionalId) 
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
