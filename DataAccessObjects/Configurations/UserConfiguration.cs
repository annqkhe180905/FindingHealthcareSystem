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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasOne(u => u.Patient)
                   .WithOne(p => p.User)
                   .HasForeignKey<Patient>(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Professional)
                 .WithOne(p => p.User)
                 .HasForeignKey<Professional>(p => p.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Articles)
                .WithOne(a => a.CreatedBy)
                .HasForeignKey(a => a.CreatedById)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                 new User
                 {
                     Id = 1,
                     Role = Role.Admin,
                     Fullname = "Admin User",
                     Password = "admin123",
                     PhoneNumber = "0987654321",
                     Email = "admin@gmail.com",
                     Gender = "Male",
                     Birthday = new DateOnly(1985, 2, 20),
                     Status = UserStatus.Active
                 }
            );
        }
    }
}
